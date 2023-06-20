using Exercicio.Models;

class AlunoResource
{
    public static List<Aluno> GetAll()
    {
        MySqlRepositories repository = new MySqlRepositories();
        List<Aluno> alunos = repository.BuscarAlunos();
        return alunos;
    }
    public static Aluno GetId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Aluno aluno = repository.BuscarAlunoPorId(id);
        return aluno;
    }
}
