using Microsoft.EntityFrameworkCore;
// using YourNamespace.Models; // Adjust the namespace accordingly

namespace app.Data
{
    public class AppDbContext : DbContext
    {
        // public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración de la cadena de conexión a LocalDB
            optionsBuilder.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=ConsoleApplicationDB;Trusted_Connection=True;Encrypt=False;");
        }
    }

}
