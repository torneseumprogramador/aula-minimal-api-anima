namespace Exercicio.Models;

public class Matricula
{
    public int Id { get; set; }
    public Aluno? Aluno { get; set; }
    public Disciplina? Disciplina { get; set; }
    public double Nota { get; set; }
    public bool Aprovado { get; set; }

}
