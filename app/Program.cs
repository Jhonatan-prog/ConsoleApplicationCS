using System;
using app.Data;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            // Crear la base de datos si no existe
            context.Database.EnsureCreated();

            // Crear un nuevo producto
            // var nuevoProducto = new Producto { Nombre = "Laptop", Precio = 999.99 };
            // context.Productos.Add(nuevoProducto);
            context.SaveChanges();
            
            // Consultar productos
            // var productos = context.Productos.ToList();
            // foreach (var producto in productos)
            // {
            //     Console.WriteLine($"Producto: {producto.Nombre}, Precio: {producto.Precio}");
            // }
        }
    }
}
