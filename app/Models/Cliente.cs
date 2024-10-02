// system
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models 
{
    public class Cliente : Persona
    {
        public long Codigo { get; set; }  // BIGINT
        public float Credito { get; set; }  // FLOAT
        public long? CodigoEmpresa { get; set; }  // BIGINT

        // Navigation properties
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
