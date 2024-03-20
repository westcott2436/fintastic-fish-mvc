using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FintasticFish.Data;
using FintasticFish.Data.Entities;
using SixLabors.ImageSharp.Formats.Webp;
using System.IO;
using SixLabors.ImageSharp;

namespace FintasticFish.Web.Controllers
{
    public class FishController : Controller
    {
        private readonly FintasticFishContext _context;

        public FishController(FintasticFishContext context)
        {
            _context = context;
        }

        // GET: Fish
        public async Task<IActionResult> Index()
        {
            var fintasticFishContext = _context.Fishes.Include(f => f.AggressionLevel).Include(f => f.Country).Include(f => f.Measurement).Include(f => f.Supplier).Include(f => f.WaterType);
            return View(await fintasticFishContext.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishes
                .Include(f => f.AggressionLevel)
                .Include(f => f.Country)
                .Include(f => f.Measurement)
                .Include(f => f.Supplier)
                .Include(f => f.WaterType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            ViewData["AggressionTypeId"] = new SelectList(_context.AggressionTypes, "Id", "Name");
            ViewData["AggressionLevelId"] = new SelectList(_context.AggressionLevels, "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["MeasurementId"] = new SelectList(_context.Measurements, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "ContactName");
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "Id", "Name");
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,Size,MeasurementId,Color,Price,Stock,IsSpecialOrder,Description,FormFile,CountryId,SupplierId,WaterTypeId,AggressionLevelId, AggressionTypeId")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fish.Image = await BuildWebpFromFormFile(fish.FormFile);
                    _context.Add(fish);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {

                }
               
            }
            ViewData["AggressionTypeId"] = new SelectList(_context.AggressionTypes, "Id", "Name");
            ViewData["AggressionLevelId"] = new SelectList(_context.AggressionLevels, "Id", "Name", fish.AggressionLevelId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", fish.CountryId);
            ViewData["MeasurementId"] = new SelectList(_context.Measurements, "Id", "Name", fish.MeasurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "ContactName", fish.SupplierId);
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "Id", "Name", fish.WaterTypeId);
            return View(fish);
        }
        public async Task<FileResult> GetFishImage(int id)
        {
            Fish? fish = await _context.Fishes.FindAsync(id);
            
            return File(fish!.Image, "image/jpg");
        }
        private async Task<byte[]> BuildWebpFromFormFile(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            // need to figure out the webp converstion
            //using var myImage = await Image.LoadAsync(memoryStream);
            //using var outStream = new MemoryStream();
            //await myImage.SaveAsync(outStream, new WebpEncoder());
            return memoryStream.ToArray();
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishes.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }
            ViewData["AggressionLevelId"] = new SelectList(_context.AggressionLevels, "Id", "Id", fish.AggressionLevelId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", fish.CountryId);
            ViewData["MeasurementId"] = new SelectList(_context.Measurements, "Id", "Name", fish.MeasurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "ContactName", fish.SupplierId);
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "Id", "Name", fish.WaterTypeId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,Size,MeasurementId,Color,Price,Stock,IsSpecialOrder,Description,Image,CountryId,SupplierId,WaterTypeId,AggressionLevelId")] Fish fish)
        {
            if (id != fish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AggressionLevelId"] = new SelectList(_context.AggressionLevels, "Id", "Id", fish.AggressionLevelId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", fish.CountryId);
            ViewData["MeasurementId"] = new SelectList(_context.Measurements, "Id", "Name", fish.MeasurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "ContactName", fish.SupplierId);
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "Id", "Name", fish.WaterTypeId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fishes
                .Include(f => f.AggressionLevel)
                .Include(f => f.Country)
                .Include(f => f.Measurement)
                .Include(f => f.Supplier)
                .Include(f => f.WaterType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await _context.Fishes.FindAsync(id);
            if (fish != null)
            {
                _context.Fishes.Remove(fish);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
            return _context.Fishes.Any(e => e.Id == id);
        }
    }
}
