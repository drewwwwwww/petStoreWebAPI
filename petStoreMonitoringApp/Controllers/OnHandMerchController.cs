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
    public class OnHandMerchController : Controller
    {
        private readonly petStoreMonitoringAppContext _context;

        public OnHandMerchController(petStoreMonitoringAppContext context)
        {
            _context = context;
        }

        // GET: OnHandMerch
        public async Task<IActionResult> Index()
        {
            return View(await _context.OnHandMerch.ToListAsync());
        }

        // GET: OnHandMerch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onHandMerch = await _context.OnHandMerch
                .FirstOrDefaultAsync(m => m.OnHandMerchId == id);
            if (onHandMerch == null)
            {
                return NotFound();
            }

            return View(onHandMerch);
        }

        // GET: OnHandMerch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OnHandMerch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnHandMerchId,ItemId,QuantityonHand,Date,TimeStamp")] OnHandMerch onHandMerch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onHandMerch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onHandMerch);
        }

        // GET: OnHandMerch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onHandMerch = await _context.OnHandMerch.FindAsync(id);
            if (onHandMerch == null)
            {
                return NotFound();
            }
            return View(onHandMerch);
        }

        // POST: OnHandMerch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnHandMerchId,ItemId,QuantityonHand,Date,TimeStamp")] OnHandMerch onHandMerch)
        {
            if (id != onHandMerch.OnHandMerchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onHandMerch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnHandMerchExists(onHandMerch.OnHandMerchId))
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
            return View(onHandMerch);
        }

        // GET: OnHandMerch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onHandMerch = await _context.OnHandMerch
                .FirstOrDefaultAsync(m => m.OnHandMerchId == id);
            if (onHandMerch == null)
            {
                return NotFound();
            }

            return View(onHandMerch);
        }

        // POST: OnHandMerch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var onHandMerch = await _context.OnHandMerch.FindAsync(id);
            _context.OnHandMerch.Remove(onHandMerch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnHandMerchExists(int id)
        {
            return _context.OnHandMerch.Any(e => e.OnHandMerchId == id);
        }
    }
}
