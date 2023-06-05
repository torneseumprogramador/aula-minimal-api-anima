using Microsoft.AspNetCore.Mvc;
using MinimalAPIWilliam.Controllers;
using MinimalAPIWilliam.Models;

namespace MinimalAPIWilliam.Routes;

class AlunoRoute
{
    public AlunoRoute(WebApplication _app)
    {
        this.app = _app;
    }

    private WebApplication app;

    public static List<Aluno> alunos = new List<Aluno>();

    public void Register()
    {
        app.MapGet("/aluno/", () => AlunoController.Get()).WithName("Aluno.Get").WithOpenApi();
        app.MapPost("/aluno/", (Aluno aluno) => AlunoController.Post(aluno)).WithName("Aluno.Post").WithOpenApi();
        app.MapPut("/aluno/{id}", (Guid id, Aluno aluno) => AlunoController.Put(id, aluno)).WithName("Aluno.Put").WithOpenApi();
        app.MapDelete("/aluno/{id}", (Guid id) => AlunoController.Delete(id)).WithName("Aluno.Delete").WithOpenApi();
        app.MapGet("/aluno/{id}", (Guid id) => AlunoController.GetByID(id)).WithName("Aluno.GetByID").WithOpenApi();
        app.MapGet("/aluno/matricula/{matricula}", (int matricula) => AlunoController.GetByMatricula(matricula)).WithName("Aluno.GetByMatricula").WithOpenApi();
        app.MapGet("/aluno/certificado/{matricula}", (int matricula) => AlunoController.GetCertificadoByMatricula(matricula)).WithName("Aluno.GetCertificadoByMatricula").WithOpenApi();
    }
}