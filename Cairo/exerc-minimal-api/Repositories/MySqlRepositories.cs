using Exercicio.Models;
using Exercicio.Repositories;
using MySqlConnector;

public class MySqlRepositories
{
    public List<Aluno> BuscarAlunos()
    {
        List<Aluno>? alunos = new List<Aluno>();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * FROM ALUNO";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome")
                    };
                    alunos.Add(aluno);
                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        return alunos;
    }

    public Aluno BuscarAlunoPorId(int id)
    {
        Aluno? aluno = null;
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * " +
                            "FROM ALUNO " +
                            "WHERE ID = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    aluno = new Aluno
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome")
                    };
                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        return aluno;
    }
}
