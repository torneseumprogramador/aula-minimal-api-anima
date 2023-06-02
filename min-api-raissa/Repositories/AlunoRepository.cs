using min_api_raissa.Models;

namespace min_api_raissa.Repositories;

public class AlunoRepository
{
    private readonly List<Aluno> alunos;

    public AlunoRepository()
    {
        alunos = new List<Aluno>();
    }


    public List<Aluno> Todos()
    {
        return alunos;
    }

    public Aluno? AlunoPorId(int id)
    {
        return alunos?.FirstOrDefault(a => a.Id == id);
    }


    public void CriarAluno(Aluno aluno)
    {

        aluno.Id = alunos.Count + 1;
        alunos.Add(aluno);
    }


    public void AtualizarAluno(Aluno aluno, int id)
    {
        var existeAluno = alunos.FirstOrDefault(a => a.Id == id);
        if (existeAluno != null)
        {
            existeAluno.Nome = aluno.Nome;
            existeAluno.Notas = aluno.Notas;
        }
    }
    public void DeletarAluno(int id)
    {

        var existeAluno = alunos.FirstOrDefault(a => a.Id == id);
        if (existeAluno != null)
        {
            alunos.Remove(existeAluno);

        }

    }
}
