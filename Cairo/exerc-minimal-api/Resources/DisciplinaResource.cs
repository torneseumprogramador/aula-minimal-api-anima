using Exercicio.Models;
using Exercicio.Models.DTO;

class DisciplinaResource
{
    public static List<Disciplina> GetAll()
    {
        MySqlRepositories repository = new MySqlRepositories();
        List<Disciplina> disciplinas = repository.BuscarDisciplinas();
        return disciplinas;
    }
    public static Disciplina GetId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Disciplina disciplina = repository.BuscarDisciplinaPorId(id);
        return disciplina;
    }
    public static bool Post(DisciplinaDTO DisciplinaRequestPost)
    {
        MySqlRepositories repository = new MySqlRepositories();
        bool cadastroSucesso = repository.CadastrarDisciplina(DisciplinaRequestPost);
        return cadastroSucesso;
    }
    public static bool DeleteId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Disciplina disciplina = repository.BuscarDisciplinaPorId(id);
        if (disciplina == null)
        {
            throw new Exception();
        }
        bool deletesucesso = repository.ExcluirDisciplinaPorId(id);
        return deletesucesso;
    }
}
