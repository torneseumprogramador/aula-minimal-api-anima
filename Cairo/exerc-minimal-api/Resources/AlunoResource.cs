using Exercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Exercicio.Models.DTO;

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
    public static bool Post(AlunoDTO alunoRequestPost)
    {
        MySqlRepositories repository = new MySqlRepositories();
        bool cadastroSucesso = repository.CadastrarAluno(alunoRequestPost);
        return cadastroSucesso;
    }

    public static bool DeleteId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Aluno aluno = repository.BuscarAlunoPorId(id);
        if (aluno == null)
        {
            throw new Exception();
        }
        bool deletesucesso = repository.ExcluirAlunoPorId(id);
        return deletesucesso;
    }
}
