namespace app.Models.Diagram1 
{
    public class Producto {
      private string Codigo;
      private string Nombre;
      private int Stock;
      private double ValorUnitario;

      public Producto(string codigo, string nombre, int stock, double valorUnitario) {
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
