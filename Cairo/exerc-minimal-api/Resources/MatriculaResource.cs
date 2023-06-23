using Exercicio.Models;
using Exercicio.Models.DTO;
using Microsoft.AspNetCore.Mvc;

class MatriculaResource
{
    public static List<Matricula> GetAll()
    {
        MySqlRepositories repository = new MySqlRepositories();
        List<Matricula> matriculas = repository.BuscarMatriculas();
        return matriculas;
    }
    public static Matricula GetId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Matricula matricula = repository.BuscarMatriculaPorId(id);
        return matricula;
    }
    public static List<Matricula> GetIdAluno(int idAluno)
    {
        Aluno aluno = AlunoResource.GetId(idAluno);
        if (aluno == null)
        {
            throw new Exception("Aluno não econtrado");
        }
        MySqlRepositories repository = new MySqlRepositories();
        List<Matricula> matriculas = repository.BuscarMatriculasPorIdAluno(idAluno);
        return matriculas;
    }

    public static bool Post([FromBody] MatriculaDTO matriculaDtoRequest)
    {
        if (matriculaDtoRequest.Aluno != null && matriculaDtoRequest.Disciplina != null)
        {
            Aluno aluno = AlunoResource.GetId(matriculaDtoRequest.Aluno.Id);
            if (aluno == null)
            {
                throw new Exception("Aluno não econtrado. ");
            }
            Disciplina disciplina = DisciplinaResource.GetId(matriculaDtoRequest.Disciplina.Id);
            if (disciplina == null)
            {
                throw new Exception("Disciplina não encontrada.");
            }
            MySqlRepositories repository = new MySqlRepositories();
            bool cadastroSucesso = repository.CadastrarMatricula(matriculaDtoRequest);
            return cadastroSucesso;
        }
        throw new Exception("Todos os parâmetros devem ser preenchidos.");
    }
    /*public static bool DeletId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Disciplina
    }*/
    /*public static bool DeleteId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Disciplina disciplina = repository.BuscarDisciplinaPorId(id);
        if (disciplina == null)
        {
            throw new Exception();
        }
        bool deletesucesso = repository.ExcluirDisciplinaPorId(id);
        return deletesucesso;
    }*/
}
