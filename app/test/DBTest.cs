using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace app.test
{
    class Testing
    {
        public void TestDb()
        {
            try 
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
         
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("\nQuery:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();


                    string sql = "SELECT * FROM Empresa";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["codigo"]);
                                Console.WriteLine(reader["nombre"]);
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nTest -> DataBabase connection successfully finished.\n");
        }

    }
}
