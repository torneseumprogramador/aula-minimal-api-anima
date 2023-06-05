namespace Minimal.Models;

public class NotaAluno{

    public int NotaAlunoId {get;set;}
    public int AlunoId {get;set;}
    public int AtividadeId {get;set;}
    public int Nota {get;set;}
    public virtual Aluno Aluno { get; set; }
    public virtual Atividade Atividade {get;set;}
}