namespace Exercicio.Models;

public class Certificado
{
    public int Id { get; set; }
    public Disciplina Disciplina { get; set; }
    public Aluno Aluno { get; set; }
}
