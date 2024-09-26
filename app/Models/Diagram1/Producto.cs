// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// controllers
using app.Controllers;

namespace app.Models.Diagram1 
{
    public class Producto : DbRepository {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment in SQL Server
      public int? Codigo { get; set; }  // Primary key
      private string Nombre;
      private int Stock;
      private double ValorUnitario;
      public Producto()
      {
        Nombre = "";
      }

      public Producto(string nombre, int stock, double valorUnitario, int? codigo = null) : base() {
        Codigo = codigo;
        Nombre = nombre;
        Stock = stock;
        ValorUnitario = valorUnitario;
      }

      public void borrar(int codigo) 
      {
        var producto = _context.Producto.Find(codigo);
        if (producto == null)
        {
          Console.Write("Producto no encontrado.");
          return;
        }

        _context.Producto.Remove(producto);
        _context.SaveChanges();
      }
      public Producto consultar(int codigo)
      {
        var producto = _context.Producto.Find(codigo);
        if (producto == null) 
        {
          Console.Write("Empresa no encontrada.");
          return new Producto();
        }

        return producto;
      }
      public void guardar() 
      {
        _context.Producto.Add(this);
        _context.SaveChanges();
        Console.WriteLine("Producto guardada exitosamente.");
      }
      public void Modificar(int codigo, Producto nuevoProducto) 
      {
        var producto = _context.Producto.Find(codigo);
        if (producto == null) 
        {
          Console.Write("Producto no encontrado.");
          return;
        }

        _context.Producto.Update(nuevoProducto);
        _context.SaveChanges();
        Console.WriteLine("Empresa actualizada exitosamente.");
      }
    }
}
