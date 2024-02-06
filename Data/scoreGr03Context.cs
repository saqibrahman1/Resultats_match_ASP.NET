using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using scoreGr03.Models;

namespace scoreGr03.Data
{
    public class scoreGr03Context : DbContext
    {
        public scoreGr03Context (DbContextOptions<scoreGr03Context> options)
            : base(options)
        {
        }

        public DbSet<scoreGr03.Models.Match> Match { get; set; } = default!;
        public DbSet<scoreGr03.Models.But> But { get; set; } = default!;
        public DbSet<scoreGr03.Models.Joueur> Joueur { get; set; } = default!;
        public DbSet<scoreGr03.Models.Equipe> Equipe { get; set; } = default!;
    }
}
