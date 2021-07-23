using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cs_Api.Models;

namespace cs_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly CoffeeDbContext _context;

        public SalesController(CoffeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSale>>> GetTblSales()
        {
            return await _context.TblSales.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSale>> GetTblSale(int id)
        {
            var tblSale = await _context.TblSales.FindAsync(id);

            if (tblSale == null)
            {
                return NotFound();
            }

            return tblSale;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSale(int id, TblSale tblSale)
        {
            if (id != tblSale.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(tblSale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSaleExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSale>> PostTblSale(TblSale tblSale)
        {
            _context.TblSales.Add(tblSale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSale", new { id = tblSale.SaleId }, tblSale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSale(int id)
        {
            var tblSale = await _context.TblSales.FindAsync(id);
            if (tblSale == null)
            {
                return NotFound();
            }

            _context.TblSales.Remove(tblSale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSaleExists(int id)
        {
            return _context.TblSales.Any(e => e.SaleId == id);
        }
    }
}
