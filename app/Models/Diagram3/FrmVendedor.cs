namespace TallerEvaluativo.Diagram3.Facturas {
  public class FrmVendedor : FrmPersona {
      private int Carne { get; set; }
      private string Direccion { get; set; }
      public FrmVendedor(string codigo, string email, string nombre, string telefono, int carne, string direccion) 
        : base(codigo, email, nombre, telefono) 
      {
        Carne = carne;
        Direccion = direccion;
      }

      public override void Borrar() 
      {
          // Specific logic for deleting a client
      }
      public override void Consultar() 
      {
          // Specific logic for consulting a client
      }
      public override void Ingresar() 
      {
          // Specific logic for adding a client
      }
      public override void Modificar() 
      {
          // Specific logic for modifying a client
      }
  }
}
