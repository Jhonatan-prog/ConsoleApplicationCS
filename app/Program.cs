using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ConsoleApplicationDB;Trusted_Connection=True;Encrypt=False;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Open the connection
                connection.Open();
                Console.WriteLine("Connection opened successfully.");

                string query = "SELECT * FROM Cliente";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {   
                            Console.WriteLine(reader["codigo"]);
                            Console.WriteLine(reader["credito"]);
                            Console.WriteLine(reader["codigo_empresa"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Closed connection
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
