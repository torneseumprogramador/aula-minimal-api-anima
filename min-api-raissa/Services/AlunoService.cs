using min_api_raissa.Models;
using min_api_raissa.Repositories;

namespace min_api_raissa.Services;

public class AlunoService
{
    private readonly AlunoRepository _alunoRepository;

    public AlunoService()
    {
        _alunoRepository = new AlunoRepository();
    }
    //TODO: depois que eu fizer injeção
    // public AlunoService(AlunoRepository alunoRepository)
    // {
    //     _alunoRepository = alunoRepository;
    // }

    public List<Aluno> ListarTodos()
    {

        try
        {
            return _alunoRepository.Todos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro {ex.Message}");
            throw;
        }
    }

    public Aluno? AlunoPorId(int id)
    {
        try
        {
            return _alunoRepository.AlunoPorId(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro {ex.Message}");
            throw new Exception("Aluno não Encontrado");
        }
    }


    public void CriarAluno(Aluno aluno)
    {
        _alunoRepository.CriarAluno(aluno);

    }
    public void AtualizarAluno(Aluno aluno, int id)
    {
        _alunoRepository.AtualizarAluno(aluno, id);

    }
    public void DeletarAluno(int id)
    {
        _alunoRepository.DeletarAluno(id);
    }
}