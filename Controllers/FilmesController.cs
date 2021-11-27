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
    public class FilmesController : ControllerBase
    {
        private readonly Context _context;
        
        private FilmeService filmeService; // Declara classe de serviço para os métodos http

        public FilmesController(Context context)
        {
            _context = context;
            filmeService = new FilmeService(_context); // Inicializa a classe de serviço
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<IEnumerable<FilmeDTO>> GetFilmes()
        {
            return await filmeService.GetFilmes();
        }
 

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeDTO>> GetFilme(int id)
        {
            var filme = await filmeService.GetFilme(id);
            //System.Diagnostics.Debug.WriteLine(filme);
            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.ID)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
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

        // POST: api/Filmes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            await filmeService.PostFilme(filme);

            return CreatedAtAction("GetFilme", new { id = filme.ID }, filme);
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            
   
            if (filme == null)
            {
                return NotFound();
            }

            await filmeService.DeleteFilme(filme);


            return NoContent();
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.ID == id);
        }
    }
}
