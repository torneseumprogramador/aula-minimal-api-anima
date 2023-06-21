using web_api_min.Enums;
using web_api_min.Service;
using web_api_min.Models;
using System.Data;
using web_api_min.Service.Response;
using Npgsql;
using Microsoft.AspNetCore.Mvc;
using web_api_min.Repository;
namespace web_api_min.Routes;

class AlunosNotasRoute:BaseRepository
{
    public AlunosNotasRoute(WebApplication _app)
    {
        this.app = _app;
    }
    private WebApplication app;

    public void Register(){

        //app.MapGet("/", () => "Home");

                        app.MapGet("/Aluno", () =>
                        {

                                using (var command = new NpgsqlCommand("SELECT nome, matricula, notas, media, situacao FROM Aluno ORDER BY nome", GetConnection()))
                                {
                                    var alunos = new List<AlunoResponse>();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            AlunoResponse aluno = new AlunoResponse(
                                                reader.GetString(0),
                                                reader.GetInt32(1),
                                                reader.GetString(2),
                                                reader.GetInt32(3),
                                                reader.GetString(4)
                                            );
                                            alunos.Add(aluno);
                                        }
                                    }
                                    return alunos;
                                }
                            
                        }).WithName("GetListAlunos").WithOpenApi();

                            

        app.MapPost("/Aluno", ([FromBody] AlunoRequest aluno) =>
        {
            var media = 0;
            SituacaoAluno situacao;
            situacao = SituacaoAluno.Reprovado;

            if(aluno.Notas != null){
                media = CadastroNotasService.ObterMediaNotas(aluno.Notas);
                situacao = media < 5 ? SituacaoAluno.Reprovado : media >= 5 && media < 7 ? SituacaoAluno.Recuperacao : SituacaoAluno.Aprovado;
            }
    
                using (var command = new NpgsqlCommand("INSERT INTO Aluno (nome, matricula, notas, media, situacao) VALUES (@Nome, @Matricula, @Notas, @Media, @Situacao)", GetConnection()))
                {
                    command.Parameters.AddWithValue("Nome", aluno.Nome);
                    command.Parameters.AddWithValue("Matricula", aluno.Matricula);
                    command.Parameters.AddWithValue("Notas", aluno.Notas);
                    command.Parameters.AddWithValue("Media", media);
                    command.Parameters.AddWithValue("Situacao", situacao.ToString());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Results.Created("/Aluno", "Aluno criado com sucesso!");
                    }
                    else
                    {
                        return Results.BadRequest("Falha ao criar o aluno");
                    }
                
            }
        }).WithName("CreateAluno").WithOpenApi();

        app.MapDelete("/Aluno", (int matricula, HttpContext context) =>
        {
            using (var command = new NpgsqlCommand())
            {
                try
                {
                    command.Connection = GetConnection();
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"DELETE FROM Aluno WHERE matricula = '{matricula}'";
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        context.Response.StatusCode = 404; 
                        context.Response.WriteAsync("Aluno não encontrado"); 
                    }
                    else
                    {
                        context.Response.StatusCode = 204;
                         context.Response.WriteAsync("Exclusao feita!");  
                    }
                }
                catch (Npgsql.PostgresException e)
                {
                    context.Response.StatusCode = 500; 
                    context.Response.WriteAsync("Erro ao excluir aluno: " + e.Message); 
                }
            }
        }).WithName("DeleteAluno").WithOpenApi();

        app.MapGet("/Aluno/{matricula}",(int matricula) => 
        {
            using (var command = new NpgsqlCommand($"SELECT nome, matricula, notas, media, situacao FROM Aluno WHERE matricula = @matricula", GetConnection()))
            {
                command.Parameters.AddWithValue("matricula", matricula);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        AlunoResponse aluno = new AlunoResponse(
                            reader.GetString(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetString(4)
                        );
                        return aluno;
                    }
                }
            }

            return null;
        }).WithName("GetAluno").WithOpenApi();

        app.MapPut("/Aluno/{matricula}", (int matricula, AlunoUpDateRequest aluno) => 
        {
            using (var command = new NpgsqlCommand(CadastroNotasService.GetUpdateQuery(aluno), GetConnection()))
                {
                    command.Parameters.AddWithValue("matricula", matricula);

                    if (aluno.Nome != null)
                        command.Parameters.Add(new NpgsqlParameter("nome", aluno.Nome));
                    else
                        command.Parameters.Add(new NpgsqlParameter("nome", DBNull.Value));

                    if (aluno.Notas != null)
                        command.Parameters.Add(new NpgsqlParameter("notas", aluno.Notas));
                    else
                        command.Parameters.Add(new NpgsqlParameter("notas", DBNull.Value));

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return Results.Ok();
                    }
                    else
                    {
                        return Results.NotFound();
                    }
                }
        }).WithName("UpdateAluno").WithOpenApi();

        app.MapPost("/Aluno/GerarPDF", (int matricula) =>
{
    using (var command = new NpgsqlCommand($"SELECT nome, matricula, notas, media, situacao FROM Aluno WHERE matricula = @matricula", GetConnection()))
    {
        command.Parameters.AddWithValue("matricula", matricula);

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string situacaoString = reader.GetString(4);
                SituacaoAluno situacao;

                if (!Enum.TryParse(situacaoString, out situacao))
                {
          
                    situacao = SituacaoAluno.Desconhecido;
                }

                var aluno = new AlunoModel(
                    reader.GetString(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    situacao
                );

                GerarPdf.GerarPDFAluno(aluno);
                return Results.Ok("PDF gerado com sucesso.");
            }
        }
    }

    return Results.NotFound();
}).WithName("GerarPdfAluno").WithOpenApi();


    
}
}