using MySqlConnector;

class Program
{
    private static readonly string connectionString = "Server=localhost;Database=TicketSystem;User=root;Password=;";

    static void Main()
    {
        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection to MySQL database successful!");

                CreateTicketsTable(connection);

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            // Optionally, log the error to a file or centralized logging system.
        }
    }

    static void CreateTicketsTable(MySqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Tickets (
                Id INT AUTO_INCREMENT PRIMARY KEY
            )";

        using (var createTableCommand = new MySqlCommand(createTableQuery, connection))
        {
            createTableCommand.ExecuteNonQuery();
        }
    }
}
