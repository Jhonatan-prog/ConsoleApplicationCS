namespace app.Models.Diagram1 {

  public class Vendedor : Persona {
    // Propiedades públicas con auto-properties
    public int Carnet { get; set; }
    public string Direccion { get; set; }

    // Relación con Persona (herencia)
    public virtual Persona Persona { get; set; }

    public Vendedor() : base() {
      Carnet = 0;
      Direccion = string.Empty;
    }

    // Constructor sobrecargado con parámetros
    public Vendedor(int carnet, string direccion, string email, string nombre, string telefono, long? codigo = null)
      : base(email, nombre, telefono, codigo)
    {
      this.Carnet = carnet;
      this.Direccion = direccion;
    }
  }
}
