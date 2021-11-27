using FirstEF.Data;
using FirstEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstEF.Services
{
    public class FilmeService
    {
        Context _context;
        public FilmeService(Context context) {
            _context = context;
        }

        // GET /api/Filmes
        public async Task<List<FilmeDTO>> GetFilmes()
        {
            var filmes = from f in _context.Filme
                        select new FilmeDTO()
                        {
                            ID = f.ID,
                            Nome = f.Nome,
                            Ano = f.Ano,
                        };

            return await filmes.ToListAsync();
        }

        // GET /api/Filmes/5
        public async Task<ActionResult<FilmeDTO>> GetFilme(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            if (filme != null)
            {
                return new FilmeDTO()
                {
                    ID = filme.ID,
                    Nome = filme.Nome,
                    Ano = filme.Ano,
                };
            }
            else
            {
                return null;
            }

        }

        // POST /api/Filmes
        public async Task<Filme> PostFilme(Filme filme)
        {
            _context.Filme.Add(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        // DELETE /api/Filme/5
        public async Task<IActionResult> DeleteFilme(Filme filme)
        {
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
