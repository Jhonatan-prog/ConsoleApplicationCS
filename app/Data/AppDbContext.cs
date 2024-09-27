// Microsoft
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

// Diagrams
using app.Models.Diagram1;

namespace app.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductosPorFactura> ProductosPorFactura { get; set; }
        public DbSet<Factura> Factura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de la cadena de conexión a SQLEXPRESS
            string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(rootDirectory)
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno entre Persona y Cliente (con eliminación en cascada)
            // Configuring the relationship with Cliente
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Persona)
                .WithMany(p => p.Clientes)
                .HasForeignKey(c => c.PersonaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.PersonaReferencia)
                .WithMany()
                .HasForeignKey(p => p.PersonaCodigo)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a muchos entre Factura y Cliente
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the relationship with Vendedor
            modelBuilder.Entity<Vendedor>()
                .HasOne(v => v.Persona)
                .WithMany()
                .HasForeignKey(v => v.PersonaCodigo)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre ProductosPorFactura y Factura
            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(pf => pf.Factura)
                .WithMany(f => f.ProductosPorFactura)
                .HasForeignKey(pf => pf.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación uno a muchos entre ProductosPorFactura y Producto
            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(pf => pf.Producto)
                .WithMany(p => p.ProductosPorFactura)
                .HasForeignKey(pf => pf.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
