using System.Collections.Generic; // Make sure this is included
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Diagram1
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment in SQL Server
        public long? Codigo { get; set; }

        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        // Keep ICollection<Cliente> for navigation property
        public virtual ICollection<Cliente> Clientes { get; set; } // Collection navigation property

        // Self-referencing foreign key property
        public long? PersonaCodigo { get; set; } // Self-referencing foreign key
        [ForeignKey(nameof(PersonaCodigo))]
        public virtual Persona PersonaReferencia { get; set; } // Navigation property for self-reference

        // Constructor sin parámetros
        public Persona()
        {
            Email = string.Empty;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Clientes = new List<Cliente>(); // Initialize the collection
        }

        // Constructor sobrecargado con parámetros
        public Persona(string email, string nombre, string telefono, long? codigo = null)
        {
            this.Codigo = codigo;
            this.Email = email;
            this.Nombre = nombre;
            this.Telefono = telefono;
            Clientes = new List<Cliente>(); // Initialize the collection
        }
    }
}
