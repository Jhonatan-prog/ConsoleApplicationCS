// Microsoft
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

// Diagrams
using app.Models;

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

            modelBuilder.Entity<Persona>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Vendedor>()
                .HasKey(v => v.Codigo);

            modelBuilder.Entity<Empresa>()
                .HasKey(e => e.Codigo); 

            modelBuilder.Entity<Factura>()
                .HasKey(e => e.Numero);

            modelBuilder.Entity<Producto>()
                .HasKey(pd => pd.Codigo);

            modelBuilder.Entity<ProductosPorFactura>()
                .HasKey(ppf => new { ppf.NumeroFactura, ppf.CodigoProducto });

            modelBuilder.Entity<Cliente>()
                .HasOne<Persona>()
                .WithOne()
                .HasForeignKey<Cliente>(c => c.Codigo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.CodigoEmpresa)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vendedor>()
                .HasOne(p => p.Persona)
                .WithOne(v => v.Vendedor)
                .HasForeignKey<Vendedor>(v => v.Codigo);

            // inheritance for Cliente and Vendedor
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Vendedor>().ToTable("Vendedor");

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.CodigoCliente)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(ppf => ppf.Factura)
                .WithMany(f => f.ProductosPorFacturas)
                .HasForeignKey(ppf => ppf.NumeroFactura)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductosPorFactura>()
                .HasOne(ppf => ppf.Producto)
                .WithMany(p => p.ProductosPorFacturas)
                .HasForeignKey(ppf => ppf.CodigoProducto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
