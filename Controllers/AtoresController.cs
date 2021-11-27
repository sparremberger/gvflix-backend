using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstEF.Data;
using FirstEF.Models;
using FirstEF.Services;

namespace FirstEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtoresController : ControllerBase
    {
        private readonly Context _context;
        private AtorService atorService;

        public AtoresController(Context context)
        {
            _context = context;
            atorService = new AtorService(_context);
        }

        // GET: api/Ators
        [HttpGet]
        public async Task<IEnumerable<AtorDTO>> GetAtores()
        {
            return await atorService.GetAtores();
        }

        // GET: api/Atores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtorDTO>> GetAtor(int id)
        {
            var ator = await atorService.GetAtor(id);
            if (ator == null)
            {
                return NotFound();
            }

            return ator;
        }


        // PUT: api/Ators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtor(int id, Ator ator)
        {
            if (id != ator.ID)
            {
                return BadRequest();
            }

            _context.Entry(ator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtorExists(id))
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

        // POST: api/Ators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ator>> PostAtor(Ator ator)
        {
            await atorService.PostAtor(ator);

            return CreatedAtAction("GetAtor", new { id = ator.ID }, ator);
        }

        // DELETE: api/Ators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtor(int id)
        {
            var ator = await _context.Ator.FindAsync(id);
            if (ator == null)
            {
                return NotFound();
            }

            await atorService.DeleteAtor(ator);

            return NoContent();
        }

        private bool AtorExists(int id)
        {
            return _context.Ator.Any(e => e.ID == id);
        }
    }
}
