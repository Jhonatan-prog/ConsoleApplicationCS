namespace app.Models.Diagram1 
{
    public class ProductosPorFactura 
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

      public void borrar() {}
      public void consultar() {}
      public void guardar() {}
      public void modificar() {}
    }
}
