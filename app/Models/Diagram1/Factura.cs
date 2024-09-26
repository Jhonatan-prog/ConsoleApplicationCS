// controllers
using app.Controllers;

namespace app.Models.Diagram1 
{
    public class Factura : DbRepository
    {
      private DateOnly Fecha;
      private long Numero;
      private double Total;
      // Relationships
      public Cliente Cliente { get; set; }
      public Vendedor Vendedor { get; set; }

      public Factura(DateOnly fecha, long numero, double total, Cliente cliente, Vendedor vendedor) 
      {
        Fecha = fecha;
        Numero = numero;
        Total = total;
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Vendedor = vendedor ?? throw new ArgumentNullException(nameof(vendedor));
      }

        public void cancelar(int codigo) 
      {
        var factura = _context.Factura.Find(codigo);
        if (factura == null)
        {
          Console.Write("Factura del cliente no encontrada.");
          return;
        }

        _context.Factura.Remove(factura);
        _context.SaveChanges();
      }
      public Factura? consultar(int numero) 
      {
        var factura = _context.Factura.Find(numero);
        if (factura == null) 
        {
          Console.Write("Factura del cliente no encontrada.");
          return null;
        }

        return factura;
      }
      public void guardar() 
      {
        _context.Factura.Add(this);
        _context.SaveChanges();
        Console.WriteLine("Producto guardada exitosamente.");
      }
      public void modificar(int numero, Factura nuevaFactura) 
      {
        var factura = _context.Factura.Find(numero);
        if (factura == null) 
        {
          Console.Write("Factura del cliente no encontrada.");
          return;
        }

        _context.Factura.Update(nuevaFactura);
        _context.SaveChanges();
        Console.WriteLine("Empresa actualizada exitosamente.");
      }
    }
}
