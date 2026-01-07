using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class CyberCorpDbContext : DbContext
    {
        public CyberCorpDbContext(DbContextOptions<CyberCorpDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuario>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Venta>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Devolucion>().Property(d => d.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Venta>()
                .Property(v => v.Precio)
                .HasColumnType("decimal(18,2)");
            base.OnModelCreating(modelBuilder);
        }
    }
}