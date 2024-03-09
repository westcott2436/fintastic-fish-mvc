using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleApplication.Entities;
using SampleApplication.Models;

namespace SampleApplication.Controllers
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
            var fintasticFishContext = _context.Fish.Include(f => f.Country);
            return View(await fintasticFishContext.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var fish = await _context.Fish
                .Include(f => f.Country)
                .FirstOrDefaultAsync(m => m.FishId == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "CountyId");
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishId,Name,Cost,Stock,WaterTypeId,AggressionLevel,CountryId")] FishModel fish)
        {
            if (ModelState.IsValid)
            {
                var newFish = new Fish()
                {
                    AggressionLevel = fish.AggressionLevel,
                    Cost = fish.Cost,
                    CountryId = fish.CountryId,
                    Name = fish.Name,
                    Stock = fish.Stock,
                    WaterTypeId = fish.WaterTypeId
                };
                _context.Add(newFish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "CountyId", fish.CountryId);
            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "CountyId", fish.CountryId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishId,Name,Cost,Stock,WaterTypeId,AggressionLevel,CountryId")] Fish fish)
        {
            if (id != fish.FishId)
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
                    if (!FishExists(fish.FishId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "CountyId", fish.CountryId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish
                .Include(f => f.Country)
                .FirstOrDefaultAsync(m => m.FishId == id);
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
            var fish = await _context.Fish.FindAsync(id);
            if (fish != null)
            {
                _context.Fish.Remove(fish);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.FishId == id);
        }
    }
}
