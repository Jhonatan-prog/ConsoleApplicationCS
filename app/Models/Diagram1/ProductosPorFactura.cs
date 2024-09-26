// controllers
using app.Controllers;

namespace app.Models.Diagram1 
{
    public class ProductosPorFactura : DbRepository
    {
      // attributes
      private int Cantidad;
      private double Subtotal;

      // Association with a product and an invoice
      public Producto? Producto { get; set; }
      public Factura? Factura { get; set; }
      public ProductosPorFactura(int cantidad, double subtotal) 
      {
        Cantidad = cantidad;
        Subtotal = subtotal;
      }

      public void borrar(int numero_factura) 
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
      public ProductosPorFactura? consultar(int numero_factura) 
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
      public void modificar(int numero_factura, ProductosPorFactura  nuevoPFactura) 
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
    }
}
