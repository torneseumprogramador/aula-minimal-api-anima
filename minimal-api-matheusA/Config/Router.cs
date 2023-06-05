using Minimal.Resources;

namespace Minimal.Config;

public class Router{

    private AlunoResource _aluno;
    private NotaAlunoResource _notaAluno;
    private AtividadeResource _atividade;
    public Router(AlunoResource aluno, NotaAlunoResource notaAluno, AtividadeResource atividade)
    {
        _aluno = aluno;
        _notaAluno = notaAluno;
        _atividade = atividade;
    }

    public void Register(WebApplication app){
        #region aluno
        app.MapGet("/Alunos", _aluno.GetAll).WithName("AlunoGetAll").WithOpenApi();
        app.MapGet("/Alunos/{id}", _aluno.Get).WithName("AlunoGet").WithOpenApi();
        app.MapPost("/Alunos", _aluno.Save).WithName("AlunoPost").WithOpenApi();
        app.MapPut("/Alunos/{id}", _aluno.Update).WithName("AlunoUpdate").WithOpenApi();
        #endregion
        #region atividade
        app.MapGet("/Atividades", _atividade.GetAll).WithName("AtividadeGetAll").WithOpenApi();
        app.MapGet("/Atividades/{id}", _atividade.Get).WithName("AtividadeGet").WithOpenApi();
        app.MapPost("/Atividades", _atividade.Save).WithName("AtividadePost").WithOpenApi();
        app.MapPut("/Atividades/{id}", _atividade.Update).WithName("AtividadeUpdate").WithOpenApi();
        #endregion
        #region nota
        app.MapGet("/NotaAlunos", _notaAluno.GetAll).WithName("NotaAlunoGetAll").WithOpenApi();
        app.MapGet("/NotaAlunos/{id}", _notaAluno.Get).WithName("NotaAlunoGet").WithOpenApi();
        app.MapGet("/NotaAlunos/Media/{id}", _notaAluno.Media).WithName("MediaAlunoGet").WithOpenApi();
        app.MapPost("/NotaAlunos", _notaAluno.Save).WithName("NotaAlunoPost").WithOpenApi();
        app.MapPut("/NotaAlunos/{id}", _notaAluno.Update).WithName("NotaAlunoUpdate").WithOpenApi();
        #endregion
    }
}