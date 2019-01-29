using EscutaSom.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EscutaSom.Data
{
    public class MeuContext : DbContext
    {

        public DbSet<Album> Albuns { get; set; }
        public DbSet<Banda> Bandas { get; set; }
        public DbSet<Faixa> Faixas { get; set; }
        public DbSet<Gravadora> Gravadoras { get; set; }
        public DbSet<Instrumento> Instrumentos { get; set; }
        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}