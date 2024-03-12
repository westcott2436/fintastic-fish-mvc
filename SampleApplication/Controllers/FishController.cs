using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FintasticFish.Data.Entities;
using SampleApplication.Models;
using FintasticFish.Data;
using Newtonsoft.Json.Linq;
using System.Transactions;

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
            var fintasticFishContext = _context.Fish.Include(f => f.Country)
                                                    .Select(f => new FishModel() 
                                                    {
                                                     Cost = f.Cost,
                                                     CountryId = f.CountryId,
                                                     FishId = f.FishId,
                                                     Name = f.Name,
                                                     Stock = f.Stock,
                                                     WaterTypeId = f.WaterTypeId,
                                                    }); 
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
                .Select(f => new FishModel()
                {
                    Cost = f.Cost,
                    CountryId = f.CountryId,
                    FishId = f.FishId,
                    Name = f.Name,
                    Stock = f.Stock,
                    WaterTypeId = f.WaterTypeId,
                })
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
            //Super breakdown of LINQ steps for review. 
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "Name");
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "WaterTypeId", "Name");
            var stepOne = Enum.GetValues(typeof(SampleApplication.Enumerations.Aggression));
            var stepTwo = stepOne.Cast<Enum>();
            var stepThree = stepTwo.Select(e => new
            {
                WhatTheUserSees = e.ToString(),
                InformationThatFills_WhatTheUserSees = Convert.ToInt32(e).ToString()
            });
            var stepFour = stepThree.ToList();
            ViewData["AggressionLevel"] = new SelectList(stepFour, "InformationThatFills_WhatTheUserSees", "WhatTheUserSees");
            return View();

            //  Concat version of the above

            //  var AggressionLevels = Enum.GetValues(typeof(SampleApplication.Enumerations.Aggression))
            //                           .Cast<Enum>()
            //                           .Select(e => new
            //                           {
            //                           Text = e.ToString(),
            //                           Value = Convert.ToInt32(e).ToString()
            //                           })
            //                           .ToList();
            //  ViewData["AggressionLevel"] = new SelectList(AggressionLevels, "Value", "Text");
            //  return View();

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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "Name");
            ViewData["WaterTypeId"] = new SelectList(_context.WaterTypes, "WaterTypeId", "Name");
            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishEntity = await _context.Fish.FindAsync(id);
            if (fishEntity == null)
            {
                return NotFound();
            }
            var model = new FishModel()
            {
                AggressionLevel = fishEntity.AggressionLevel,
                Cost = fishEntity.Cost,
                CountryId = fishEntity.CountryId,
                Name = fishEntity.Name,
                Stock = fishEntity.Stock,
                WaterTypeId = fishEntity.WaterTypeId
            };
            
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "Name", fishEntity.CountryId);
            return View(model);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //TODO: Find location of use and fix entities/models issue.
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountyId", "Name", fish.CountryId);
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
                .Select(f => new FishModel()
                {
                    AggressionLevel = f.AggressionLevel,
                    Cost = f.Cost,
                    CountryId = f.CountryId,
                    FishId = f.FishId,
                    Name = f.Name,
                    Stock = f.Stock,
                    WaterTypeId = f.WaterTypeId,
                })
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
