using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Models;

namespace ProiectMeridian.Data
{
    public class ProiectMeridianContext : DbContext
    {
        public ProiectMeridianContext (DbContextOptions<ProiectMeridianContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMeridian.Models.Telefon> Telefon { get; set; } = default!;

        public DbSet<ProiectMeridian.Models.Producator> Producator { get; set; }

        public DbSet<ProiectMeridian.Models.Distribuitor> Distribuitor { get; set; }

        public DbSet<ProiectMeridian.Models.Category> Category { get; set; }

        public DbSet<ProiectMeridian.Models.Client> Client { get; set; }

        public DbSet<ProiectMeridian.Models.Buying> Buying { get; set; }
    }
}
