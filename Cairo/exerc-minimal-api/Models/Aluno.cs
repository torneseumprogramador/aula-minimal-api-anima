namespace Exercicio.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Disciplina> DisciplinasConfirmadas { get; set; }
}
