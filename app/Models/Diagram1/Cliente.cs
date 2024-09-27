// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models.Diagram1 
{
    public class Cliente 
    {
        [Key]
        [ForeignKey("Persona")]
        public long? PersonaId { get; set; } // Clave primaria y foránea para Persona

        public float? Credito { get; set; } // Propiedad opcional

        // Relación con Persona (uno a uno)
        public virtual Persona Persona { get; set; }

        // Relación con Empresa (muchos a uno)
        public long EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        // Relación con Facturas (uno a muchos)
        public virtual ICollection<Factura> Facturas { get; set; }

        // Constructor sin parámetros
        public Cliente()
        {
            Credito = null;
            Facturas = new HashSet<Factura>();
        }

        // Constructor que recibe solo Empresa
        public Cliente(Empresa empresa) : this()
        {
            Empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));
        }

        // Constructor sobrecargado con parámetros
        public Cliente(float? credito, Empresa empresa) : this(empresa)
        {
            Credito = credito;
        }
    }
}
