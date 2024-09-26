// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// controllers
using app.Controllers;

namespace app.Models.Diagram1 
{
    public class Empresa : DbRepository {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment in SQL Server
      public int? Codigo { get; set; }  // Primary key
      private string Nombre { get; set;}
      public Empresa() : base() 
      {
        Nombre = "";
      }

      public Empresa(string nombre, int? codigo = null) : base() {
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

      public Empresa Consultar(string nombre) 
      {
        var empresa = _context.Empresa.FirstOrDefault(field => field.Nombre == nombre);
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
    }
}
