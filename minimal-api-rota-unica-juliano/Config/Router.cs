namespace Minimal.Config;

public class Router
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/", HomeResource.Index).WithName("Home").WithOpenApi();

        app.MapGet("/alunos/{id}", AlunoResource.Get).WithName("RetornaAluno").WithOpenApi();
        app.MapGet("/alunos", AlunoResource.Lista).WithName("ListaAlunos").WithOpenApi();
        app.MapPost("/alunos", AlunoResource.Cadastro).WithName("CadastroAlunos").WithOpenApi();
        app.MapPut("/alunos/{id}", AlunoResource.Atualiza).WithName("AtualizaAlunos").WithOpenApi();
        app.MapDelete("/alunos/{id}", AlunoResource.Apaga).WithName("ApagaAlunos").WithOpenApi();
        app.MapGet("/medias/{id}", AlunoResource.CalculaMedia).WithName("MediaAluno").WithOpenApi();
    }
}
