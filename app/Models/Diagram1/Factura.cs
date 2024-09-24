namespace app.Models.Diagram1 
{
    public class Factura 
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

      public void cancelar() {}
      public void consultar() {}
      public void guardar() {}
      public void modificar() {}
    }
}
