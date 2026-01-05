using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.Data
{
    public class CyberCorpDbContext : DbContext
    {
        public CyberCorpDbContext(DbContextOptions<CyberCorpDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Visita> Visitas => Set<Visita>();
    }
}
