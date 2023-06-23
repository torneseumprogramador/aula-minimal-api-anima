namespace Exercicio.Config.Router;

public class MatriculaRouter
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/matriculas", MatriculaResource.GetAll).WithName("BuscarMatriculas").WithOpenApi();
        app.MapGet("/matricula/{id}", MatriculaResource.GetId).WithName("BuscarMatriculaPorId").WithOpenApi();
        app.MapGet("/matriculas/{id_aluno}", MatriculaResource.GetIdAluno).WithName("BuscarMatriculasPorALuno").WithOpenApi();
        app.MapPost("matricula/cadastro", MatriculaResource.Post).WithName("CadastroMatricula").WithOpenApi();
        //app.MapDelete("matricula/{id}/excluir", MatriculaResource.DeleteId).WithName("ExcluirMatricula").WithOpenApi();

    }
}
