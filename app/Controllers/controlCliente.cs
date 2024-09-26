using app.Models.Diagram1;

namespace app.Controllers 
{
    public class ControlCliente : DbRepository 
    {

        public ControlCliente() : base() {}

        public void AgregarCliente(Cliente cliente) 
        {   
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> ListarClientes() 
        {
            List<Cliente> Query = _context.Cliente.ToList();
            return Query;
        }

        public Cliente? ObtenerClientePorId(int pk) 
        {
            Cliente? cliente = _context.Cliente.Find(pk);
            return cliente;
        }

        public void ActualizarCliente(Cliente cliente) 
        {
          _context.Cliente.Update(cliente);
          _context.SaveChanges();
        }

        public int EliminarCliente(int pk) 
        {
            var cliente = _context.Cliente.Find(pk);
            if (cliente == null) return 0;

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return 1;
        }
    }
}
