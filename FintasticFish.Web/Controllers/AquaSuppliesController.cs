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
    public class AquaSuppliesController : Controller
    {
        private readonly FintasticFishContext _context;

        public AquaSuppliesController(FintasticFishContext context)
        {
            _context = context;
        }

        // GET: AquaSupplies
        public async Task<IActionResult> Index()
        {
            var fintasticFishContext = _context.AquaSupplies.Include(a => a.Mearsurement).Include(a => a.Supplier);
            return View(await fintasticFishContext.ToListAsync());
        }

        // GET: AquaSupplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquaSupplies = await _context.AquaSupplies
                .Include(a => a.Mearsurement)
                .Include(a => a.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aquaSupplies == null)
            {
                return NotFound();
            }

            return View(aquaSupplies);
        }

        // GET: AquaSupplies/Create
        public IActionResult Create()
        {
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: AquaSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,SalePrice,Size,Description,Taxable,Stock,SupplierId,SaleStartDate,SaleEndDate,MearsurementId")] AquaSupplies aquaSupplies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aquaSupplies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", aquaSupplies.MearsurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", aquaSupplies.SupplierId);
            return View(aquaSupplies);
        }

        // GET: AquaSupplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquaSupplies = await _context.AquaSupplies.FindAsync(id);
            if (aquaSupplies == null)
            {
                return NotFound();
            }
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", aquaSupplies.MearsurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", aquaSupplies.SupplierId);
            return View(aquaSupplies);
        }

        // POST: AquaSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,SalePrice,Size,Description,Taxable,Stock,SupplierId,SaleStartDate,SaleEndDate,MearsurementId")] AquaSupplies aquaSupplies)
        {
            if (id != aquaSupplies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aquaSupplies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AquaSuppliesExists(aquaSupplies.Id))
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
            ViewData["MearsurementId"] = new SelectList(_context.Measurements, "Id", "Name", aquaSupplies.MearsurementId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", aquaSupplies.SupplierId);
            return View(aquaSupplies);
        }

        // GET: AquaSupplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquaSupplies = await _context.AquaSupplies
                .Include(a => a.Mearsurement)
                .Include(a => a.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aquaSupplies == null)
            {
                return NotFound();
            }

            return View(aquaSupplies);
        }

        // POST: AquaSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aquaSupplies = await _context.AquaSupplies.FindAsync(id);
            if (aquaSupplies != null)
            {
                _context.AquaSupplies.Remove(aquaSupplies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AquaSuppliesExists(int id)
        {
            return _context.AquaSupplies.Any(e => e.Id == id);
        }
    }
}
