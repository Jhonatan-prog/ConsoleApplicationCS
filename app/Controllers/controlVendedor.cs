using app.Models;

namespace app.Controllers 
{
    public class ControlVendedor : DbRepository 
    {

        public ControlVendedor() : base() {}

        public void AgregarVendedor(Vendedor vendedor) 
        {   
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
        }

        public List<Vendedor> ListarVendedores() 
        {
            List<Vendedor> Query = _context.Vendedor.ToList();
            return Query;
        }

        public Vendedor? ObtenerVendedorPorId(long pk) 
        {
            Vendedor? vendedor = _context.Vendedor.Find(pk);
            return vendedor;
        }

        public void ActualizarVendedor(Vendedor vendedor) 
        {
          _context.Vendedor.Update(vendedor);
          _context.SaveChanges();
        }

        public int EliminarVendedor(long pk) 
        {
            var vendedor = _context.Vendedor.Find(pk);
            if (vendedor == null) return 0;

            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();

            return 1;
        }
    }
}

