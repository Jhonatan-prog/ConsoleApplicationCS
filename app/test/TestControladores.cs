// using app.Models;
// using projects.Controllers;
// 
// namespace TallerEvaluativo.Facturas {
//   public class TestControladores {
// 
//     public void RunTest() {
//         // Crear y poblar el controlador de clientes
//         var controlCliente = new ControlCliente();
//         controlCliente.AgregarCliente(new Cliente("001", "cliente1@correo.com", "Cliente Uno ", "1234567890 ", 1000.0));
//         controlCliente.AgregarCliente(new Cliente("002", "cliente2@correo.com", "ClienteDos ", "0987654321 ", 2000.0));
// 
//         // Listar y mostrar clientes
//         var clientes = controlCliente.ListarClientes(); 
//         foreach(var cliente in clientes) {
//           Console.WriteLine($"{cliente.Nombre}, {cliente.Credito}");
//         }
// 
//         // Crear y poblar el controlador de vendedores
//         var controlVendedor = new ControlVendedor(); 
//         controlVendedor.AgregarVendedor(new Vendedor("001", "vendedor1@correo.com", "Vendedor Uno", "1234567890", 1234, "Dirección 1")); 
//         controlVendedor.AgregarVendedor(new Vendedor("002", "vendedor2@correo.com", "Vendedor Dos", "0987654321", 5678, "Dirección 2"));
// 
//         // Listar y mostrar vendedores
//         var vendedores = controlVendedor.ListarVendedores(); foreach(var vendedor in vendedores) {
//           Console.WriteLine($"{vendedor.Nombre}, {vendedor.Carnet}");
//         }
//     }
//   }
// }