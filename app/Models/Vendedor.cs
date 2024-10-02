namespace app.Models {
    public class Vendedor
    {
        public long Codigo { get; set; }  // BIGINT
        public int Carnet { get; set; }  // INT
        public string Direccion { get; set; }  // VARCHAR(255)

        // Navigation property
        public virtual Persona Persona { get; set; }
    }
}
