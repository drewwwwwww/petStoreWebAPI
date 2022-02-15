#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petStoreWebAPI.Data;
using petStoreWebAPI.Models;

namespace petStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalPurchaseCategoriesController : ControllerBase
    {
        private readonly petStoreMonitoringAppDbContext _context;

        public AnimalPurchaseCategoriesController(petStoreMonitoringAppDbContext context)
        {
            _context = context;
        }

        // GET: api/AnimalPurchaseCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalPurchaseCategory>>> GetAnimalPurchaseCategory()
        {
            return await _context.AnimalPurchaseCategory.ToListAsync();
        }

        // GET: api/AnimalPurchaseCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalPurchaseCategory>> GetAnimalPurchaseCategory(int id)
        {
            var animalPurchaseCategory = await _context.AnimalPurchaseCategory.FindAsync(id);

            if (animalPurchaseCategory == null)
            {
                return NotFound();
            }

            return animalPurchaseCategory;
        }

        // PUT: api/AnimalPurchaseCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalPurchaseCategory(int id, AnimalPurchaseCategory animalPurchaseCategory)
        {
            if (id != animalPurchaseCategory.AnimalPurchaseCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(animalPurchaseCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalPurchaseCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnimalPurchaseCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalPurchaseCategory>> PostAnimalPurchaseCategory(AnimalPurchaseCategory animalPurchaseCategory)
        {
            _context.AnimalPurchaseCategory.Add(animalPurchaseCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalPurchaseCategory", new { id = animalPurchaseCategory.AnimalPurchaseCategoryId }, animalPurchaseCategory);
        }

        // DELETE: api/AnimalPurchaseCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalPurchaseCategory(int id)
        {
            var animalPurchaseCategory = await _context.AnimalPurchaseCategory.FindAsync(id);
            if (animalPurchaseCategory == null)
            {
                return NotFound();
            }

            _context.AnimalPurchaseCategory.Remove(animalPurchaseCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalPurchaseCategoryExists(int id)
        {
            return _context.AnimalPurchaseCategory.Any(e => e.AnimalPurchaseCategoryId == id);
        }
    }
}
