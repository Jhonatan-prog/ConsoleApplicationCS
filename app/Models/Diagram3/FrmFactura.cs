namespace TallerEvaluativo.Diagram3.Facturas {
    public class FrmFactura 
    {
      private DateOnly Fecha;
      private long Numero;
      private double Total;
      // Relationships
      public FrmPersona Cliente { get; set; }
      public FrmPersona Vendedor { get; set; }
      public FrmFactura(DateOnly fecha, long numero, double total, FrmCliente cliente, FrmPersona vendedor) 
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
