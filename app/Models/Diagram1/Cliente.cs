namespace projects.Models {

  public class Cliente : Persona {
    // Atributo privado
    private double credito;
    // Propiedad pública con get y set
    public double Credito {
      get => credito;
      set => credito = value;
    }

    // Constructor sin parámetros
    public Cliente(): base() { // Constructor de la clase persona is invoked when we call the Client class
      credito = 0.0;
    }

    // Constructor sobrecargado con parámetros
    public Cliente(
        string codigo, 
        string email, 
        string nombre, 
        string telefono, 
        double credito
    ) : base(
        codigo, 
        email, 
        nombre, 
        telefono
    ) 
    {
      this.credito = credito;
    }

  }

}
