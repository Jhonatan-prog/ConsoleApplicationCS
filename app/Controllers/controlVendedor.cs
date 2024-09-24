using projects.Models;

namespace projects.Controllers {
    public class ControlVendedor {
        public void AgregarVendedor(Persona data) { }

        public List<Vendedor> ListarVendedores() {
            Vendedor seller = new Vendedor();
            List<Vendedor> Query = [seller];

            return Query;
        }
    }
}