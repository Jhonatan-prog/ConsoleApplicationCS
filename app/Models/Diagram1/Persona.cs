namespace app.Models.Diagram1 {

  public class Persona {
    // Atributos privados
    private string codigo;
    private string email;
    private string nombre;
    private string telefono;

    // Propiedades públicas con get y set
    public string Codigo { // Property
      get => codigo;
      set => codigo = value;
    }

    public string Email { // Property
      get => email;
      set => email = value;
    }

    public string Nombre { // Property
      get => nombre;
      set => nombre = value;
    }

    public string Telefono { // Property
      get => telefono;
      set => telefono = value;
    }

    // Constructor sin parámetros
    public Persona() {
      codigo = string.Empty;
      email = string.Empty;
      nombre = string.Empty;
      telefono = string.Empty;
    }

    // Constructor sobrecargado con parámetros
    public Persona(string codigo, string email, string nombre, string telefono) {
      this.codigo = codigo;
      this.email = email;
      this.nombre = nombre;
      this.telefono = telefono;
    }
  }
}
