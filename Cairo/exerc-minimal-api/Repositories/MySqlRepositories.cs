using Exercicio.Models;
using Exercicio.Models.DTO;
using Exercicio.Repositories;
using MySqlConnector;

public class MySqlRepositories
{
    #region Aluno
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
            throw;
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
            throw;
        }
        finally
        {
            connection.Clone();
        }
        if (aluno == null)
            throw new NullReferenceException("Aluno não encontrado. ");
        return aluno;
    }

    public bool CadastrarAluno(AlunoDTO alunoRequestPost)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "INSERT INTO ALUNO (NOME) VALUES (@nome)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nome", alunoRequestPost.Nome);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }

    public bool ExcluirAlunoPorId(int id)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "DELETE FROM ALUNO WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }
    #endregion

    #region Disciplina
    public List<Disciplina> BuscarDisciplinas()
    {
        List<Disciplina>? disciplinas = new List<Disciplina>();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * FROM DISCIPLINA";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Disciplina disciplina = new Disciplina
                    {
                        Id = reader.GetInt32("Id"),
                        NomeDisciplina = reader.GetString("NOME_DISCIPLINA")
                    };
                    disciplinas.Add(disciplina);
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
        return disciplinas;
    }
    public Disciplina BuscarDisciplinaPorId(int id)
    {
        Disciplina? disciplina = null;
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * " +
                            "FROM DISCIPLINA " +
                            "WHERE ID = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    disciplina = new Disciplina
                    {
                        Id = reader.GetInt32("Id"),
                        NomeDisciplina = reader.GetString("NOME_DISCIPLINA")
                    };
                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
            throw;
        }
        finally
        {
            connection.Clone();
        }
        if (disciplina == null)
            throw new NullReferenceException("Aluno não encontrado. ");
        return disciplina;
    }

    public bool CadastrarDisciplina(DisciplinaDTO disciplinaRequestPost)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "INSERT INTO DISCIPLINA (NOME_DISCIPLINA) VALUES (@nomeDisciplina)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nomeDisciplina", disciplinaRequestPost.NomeDisciplina);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }
    public bool ExcluirDisciplinaPorId(int id)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "DELETE FROM DISCIPLINA WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }
    #endregion

    #region Matricula
    public List<Matricula> BuscarMatriculas()
    {
        List<Matricula>? matriculas = new List<Matricula>();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * FROM MATRICULA";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Id = reader.GetInt32("ID_ALUNO"),
                        Nome = reader.GetString("NOME_ALUNO")
                    };
                    Disciplina disciplina = new Disciplina
                    {
                        Id = reader.GetInt32("ID_DISCIPLINA"),
                        NomeDisciplina = reader.GetString("NOME_DISCIPLINA")
                    };
                    Matricula matricula = new Matricula
                    {
                        Id = reader.GetInt32("Id"),
                        Nota = reader.GetDouble("NOTA"),
                        Aprovado = reader.GetBoolean("APROVADO"),
                        Aluno = aluno,
                        Disciplina = disciplina
                    };
                    matriculas.Add(matricula);
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
        return matriculas;
    }

    public Matricula BuscarMatriculaPorId(int id)
    {
        Matricula matricula = new Matricula();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * " +
                            "FROM MATRICULA " +
                            "WHERE ID = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Id = reader.GetInt32("ID_ALUNO"),
                        Nome = reader.GetString("NOME_ALUNO")
                    };
                    Disciplina disciplina = new Disciplina
                    {
                        Id = reader.GetInt32("ID_DISCIPLINA"),
                        NomeDisciplina = reader.GetString("NOME_DISCIPLINA")
                    };
                    matricula.Id = reader.GetInt32("Id");
                    matricula.Nota = reader.GetDouble("NOTA");
                    matricula.Aprovado = reader.GetBoolean("APROVADO");
                    matricula.Aluno = aluno;
                    matricula.Disciplina = disciplina;
                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
            throw;
        }
        finally
        {
            connection.Clone();
        }
        if (matricula == null)
            throw new NullReferenceException("Matricula não encontrada. ");
        return matricula;
    }

    public List<Matricula> BuscarMatriculasPorIdAluno(int idAluno)
    {
        List<Matricula>? matriculas = new List<Matricula>();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * " +
                            "FROM MATRICULA " +
                            "WHERE ID_ALUNO = @idAluno";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@idAluno", idAluno);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Id = reader.GetInt32("ID_ALUNO"),
                        Nome = reader.GetString("NOME_ALUNO")
                    };
                    Disciplina disciplina = new Disciplina
                    {
                        Id = reader.GetInt32("ID_DISCIPLINA"),
                        NomeDisciplina = reader.GetString("NOME_DISCIPLINA")
                    };
                    Matricula matricula = new Matricula
                    {
                        Id = reader.GetInt32("Id"),
                        Nota = reader.GetDouble("NOTA"),
                        Aprovado = reader.GetBoolean("APROVADO"),
                        Aluno = aluno,
                        Disciplina = disciplina
                    };
                    matriculas.Add(matricula);

                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
            throw;
        }
        finally
        {
            connection.Clone();
        }
        if (matriculas.Count == 0)
        {
            throw new NullReferenceException("Nenhuma matrícula encontrada para o aluno. ");
        }
        return matriculas;
    }

    public bool CadastrarMatricula(MatriculaDTO matriculaDtoRequest)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "INSERT INTO MATRICULA " +
                            "(ID_ALUNO, NOME_ALUNO, ID_DISCIPLINA, NOME_DISCIPLINA, NOTA, APROVADO) " +
                            " VALUES (@id_aluno, @nome_aluno, @id_disciplina, @nome_disciplina, @nota, @aprovado)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_aluno", matriculaDtoRequest.Aluno?.Id);
            command.Parameters.AddWithValue("@nome_aluno", matriculaDtoRequest.Aluno?.Nome);
            command.Parameters.AddWithValue("@id_disciplina", matriculaDtoRequest.Disciplina?.Id);
            command.Parameters.AddWithValue("@nome_disciplina", matriculaDtoRequest.Disciplina?.NomeDisciplina);
            command.Parameters.AddWithValue("@nota", matriculaDtoRequest.Nota);
            command.Parameters.AddWithValue("@aprovado", matriculaDtoRequest.Aprovado);


            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }

    #endregion

    #region Certificado
    public List<Certificado> BuscarCertificados()
    {
        List<Certificado>? certificados = new List<Certificado>();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * FROM CERTIFICADO";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Certificado certificado = new Certificado
                    {
                        Id = reader.GetInt32("ID"),
                        Matricula = BuscarMatriculaPorId(reader.GetInt32("ID_MATRICULA"))
                    };
                    certificados.Add(certificado);
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
        return certificados;
    }

    public Certificado BuscarCertificadoPorId(int id)
    {
        Certificado certificado = new Certificado();
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "SELECT * " +
                            "FROM CERTIFICADO " +
                            "WHERE ID = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    certificado.Id = reader.GetInt32("ID");
                    certificado.Matricula = BuscarMatriculaPorId(reader.GetInt32("ID_MATRICULA"));
                }
            }
        }
        catch (MySqlException ex)
        {
            //Lidar com exceções do MySQL
            Console.WriteLine("Erro do MySQL: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            //Lidar com outras exceções
            Console.WriteLine("Erro ao executar: " + ex.Message);
            throw;
        }
        finally
        {
            connection.Clone();
        }
        if (certificado == null)
            throw new NullReferenceException("Certificado não encontrado. ");
        return certificado;
    }

    public bool CadastrarCertificado(CertificadoDTO certificadoDtoRequest)
    {
        DbConnection dbConnection = new DbConnection();
        MySqlConnection connection = dbConnection.GetConnection();

        try
        {
            //Abre a conexão com o banco de dados
            connection.Open();

            //Faça operações no banco de dados
            string query = "INSERT INTO CERTIFICADO " +
                            "(ID_MATRICULA, NOME_ALUNO, NOME_DISCIPLINA, NOTA) " +
                            " VALUES (@id_matricula, @nome_aluno, @nome_disciplina, @nota)";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id_matricula", certificadoDtoRequest.matricula?.Id);
            command.Parameters.AddWithValue("@nome_aluno", certificadoDtoRequest.matricula?.Aluno?.Nome);
            command.Parameters.AddWithValue("@nome_disciplina", certificadoDtoRequest.matricula?.Disciplina?.NomeDisciplina);
            command.Parameters.AddWithValue("@nota", certificadoDtoRequest.matricula?.Nota);
            command.Parameters.AddWithValue("@aprovado", certificadoDtoRequest.matricula?.Aprovado);


            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Erro do MySql:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao executar: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return false;
    }
    #endregion

}

