using projects.Models;

namespace projects.Controllers {
    public class ControlCliente {
        public void AgregarCliente(Persona client) { }

        public List<Cliente> ListarClientes() {
            Cliente seller = new Cliente();
            List<Cliente> Query = [seller];

            return Query;
        }
    }
}
