using Microsoft.EntityFrameworkCore;
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
            // Configuración de la cadena de conexión a LocalDB
            optionsBuilder.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=ConsoleApplicationDB;Trusted_Connection=True;Encrypt=False;");
        }
    }

}
