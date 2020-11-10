using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Model;

namespace WEBAPI.Controllers
{
    [Route("api/Adults")]
    [ApiController]
    public class AdultsController : ControllerBase
    {
        private readonly AdultContext _context;

        public AdultsController(AdultContext context)
        {
            _context = context;
        }

        // GET: api/Adults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adult>>> GetAdults()
        {
            return await _context.Adults.ToListAsync();
        }

        // GET: api/Adults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            var adult = await _context.Adults.FindAsync(id);

            if (adult == null)
            {
                return NotFound();
            }

            return adult;
        }

        // PUT: api/Adults/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdult(int id, Adult adult)
        {
            if (id != adult.Id)
            {
                return BadRequest();
            }

            _context.Entry(adult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdultExists(id))
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

        // POST: api/Adults
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdult(Adult adult)
        {
            _context.Adults.Add(adult);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAdult), new { id = adult.Id }, adult);
          //  return CreatedAtAction("GetAdult", new { id = adult.Id }, adult);
        }

        // DELETE: api/Adults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adult>> DeleteAdult(int id)
        {
            var adult = await _context.Adults.FindAsync(id);
            if (adult == null)
            {
                return NotFound();
            }

            _context.Adults.Remove(adult);
            await _context.SaveChangesAsync();

            return adult;
        }

        private bool AdultExists(int id)
        {
            return _context.Adults.Any(e => e.Id == id);
        }
    }
}
