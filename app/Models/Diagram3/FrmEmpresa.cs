namespace TallerEvaluativo.Diagram3.Facturas {
    public class FrmEmpresa {
        private string Codigo { get; set;}
        private string Nombre { get; set;}

        public FrmEmpresa(string codigo, string nombre) {
          Codigo = codigo;
          Nombre = nombre;
        }

        public void borrar() {}
        public void consultar() {}
        public void guardar() {}
        public void modificar() {}
    }
}
