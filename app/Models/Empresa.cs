// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// controllers
using app.Controllers;

namespace app.Models 
{
  public class Empresa
  {
      public long Codigo { get; set; }  // BIGINT
      public string Nombre { get; set; }  // VARCHAR(255)

      // Navigation property
      public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
  }

/*     public class Empresa : DbRepository {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment in SQL Server
      public long? Codigo { get; set; }  // Primary key   
      public string Nombre { get; set; }
      // Relación con Clientes
      public virtual ICollection<Cliente> Clientes { get; set; }
      public Empresa() : base() 
      {
        Nombre = "";
      }

      public Empresa(string nombre, long? codigo = null) : base() {
        Codigo = codigo;
        Nombre = nombre;
      }

      public void Borrar() 
      {
        var empresa = _context.Empresa.FirstOrDefault(field => field.Nombre == this.Nombre);
        if (empresa == null) 
        {
          Console.Write("Empresa no encontrada.");
          return;
        }

        _context.Empresa.Remove(empresa);
        _context.SaveChanges();
        Console.WriteLine("Empresa actualizada exitosamente.");
      }

      public Empresa Consultar(long codigo) 
      {
        var empresa = _context.Empresa.FirstOrDefault(field => field.Codigo == codigo);
        if (empresa == null) 
        {
          Console.Write("Empresa no encontrada.");
          return new Empresa();
        }

        return empresa;
      }

      public void Guardar() 
      {
        _context.Empresa.Add(this);
        _context.SaveChanges();
        Console.WriteLine("Empresa guardada exitosamente.");
      }

      public void Modificar(string nuevoNombre) 
      {
        var empresa = _context.Empresa.FirstOrDefault(field => field.Nombre == this.Nombre);
        if (empresa == null) 
        {
          Console.Write("Empresa no encontrada.");
          return;
        }

        empresa.Nombre = nuevoNombre;
        _context.SaveChanges();
        Console.WriteLine("Empresa actualizada exitosamente.");
      }
    } */
}
