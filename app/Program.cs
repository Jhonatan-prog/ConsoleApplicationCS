using app.Models.Diagram1;
using app.Controllers;
using app.test;

class Program
{
    static void Main(string[] args)
    {      
        Testing test = new Testing();
        test.TestDb();

        Empresa empresa = new Empresa();
        ControlCliente controlCliente = new();
        ControlPersona controlPersona = new();

        Console.WriteLine("Programa de consola.");
        Console.WriteLine("Instrucciones de uso:");
        Console.WriteLine("1. Escribir el nombre de la tabla");
        Console.WriteLine("2. Ingrese la funcionalidad que desea (agregar - 1, listar - 2, obtener - 3, actualizar - 4 o eliminar - 5)");
        Console.WriteLine("3. Ingrese la información pedida despues de ingresar el nombre de la tabla.");
        Console.WriteLine("4. Para salir presione 'Ctrl + C'.\n");
        Console.WriteLine("===============================================================================================================");
        while (true) 
        {   
            Console.Write("Nombre de la tabla: ");
            var nombreTabla = Console.ReadLine()?.ToLower().Trim();
            Console.Write("Funcionalidad: ");
            var funcionalidad = Console.ReadLine();

            if (funcionalidad == null || nombreTabla == null) 
            {   
                Console.Write("\nLos datos esperados no fueron ingresados.");
                continue;
            }

            if (nombreTabla == "cliente") 
            {
                switch (Convert.ToInt16(funcionalidad))
                {   
                    case 1:
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        var telefono = Console.ReadLine();
                        Console.Write("Credito: ");
                        var credito = Console.ReadLine();
                        Console.Write("Empresa (número 1 - 3): ");
                        long codigoEmpresa = Convert.ToInt64(Console.ReadLine());

                        Empresa Empresa = empresa.Consultar(codigoEmpresa);

                        if (email == null || nombre == null || telefono == null) 
                        {   
                            Console.Write("Los campos no pueden estar vacíos.");
                            continue;
                        }

                        Persona nuevaPersona = new Persona(email, nombre, telefono);
                        Cliente nuevoCliente = new Cliente((float) Convert.ToDouble(credito), Empresa);
                        controlPersona.AgregarPersona(nuevaPersona); 
                        controlCliente.AgregarCliente(nuevoCliente); // UPDATE DB
                        break;
                    case 2:
                        List<Cliente> clientes = controlCliente.ListarClientes();
                        Console.WriteLine(clientes);
                        break;
                    case 3:
                        Console.Write("Ingrese identificador: ");
                        var PK = Convert.ToInt32(Console.ReadLine());

                        Cliente? cliente = controlCliente.ObtenerClientePorId(PK);
                        if (cliente == null) 
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }  

                        Console.WriteLine(cliente);
                        break;
                    case 4:
                        Console.Write("Email: ");
                        var newEmail = Console.ReadLine();
                        Console.Write("Nombre: ");
                        var newNombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        var newTelefono = Console.ReadLine();
                        Console.Write("Credito: ");
                        var newCredito = Console.ReadLine();

                        // Cliente ClienteActualizado = new Cliente(Convert.ToDouble(credito), Empresa);
                        // controlCliente.ActualizarCliente(ClienteActualizado);
                        break;
                    case 5:
                        Console.Write("Ingrese identificador: ");
                        var id = Convert.ToInt32(Console.ReadLine());

                        if (controlCliente.ObtenerClientePorId(id) == null) 
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }  

                        controlCliente.EliminarCliente(id);
                        Console.WriteLine("Cliente eliminado con exito.");
                        break;

                    default:
                        Console.WriteLine("Funcionalidad no valida.");
                        break;
                }
            } 
            else if (nombreTabla == "vendedor") 
            {

            }

            break;
        }
    }
}
