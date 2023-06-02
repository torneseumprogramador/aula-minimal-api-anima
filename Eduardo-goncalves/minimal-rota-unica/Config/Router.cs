namespace Minimal.Config;

public class Router
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/BuscarListaAlunos", AlunoResource.GetListaAlunos)
        .WithName("BuscarListaAlunos")
        .WithOpenApi();

        app.MapGet("BuscarAluno", AlunoResource.GetAluno)
        .WithName("BuscarAluno")
        .WithOpenApi();

        app.MapPost("/CadastrarNotaAluno", AlunoResource.PostAluno)
        .WithName("CadastrarNotaAluno")
        .WithOpenApi();

        app.MapPut("/EditarAluno", AlunoResource.PutAluno)
        .WithName("EditarAluno")
        .WithOpenApi();

        app.MapGet("/cadastro", CadastroResource.Cadastro)
        .WithName("Cadastro")
        .WithOpenApi();
    }
}