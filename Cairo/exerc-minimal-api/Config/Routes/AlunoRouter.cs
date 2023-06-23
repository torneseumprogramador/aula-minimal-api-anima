namespace Exercicio.Config.Router;

public class AlunoRouter
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/alunos", AlunoResource.GetAll).WithName("BuscarAlunos").WithOpenApi();
        app.MapGet("/aluno/{id}", AlunoResource.GetId).WithName("BuscarAlunoPorId").WithOpenApi();
        app.MapPost("/aluno/cadastro", AlunoResource.Post).WithName("CadastrarAluno").WithOpenApi();
        app.MapDelete("aluno/{id}/excluir", AlunoResource.DeleteId).WithName("ExcluirAluno").WithOpenApi();

    }
}
