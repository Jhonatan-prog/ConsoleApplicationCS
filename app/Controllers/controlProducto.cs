class controlProducto 
{
    public static void CrearProducto()
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        double precio = Convert.ToDouble(Console.ReadLine());

        // Llamada a la capa de lógica de negocio para crear el producto
        Producto producto = new Producto(nombre, precio);
        // Guardar producto en la base de datos
        ProductoDAO.GuardarProducto(producto);

        Console.WriteLine("Producto creado exitosamente!");
    }

}
