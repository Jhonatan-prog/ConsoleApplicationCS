using app.Models;

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

        public Cliente? ObtenerClientePorId(long pk) 
        {
            Cliente? cliente = _context.Cliente.Find(pk);
            return cliente;
        }

        public void ActualizarCliente(Cliente cliente) 
        {
          _context.Cliente.Update(cliente);
          _context.SaveChanges();
        }

        public int EliminarCliente(long pk) 
        {
            var cliente = _context.Persona.Find(pk);
            Console.Write(cliente);
            if (cliente == null) return 0;

            _context.Persona.Remove(cliente);
            _context.SaveChanges();

            return 1;
        }
    }
}
