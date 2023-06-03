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
        if (string.IsNullOrEmpty(dadosAluno.NomeAluno))
            throw new Exception($"Nome inválido");

        Aluno.Salvar(dadosAluno);
    }

    public static void PutAluno(int id, [FromBody] Aluno alunoEditado)
    {
        if (string.IsNullOrEmpty(alunoEditado.NomeAluno))
            throw new Exception($"Nome inválido");

        Aluno.Editar(id, alunoEditado);
    }

    public static void DeleteAluno(int id)
    {
        Aluno.Deletar(id);
    }

}