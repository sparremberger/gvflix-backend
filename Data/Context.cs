using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstEF.Models;

namespace FirstEF.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base (options) { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Filme> Filme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Filme>().ToTable("Filme");

        }

        public DbSet<FirstEF.Models.Ator> Ator { get; set; }

        public DbSet<FirstEF.Models.FilmeDTO> FilmeDTO { get; set; }
    }
}
