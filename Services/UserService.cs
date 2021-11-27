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
    public class UserService
    {
        Context _context;
        public UserService(Context context)
        {
            _context = context;
        }

        // GET /api/Usuarios
        public async Task<List<UsuarioDTO>> GetUsuarios()
        {
            var usuarios = from u in _context.Usuario
                         select new UsuarioDTO()
                         {
                             ID = u.ID,
                             Nome = u.Nome,
                             Email = u.Email,
                             Senha = u.Senha,

                         };

            return await usuarios.ToListAsync();
        }

        // GET /api/Usuarios/5
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                return new UsuarioDTO()
                {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                };
            }
            else
            {
                return null;
            }

        }

        // POST /api/Usuarios
        public async Task<Usuario> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // DELETE /api/Usuarios/5
        public async Task<IActionResult> DeleteUsuario(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
