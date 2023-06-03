namespace Minimal.Config;

public class Router
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/buscarlistaAlunos", AlunoResource.GetListaAlunos)
        .WithName("BuscarListaAlunos")
        .WithOpenApi();

        app.MapGet("buscarAluno", AlunoResource.GetAluno)
        .WithName("BuscarAluno")
        .WithOpenApi();

        app.MapPost("/cadastrarAluno", AlunoResource.PostAluno)
        .WithName("CadastrarAluno")
        .WithOpenApi();

        app.MapPut("/editarAluno", AlunoResource.PutAluno)
        .WithName("EditarAluno")
        .WithOpenApi();

        app.MapGet("/deletarAluno", AlunoResource.DeleteAluno)
        .WithName("DeletarAluno")
        .WithOpenApi();
    }
}