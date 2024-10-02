// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// controllers
using app.Controllers;

namespace app.Models 
{
  public class ProductosPorFactura
  {
      public long NumeroFactura { get; set; }  // BIGINT
      public long CodigoProducto { get; set; }  // BIGINT
      public int Cantidad { get; set; }  // INT
      public float Subtotal { get; set; }  // FLOAT

      // Navigation properties
      public virtual Factura Factura { get; set; }
      public virtual Producto Producto { get; set; }
  }
/*     public class ProductosPorFactura : DbRepository
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment in SQL Server
      public long? Codigo { get; set; }
      public int Cantidad { get; set; }
      public double Subtotal { get; set; }

      // Relación con Factura
      public long FacturaId { get; set; }
      public virtual Factura Factura { get; set; }

      // Relación con Producto
      public long ProductoId { get; set; }
      public virtual Producto Producto { get; set; }

      public ProductosPorFactura() {}

      public ProductosPorFactura(int cantidad, double subtotal) 
      {
        Cantidad = cantidad;
        Subtotal = subtotal;
      }

      public void borrar(long numero_factura) 
      {
        var Pfactura = _context.ProductosPorFactura.Find(numero_factura);
        if (Pfactura == null)
        {
          Console.Write("Porductos por factura no encontrados.");
          return;
        }

        _context.ProductosPorFactura.Remove(Pfactura);
        _context.SaveChanges();
      }
      public ProductosPorFactura? consultar(long numero_factura) 
      {
        var PFactura = _context.ProductosPorFactura.Find(numero_factura);
        if (PFactura == null) 
        {
          Console.Write("Porductos por factura no encontrados.");
          return null;
        }

        return PFactura;
      }
      public void guardar() 
      {
        _context.ProductosPorFactura.Add(this);
        _context.SaveChanges();
        Console.WriteLine("Producto guardada exitosamente.");
      }
      public void modificar(long numero_factura, ProductosPorFactura  nuevoPFactura) 
      {
        var PFactura = _context.ProductosPorFactura.Find(numero_factura);
        if (PFactura == null) 
        {
          Console.Write("Porductos por factura no encontrados.");
          return;
        }

        _context.ProductosPorFactura.Update(nuevoPFactura);
        _context.SaveChanges();
        Console.WriteLine("Productos actualizados exitosamente.");
      }
    } */
}
