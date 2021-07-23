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
    public class PaymentsController : ControllerBase
    {
        private readonly CoffeeDbContext _context;

        public PaymentsController(CoffeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPay>>> GetTblPays()
        {
            return await _context.TblPays.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPay>> GetTblPay(int id)
        {
            var tblPay = await _context.TblPays.FindAsync(id);

            if (tblPay == null)
            {
                return NotFound();
            }

            return tblPay;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPay(int id, TblPay tblPay)
        {
            if (id != tblPay.PayId)
            {
                return BadRequest();
            }

            _context.Entry(tblPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPayExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPay>> PostTblPay(TblPay tblPay)
        {
            _context.TblPays.Add(tblPay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPay", new { id = tblPay.PayId }, tblPay);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPay(int id)
        {
            var tblPay = await _context.TblPays.FindAsync(id);
            if (tblPay == null)
            {
                return NotFound();
            }

            _context.TblPays.Remove(tblPay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPayExists(int id)
        {
            return _context.TblPays.Any(e => e.PayId == id);
        }
    }
}
