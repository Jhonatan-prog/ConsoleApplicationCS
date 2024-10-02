using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using app.Models;
using app.test;
// using app.Controllers;
using app.Data;

class Program
{
    static void Main(string[] args)
    {
        string rootDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

        // Build configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(rootDirectory)
            .AddJsonFile("appsettings.json");

        IConfiguration configuration = builder.Build();

        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection string is null or empty.");
            return;
        }

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using var dbContext = new AppDbContext();
        Testing test = new Testing();
        test.TestDb();

        Console.WriteLine("Programa de consola.");
        Console.WriteLine("Instrucciones de uso:");
        Console.WriteLine("1. Escribir el nombre de la tabla");
        Console.WriteLine("2. Ingrese la funcionalidad que desea (agregar - 1, listar - 2, obtener - 3, actualizar - 4 o eliminar - 5)");
        Console.WriteLine("3. Ingrese la información pedida después de ingresar el nombre de la tabla.");
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
                    case 1: // Agregar
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

                        // Create and save the new Persona and Cliente
                        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(telefono))
                        {
                            var nuevaPersona = new Persona { Email = email, Nombre = nombre, Telefono = telefono };
                            dbContext.Persona.Add(nuevaPersona);
                            dbContext.SaveChanges();

                            var nuevoCliente = new Cliente { Codigo = nuevaPersona.Codigo, Credito = float.Parse(credito), CodigoEmpresa = codigoEmpresa };
                            dbContext.Cliente.Add(nuevoCliente);
                            dbContext.SaveChanges();

                            Console.WriteLine("Cliente agregado exitosamente.");
                        }
                        else
                        {
                            Console.Write("Los campos no pueden estar vacíos.");
                        }
                        break;

                    case 2: // Listar
                        var clientes = dbContext.Cliente.Include(c => c.Cliente).ToList();
                        foreach (var client in clientes)
                        {
                            Console.WriteLine($"Cliente: {client.Cliente.Nombre}, Email: {client.Cliente.Email}, Credito: {client.Credito}");
                        }
                        break;

                    case 3: // Obtener
                        Console.Write("Ingrese identificador: ");
                        var PK = Convert.ToInt64(Console.ReadLine());

                        var cliente = dbContext.Cliente.Include(c => c.Cliente).FirstOrDefault(c => c.Codigo == PK);
                        if (cliente == null)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine($"Cliente: {cliente.Cliente.Nombre}, Email: {cliente.Cliente.Email}, Credito: {cliente.Credito}");
                        }
                        break;

                    case 4: // Actualizar
                        Console.Write("Ingrese identificador: ");
                        var idToUpdate = Convert.ToInt64(Console.ReadLine());
                        var clienteToUpdate = dbContext.Cliente.Include(c => c.Cliente).FirstOrDefault(c => c.Codigo == idToUpdate);

                        if (clienteToUpdate == null)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }

                        Console.Write("Nuevo Email: ");
                        clienteToUpdate.Cliente.Email = Console.ReadLine();
                        Console.Write("Nuevo Nombre: ");
                        clienteToUpdate.Cliente.Nombre = Console.ReadLine();
                        Console.Write("Nuevo Teléfono: ");
                        clienteToUpdate.Cliente.Telefono = Console.ReadLine();
                        Console.Write("Nuevo Crédito: ");
                        clienteToUpdate.Credito = float.Parse(Console.ReadLine());

                        dbContext.SaveChanges();
                        Console.WriteLine("Cliente actualizado exitosamente.");
                        break;

                    case 5: // Eliminar
                        Console.Write("Ingrese identificador: ");
                        var idToDelete = Convert.ToInt64(Console.ReadLine());

                        var clienteToDelete = dbContext.Cliente.Find(idToDelete);
                        if (clienteToDelete == null)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }

                        dbContext.Cliente.Remove(clienteToDelete);
                        dbContext.SaveChanges();
                        Console.WriteLine("Cliente eliminado con éxito.");
                        break;

                    default:
                        Console.WriteLine("Funcionalidad no válida.");
                        break;
                }
            }
            else if (nombreTabla == "vendedor")
            {
                // Similar logic can be implemented for 'vendedor' operations
            }

            break; // Add this break if you want to exit after the first iteration
        }
    }
}
