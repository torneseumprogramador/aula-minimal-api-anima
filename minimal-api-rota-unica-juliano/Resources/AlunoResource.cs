
using Microsoft.AspNetCore.Mvc;
using Minimal.Models;
using Npgsql;

class AlunoResource
{
    public static IResult Lista()
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        List<Aluno> alunos = new List<Aluno>();
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT matricula, nome, grau_a, grau_b FROM alunos ORDER BY matricula";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    Aluno aluno = new Aluno
                    {
                        Matricula = (int)reader["matricula"],
                        Nome = reader["Nome"].ToString(),
                        GrauA = (float)reader["grau_a"],
                        GrauB = (float)reader["grau_b"]
                    };
                    alunos.Add(aluno);
                }

            }
            connection.Close();
        }

        if (alunos.Count > 0) {
            return Results.Ok(alunos);
        }
        else
        {
            return Results.NoContent();
        }
    }

    public static IResult Get([FromRoute] int id)
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        List<Aluno> alunos = new List<Aluno>();
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT matricula, nome, grau_a, grau_b FROM alunos WHERE matricula = @matricula ORDER BY matricula";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@matricula", id);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    Aluno aluno = new Aluno
                    {
                        Matricula = (int)reader["matricula"],
                        Nome = reader["Nome"].ToString(),
                        GrauA = (float)reader["grau_a"],
                        GrauB = (float)reader["grau_b"]
                    };
                    alunos.Add(aluno);
                }

            }
            connection.Close();
        }

        if (alunos.Count > 0) {
            return Results.Ok(alunos);
        }
        else
        {
            return Results.NoContent();
        }
    }
    
    public static IResult Cadastro([FromBody] Aluno dadoRequestPost) 
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO alunos (nome, grau_a, grau_b) VALUES (@nome, @grau_a, @grau_b) RETURNING matricula;";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@nome", dadoRequestPost.Nome);
            command.Parameters.AddWithValue("@grau_a", (float)dadoRequestPost.GrauA);
            command.Parameters.AddWithValue("@grau_b", (float)dadoRequestPost.GrauB);
            NpgsqlDataReader reader = command.ExecuteReader();

            int rowsAffected = 0;
            //int rId = 0;
            List<Aluno> alunos = new List<Aluno>();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    rowsAffected++;
                    Aluno aluno = new Aluno
                    {
                        Matricula = (int)reader["matricula"],
                        Nome = dadoRequestPost.Nome,
                        GrauA = (float)dadoRequestPost.GrauA,
                        GrauB = (float)dadoRequestPost.GrauB
                    };
                    alunos.Add(aluno);
                }
            }

            connection.Close();

            if (rowsAffected > 0)
            {
                return Results.Created($"/alunos", alunos);
            }
            else
            {
                return Results.Problem("Falha ao inserir o aluno.");
            }
        }
    }

    public static IResult Atualiza([FromRoute] int id, [FromBody] Aluno dadoRequestPost) 
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE alunos SET nome = @nome, grau_a = @grau_a, grau_b = @grau_b WHERE matricula = @matricula;";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@matricula", id);
            command.Parameters.AddWithValue("@nome", dadoRequestPost.Nome);
            command.Parameters.AddWithValue("@grau_a", (float)dadoRequestPost.GrauA);
            command.Parameters.AddWithValue("@grau_b", (float)dadoRequestPost.GrauB);
            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            if (rowsAffected > 0)
            {
                return Results.Ok("Atualizado com sucesso!");
            }
            else
            {
                return Results.Problem("Falha ao atualizar o aluno.");
            }
        }
    }

    public static IResult Apaga([FromRoute] int id) 
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM alunos WHERE matricula = @matricula;";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@matricula", id);
            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            if (rowsAffected > 0)
            {
                return Results.Ok("Removido com sucesso!");
            }
            else
            {
                return Results.Problem("Falha ao remover o aluno.");
            }
        }
    }
    
    public static IResult CalculaMedia([FromRoute] int id) 
    {
        string connectionString = "Server=mahmud.db.elephantsql.com;Database=wklmmski;User Id=wklmmski;Password=DlDzB7jLPnuqAVSJmqmwOW1dh0TCAEA2;";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT matricula, nome, grau_a, grau_b FROM alunos WHERE matricula = @matricula ORDER BY matricula";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@matricula", id);
            NpgsqlDataReader reader = command.ExecuteReader();
            float media = -1;
            while (reader.Read())
            {
                media = ((float)reader["grau_a"] + (float)reader["grau_b"]) / 2;
            }
            connection.Close();
            if(media == -1) {
                return Results.NoContent();
            }else {
                string? status = null;
                if(media >= 6) {
                    status = "Aprovado";
                }else {
                    status = "Reprovado";
                }
                List<object> dados = new List<object>();
                object dado =  new 
                {
                    Media = media,
                    Status = status
                };
                dados.Add(dado);
                return Results.Ok(dados);
            }            
        }
    }
}