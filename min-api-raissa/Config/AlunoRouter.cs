
using Microsoft.AspNetCore.Mvc;
using min_api_raissa.Models;
using min_api_raissa.Services;
namespace min_api_raissa.Config;

public class AlunoRouter
{
    private readonly static AlunoService _alunoService = new AlunoService();

    public AlunoRouter()
    {
        // _alunoService = new AlunoService();
    }
    //TODO: depois que eu fizer injeção
    // public Router(AlunoService alunoService)
    // {
    //     _alunoService = alunoService;
    // }

    public static void Register(WebApplication app)
    {
        app.MapGet("/alunos", _alunoService.ListarTodos).WithName("ListarTodosAlunos").WithOpenApi();

        app.MapGet("/alunos/{id}", _alunoService.AlunoPorId).WithName("ObterAlunoPorId").WithOpenApi();

        app.MapPost("/alunos", _alunoService.CriarAluno).WithName("CadastrarAluno").WithOpenApi();


        app.MapPut("/alunos/{id}", ([FromBody] Aluno aluno, [FromRoute] int id) =>
        {
            _alunoService.AtualizarAluno(aluno, id);
        })
        .WithName("AtualizarAluno")
        .WithOpenApi();


        app.MapDelete("/alunos/{id}", _alunoService.DeletarAluno).WithName("DeletarAluno").WithOpenApi();


    }
}