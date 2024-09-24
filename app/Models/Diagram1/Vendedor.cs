namespace app.Models.Diagram1 {

  public class Vendedor : Persona {

    // Atributos privados
    private int carnet;
    private string direccion;

    // Propiedades públicas con get y set
    public int Carnet {
      get => carnet;
      set => carnet = value;
    }

    public string Direccion {
      get => direccion;
      set => direccion = value;
    }

    // Constructor sin parámetros
    public Vendedor() : base() {
      carnet = 0;
      direccion = string.Empty;
    }

    // Constructor sobrecargado con parámetros
    public Vendedor(
      string codigo, 
      string email, 
      string nombre, 
      string telefono, 
      int carnet,
      string direccion
      ) : base(
        codigo, 
        email, 
        nombre, 
        telefono
      ) 
    {
      this.carnet = carnet;
      this.direccion = direccion;
    }
  }
}