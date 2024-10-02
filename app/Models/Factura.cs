// controllers
namespace app.Models 
{

  public class Factura
  {
    public long Numero { get; set; }  // BIGINT
    public DateTime Fecha { get; set; } = DateTime.Now;  // DATE
    public float Total { get; set; }  // FLOAT
    public long CodigoCliente { get; set; }  // BIGINT

    // Navigation properties
    public virtual Cliente Cliente { get; set; }
    public virtual ICollection<ProductosPorFactura> ProductosPorFacturas { get; set; } = new List<ProductosPorFactura>();
  }
/*     public class Factura : DbRepository
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-increment in SQL Server
      public long? Numero { get; set; }  // Primary key
      public DateTime  Fecha { get; set; }
      public double Total { get; set; }

      // Relación con Cliente
      public long ClienteId { get; set; }
      public virtual Cliente Cliente { get; set; }

      // Relación con ProductosPorFactura
      public virtual ICollection<ProductosPorFactura> ProductosPorFactura { get; set; }

      public Factura() {}

      public Factura(DateTime fecha, double total, Cliente cliente, Vendedor vendedor, long? numero = null) 
      {
        Numero = numero;
        Fecha = fecha;
        Total = total;
        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
      }

        public void cancelar(long codigo) 
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
      public Factura? consultar(long numero) 
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
      public void modificar(long numero, Factura nuevaFactura) 
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
    } */
}
