using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

class AlunoResource
{
    public static List<Aluno> GetListaAlunos()
    {
        return Aluno.BuscarLista();
    }

    public static Aluno GetAluno(int id)
    {
        return Aluno.Buscar(id);
    }

    public static void PostAluno([FromBody] Aluno dadosAluno)
    {
        Aluno.Salvar(dadosAluno);
    }

    public static void PutAluno(int id, [FromBody] Aluno alunoEditado)
    {
        Aluno.Editar(id, alunoEditado);
    }

}