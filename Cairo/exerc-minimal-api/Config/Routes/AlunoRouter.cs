namespace Exercicio.Config.Router;

public class AlunoRouter
{
    public static void Register(WebApplication app)
    {
        /// <summary>
        /// Rota que retorna todos os alunos
        /// </summary>
        /// <returns>Retorna todos os alunos cadastrados.</returns>
        app.MapGet("/alunos", AlunoResource.GetAll).WithName("BuscarAlunos").WithOpenApi();
        app.MapGet("/aluno/{id}", AlunoResource.GetId).WithName("BuscarAlunoPorId").WithOpenApi();

    }
}
