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
        private DatabaseActions dbAction;
        public AdultsController(AdultContext context,DatabaseActions databaseActions)
        {
            _context = context;
            dbAction = databaseActions;
        }

        // GET: api/Adults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adult>>> GetAdults()
        {
            await dbAction.InsertInit();
            List<Adult> adultList = new List<Adult>();
            for (int x = 0; x < dbAction.getsize(); x++)
            {
                Adult a = dbAction.GetAdultById(x);
                adultList.Add(a);
                Console.WriteLine("Loop： " + x);
            }
            return adultList;
        }

        // GET: api/Adults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adult>> GetAdult(int id)
        {
            //await dbAction.InsertInit();
            var adult = dbAction.GetAdultById(id);
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
            await dbAction.InsertAdult(adult);
            return CreatedAtAction(nameof(GetAdult), new { id = adult.Id }, adult);
          //  return CreatedAtAction("GetAdult", new { id = adult.Id }, adult);
        }

        // DELETE: api/Adults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adult>> DeleteAdult(int id)
        {
            var adult = dbAction.GetAdultById(id);
            if (adult == null)
            {
                return NotFound();
            }

            dbAction.DeleteAdult(adult);

            return adult;
        }

        private bool AdultExists(int id)
        {
            if (dbAction.getsize() == 0)
            {
                return false;
            }
            else return true;
        }
    }
}
