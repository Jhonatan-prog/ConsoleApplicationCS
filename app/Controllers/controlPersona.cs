using app.Models.Diagram1;

namespace app.Controllers 
{
    public class ControlPersona : DbRepository 
    {

        public ControlPersona() : base() {}

        public void AgregarPersona(Persona persona) 
        {   
            _context.Persona.Add(persona);
            _context.SaveChanges();
        }

        public List<Persona> ListarPersona() 
        {
            List<Persona> Query = _context.Persona.ToList();
            return Query;
        }

        public Persona? ObtenerPersonaPorId(int pk) 
        {
            Persona? cliente = _context.Persona.Find(pk);
            return cliente;
        }

        public void ActualizarPersona(Persona persona) 
        {
          _context.Persona.Update(persona);
          _context.SaveChanges();
        }

        public int EliminarPersona(int pk) 
        {
            var persona = _context.Persona.Find(pk);
            if (persona == null) return 0;

            _context.Persona.Remove(persona);
            _context.SaveChanges();

            return 1;
        }
    }
}
