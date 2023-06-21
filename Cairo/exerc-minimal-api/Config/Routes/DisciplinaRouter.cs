namespace Exercicio.Config.Router;

public class DisciplinaRouter
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/disciplinas", DisciplinaResource.GetAll).WithName("BuscarDisciplinas").WithOpenApi();
        app.MapGet("/disciplina/{id}", DisciplinaResource.GetId).WithName("BuscarDisciplinaPorId").WithOpenApi();
        app.MapPost("/disciplina/cadastro", DisciplinaResource.Post).WithName("CadastrarDisciplina").WithOpenApi();
        app.MapDelete("disciplina/{id}/excluir", DisciplinaResource.DeleteId).WithName("ExcluirDisciplina").WithOpenApi();
    }
}
