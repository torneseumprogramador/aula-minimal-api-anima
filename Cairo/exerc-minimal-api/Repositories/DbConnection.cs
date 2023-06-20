namespace Exercicio.Repositories;
using MySqlConnector;

public class DbConnection
{
    private string connectionString;
    public DbConnection()
    {
        connectionString = "server=localhost;database=minimal_api;uid=root;password=654321";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

}
