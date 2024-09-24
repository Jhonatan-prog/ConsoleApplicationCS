namespace app.Models.Diagram1 
{
    public class Empresa {
        private string Codigo { get; set;}
        private string Nombre { get; set;}

        public Empresa(string codigo, string nombre) {
          Codigo = codigo;
          Nombre = nombre;
        }

        public void borrar() {}
        public void consultar() {}
        public void guardar() {}
        public void modificar() {}
    }
}
