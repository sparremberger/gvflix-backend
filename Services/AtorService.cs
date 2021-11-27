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
    public class AtorService
    {
        Context _context;
        public AtorService(Context context)
        {
            _context = context;
        }

        // GET /api/Atores
        public async Task<List<AtorDTO>> GetAtores()
        {
            var atores = from a in _context.Ator
                         select new AtorDTO()
                         {
                             ID = a.ID,
                             Nome = a.Nome,
                             Nacionalidade = a.Nacionalidade,

                         };

            return await atores.ToListAsync();
        }

        // GET /api/Atores/5
        public async Task<ActionResult<AtorDTO>> GetAtor(int id)
        {
            var ator = await _context.Ator.FindAsync(id);
            if (ator != null)
            {
                return new AtorDTO()
                {
                    ID = ator.ID,
                    Nome = ator.Nome,
                    Nacionalidade = ator.Nacionalidade,
                };
            }
            else
            {
                return null;
            }

        }

        // POST /api/Atores
        public async Task<Ator> PostAtor(Ator ator)
        {
            _context.Ator.Add(ator);
            await _context.SaveChangesAsync();
            return ator;
        }

        // DELETE /api/Atores/5
        public async Task<IActionResult> DeleteAtor(Ator ator)
        {
            _context.Ator.Remove(ator);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
