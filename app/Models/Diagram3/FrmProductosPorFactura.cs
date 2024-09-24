namespace TallerEvaluativo.Diagram3.Facturas {
    public class FrmProductosPorFactura 
    {
      // attributes
      private int Cantidad;
      private double Subtotal;

      // Association with a product and an invoice
      public FrmProducto? Producto { get; set; }
      public FrmFactura? Factura { get; set; }
      public FrmProductosPorFactura(int cantidad, double subtotal) 
      {
        Cantidad = cantidad;
        Subtotal = subtotal;
      }

      public void borrar() {}
      public void consultar() {}
      public void guardar() {}
      public void modificar() {}
    }
}
