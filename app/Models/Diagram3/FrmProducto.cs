namespace TallerEvaluativo.Diagram3.Facturas {
    public class FrmProducto {
      private string Codigo;
      private string Nombre;
      private int Stock;
      private double ValorUnitario;

      public FrmProducto(string codigo, string nombre, int stock, double valorUnitario) {
        Codigo = codigo;
        Nombre = nombre;
        Stock = stock;
        ValorUnitario = valorUnitario;
      }

      public void borrar() {}
      public void consultar() {}
      public void guardar() {}
      public void modificar() {}
    }
}
