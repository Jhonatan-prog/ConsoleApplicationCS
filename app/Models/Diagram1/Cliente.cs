namespace app.Models.Diagram1 {

  public class Cliente : Persona {
    // Atributo privado
    private double credito;
    public Empresa Empresa { get; set; }
    // Propiedad pública con get y set
    public double Credito {
      get => credito;
      set => credito = value;
    }

    // Constructor sin parámetros
    public Cliente(Empresa empresa) : base() {
      Credito = 0;
      Empresa = empresa;
    }

    // Constructor sobrecargado con parámetros
    public Cliente(
      //string? codigo, 
      string email, 
      string nombre, 
      string telefono, 
      double credito,
      Empresa empresa
    ) : base(
      //codigo, 
      email, 
      nombre, 
      telefono
    ) 
    {
      this.credito = credito;
      this.Empresa = empresa;
    }

  }

}
