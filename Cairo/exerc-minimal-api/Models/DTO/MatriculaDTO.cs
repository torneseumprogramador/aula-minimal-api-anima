namespace Exercicio.Models.DTO;

public struct MatriculaDTO
{
    public Aluno? Aluno { get; set; }
    public Disciplina? Disciplina { get; set; }
    public double Nota { get; set; }
    public bool Aprovado { get; set; }

}
