#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petStoreMonitoringApp.Models;

namespace petStoreMonitoringApp.Controllers
{
    public class AnimalPurchaseCategoriesController : Controller
    {
        private readonly petStoreMonitoringAppContext _context;

        public AnimalPurchaseCategoriesController(petStoreMonitoringAppContext context)
        {
            _context = context;
        }

        // GET: AnimalPurchaseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalPurchaseCategory.ToListAsync());
        }

        // GET: AnimalPurchaseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalPurchaseCategory = await _context.AnimalPurchaseCategory
                .FirstOrDefaultAsync(m => m.AnimalPurchaseCategoryId == id);
            if (animalPurchaseCategory == null)
            {
                return NotFound();
            }

            return View(animalPurchaseCategory);
        }

        // GET: AnimalPurchaseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalPurchaseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalPurchaseCategoryId,Category,Date,TimeStamp")] AnimalPurchaseCategory animalPurchaseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalPurchaseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalPurchaseCategory);
        }

        // GET: AnimalPurchaseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalPurchaseCategory = await _context.AnimalPurchaseCategory.FindAsync(id);
            if (animalPurchaseCategory == null)
            {
                return NotFound();
            }
            return View(animalPurchaseCategory);
        }

        // POST: AnimalPurchaseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalPurchaseCategoryId,Category,Date,TimeStamp")] AnimalPurchaseCategory animalPurchaseCategory)
        {
            if (id != animalPurchaseCategory.AnimalPurchaseCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalPurchaseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalPurchaseCategoryExists(animalPurchaseCategory.AnimalPurchaseCategoryId))
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
            return View(animalPurchaseCategory);
        }

        // GET: AnimalPurchaseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalPurchaseCategory = await _context.AnimalPurchaseCategory
                .FirstOrDefaultAsync(m => m.AnimalPurchaseCategoryId == id);
            if (animalPurchaseCategory == null)
            {
                return NotFound();
            }

            return View(animalPurchaseCategory);
        }

        // POST: AnimalPurchaseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalPurchaseCategory = await _context.AnimalPurchaseCategory.FindAsync(id);
            _context.AnimalPurchaseCategory.Remove(animalPurchaseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalPurchaseCategoryExists(int id)
        {
            return _context.AnimalPurchaseCategory.Any(e => e.AnimalPurchaseCategoryId == id);
        }
    }
}
