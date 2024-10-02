using System.Collections.Generic; // Make sure this is included
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models
{
    public class Persona
    {
        public long Codigo { get; set; }  // BIGINT
        public string Email { get; set; }  // VARCHAR(255)
        public string Nombre { get; set; }  // VARCHAR(255)
        public string Telefono { get; set; }  // VARCHAR(255)

        // Navigation properties
        public virtual Vendedor Vendedor { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
