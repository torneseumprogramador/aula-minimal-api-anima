
using Microsoft.AspNetCore.Mvc;

public class AlunoRoute
{
    public AlunoRoute(WebApplication _app)
    {
        this.app = _app;
    }
    private List<Aluno> alunos = new List<Aluno>();
    private WebApplication app;

    public void CadastraAluno()
    {
        app.MapPost("/aluno", ([FromBody] Aluno alunoPost) =>
            {
                var id = alunos.Select(x=> x.IdAluno).LastOrDefault()+1;
                alunoPost.IdAluno = id;
                alunos.Add(alunoPost);
            })
            .WithName("Aluno")
            .WithOpenApi();
    }

    public void getAluno ()
    {
        app.MapGet("/aluno", ( int idAluno) =>
        {
            var aluno = alunos.Find(x=> x.IdAluno == idAluno);

            return aluno;
        }).WithName("Aluno/Id")
        .WithOpenApi();

    }

     public void media ()
    {
        app.MapGet("/media", ( int idAluno) =>
        {
            var media = calculaMedia(idAluno);
            return media;
        }).WithName("Media")
        .WithOpenApi();

    }

    public double calculaMedia(int idAluno){
        var aluno = alunos.Find(x=> x.IdAluno == idAluno);
        var media = (aluno.Nota1 + aluno.Nota2)/2;

        return media;
    }
}