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
    public class OnHandMerchController : ControllerBase
    {
        private readonly petStoreMonitoringAppDbContext _context;

        public OnHandMerchController(petStoreMonitoringAppDbContext context)
        {
            _context = context;
        }

        // GET: api/OnHandMerches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnHandMerch>>> GetOnHandMerch()
        {
            return await _context.OnHandMerch.ToListAsync();
        }

        // GET: api/OnHandMerches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnHandMerch>> GetOnHandMerch(int id)
        {
            var onHandMerch = await _context.OnHandMerch.FindAsync(id);

            if (onHandMerch == null)
            {
                return NotFound();
            }

            return onHandMerch;
        }

        // PUT: api/OnHandMerches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnHandMerch(int id, OnHandMerch onHandMerch)
        {
            if (id != onHandMerch.OnHandMerchId)
            {
                return BadRequest();
            }

            _context.Entry(onHandMerch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnHandMerchExists(id))
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

        // POST: api/OnHandMerches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnHandMerch>> PostOnHandMerch(OnHandMerch onHandMerch)
        {
            _context.OnHandMerch.Add(onHandMerch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnHandMerch", new { id = onHandMerch.OnHandMerchId }, onHandMerch);
        }

        // DELETE: api/OnHandMerches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnHandMerch(int id)
        {
            var onHandMerch = await _context.OnHandMerch.FindAsync(id);
            if (onHandMerch == null)
            {
                return NotFound();
            }

            _context.OnHandMerch.Remove(onHandMerch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnHandMerchExists(int id)
        {
            return _context.OnHandMerch.Any(e => e.OnHandMerchId == id);
        }
    }
}
