namespace app.Models.Diagram3 {
  public class FrmCliente : FrmPersona
  {
    private double Credito { get; set; }
    public FrmEmpresa? Empresa { get; set; }

    public FrmCliente(string codigo, string email, string nombre, string telefono, double credito, FrmEmpresa? empresa = null) 
        : base(codigo, email, nombre, telefono)
    {
        Credito = credito;
        Empresa = empresa;
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