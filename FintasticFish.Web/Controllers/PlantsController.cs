using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FintasticFish.Data.Entities;

namespace FintasticFish.Web.Controllers
{
    public class PlantsController : Controller
    {
        private readonly FintasticFishContext _context;

        public PlantsController(FintasticFishContext context)
        {
            _context = context;
        }

        // GET: Plants
        public async Task<IActionResult> Index()
        {
            var fintasticFishContext = _context.Plants.Include(p => p.Mearsurement).Include(p => p.PlantType);
            return View(await fintasticFishContext.ToListAsync());
        }

        // GET: Plants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Mearsurement)
                .Include(p => p.PlantType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // GET: Plants/Create
        public IActionResult Create()
        {
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name");
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name");
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,SalePrice,Taxable,Description,Stock,SaleStartDate,SaleEndDate,PlantTypeId,Size,MearsurementId")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", plant.MearsurementId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // GET: Plants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", plant.MearsurementId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,SalePrice,Taxable,Description,Stock,SaleStartDate,SaleEndDate,PlantTypeId,Size,MearsurementId")] Plant plant)
        {
            if (id != plant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantExists(plant.Id))
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
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", plant.MearsurementId);
            ViewData["PlantTypeId"] = new SelectList(_context.PlantTypes, "Id", "Name", plant.PlantTypeId);
            return View(plant);
        }

        // GET: Plants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plant = await _context.Plants
                .Include(p => p.Mearsurement)
                .Include(p => p.PlantType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plant == null)
            {
                return NotFound();
            }

            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant != null)
            {
                _context.Plants.Remove(plant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantExists(int id)
        {
            return _context.Plants.Any(e => e.Id == id);
        }
    }
}
