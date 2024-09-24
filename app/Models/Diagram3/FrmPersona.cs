
namespace TallerEvaluativo.Diagram3.Facturas {
public class FrmPersona
{
    private string Codigo { get; set; }
    private string Email { get; set; }
    private string Nombre { get; set; }
    private string Telefono { get; set; }

    public List<FrmFactura> Facturas { get; set; } = new List<FrmFactura>();  // Optional association with invoices

    public FrmPersona(string codigo, string email, string nombre, string telefono) {
      Codigo = codigo;
      Email = email;
      Nombre = nombre;
      Telefono = telefono;
    }

    public virtual void Borrar()
    {
        // Logic for deleting a person
    }

    public virtual void Consultar()
    {
        // Logic for consulting person details
    }

    public virtual void Ingresar()
    {
        // Logic for adding a new person
    }

    public virtual void Modificar()
    {
        // Logic for modifying person details
    }

    public virtual void Verificar()
    {
        // Logic for verifying the person
    }
  }
}
