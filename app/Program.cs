using app.Models.Diagram1;
using app.Controllers;

class Program
{
    static void Main(string[] args)
    {   
        ControlCliente controlCliente = new();
        ControlPersona controlPersona = new();

        Console.WriteLine("Instrucciones de uso:");
        Console.WriteLine("1. Ingrese la funcionalidad que desea (agregar - 1, listar - 2, obtener - 3, actualizar - 4 o eliminar - 5)");
        Console.WriteLine("2. Escribir el nombre de la tabla");
        Console.WriteLine("3. Ingrese la información pedida despues de ingresar el nombre de la tabla.");
        Console.WriteLine("4. Para salir escriba la palabra 'exit'.\n");
        Console.WriteLine("===============================================================================================================");
        while (true) 
        {   
            Console.Write("Funcionalidad: ");
            var funcionalidad = Console.ReadLine();
            Console.Write("Nombre de la tabla: ");
            var nombreTabla = Console.ReadLine();

            if (funcionalidad == null || nombreTabla == null) 
            {   
                Console.Write("\nLos datos esperados no fueron ingresados.");
                continue;
            }

            if (nombreTabla?.ToLower().Trim() == "cliente") 
            {
                switch (Convert.ToInt32(funcionalidad))
                {   
                    case 1:
                        Console.Write("Codigo (PK): ");
                        var codigo = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        var telefono = Console.ReadLine();
                        Console.Write("Credito: ");
                        var credito = Console.ReadLine();

                        Persona nuevaPersona = new Persona(codigo, email, nombre, telefono);
                        Cliente nuevoCliente = new Cliente(Convert.ToDouble(credito));
                        controlPersona.AgregarPersona(nuevaPersona); 
                        controlCliente.AgregarCliente(nuevoCliente);
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
                        Console.Write("Codigo: ");
                        var newCodigo = Console.ReadLine();
                        Console.Write("Email: ");
                        var newEmail = Console.ReadLine();
                        Console.Write("Nombre: ");
                        var newNombre = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        var newTelefono = Console.ReadLine();
                        Console.Write("Credito: ");
                        var newCredito = Console.ReadLine();

                        Cliente ClienteActualizado = new Cliente(newCodigo, newEmail, newNombre, newTelefono, Convert.ToDouble(newCredito));
                        controlCliente.ActualizarCliente(ClienteActualizado);
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
                        break;

                    default:
                        Console.WriteLine("Funcionalidad no valida.");
                        break;
                }
            }

            break;
        }
    }
}
