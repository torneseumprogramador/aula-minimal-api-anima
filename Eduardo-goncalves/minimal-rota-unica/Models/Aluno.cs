using Minimal.Persistencia;
using System.Text.Json.Serialization;

namespace Minimal.Models;

public class Aluno
{
    public int Id { get; set; }
    public string NomeAluno { get; set; } = string.Empty;
    public double Nota_01 { get; set; } = default;
    public double Nota_02 { get; set; } = default;
    public double Nota_03 { get; set; } = default;
    public double Media { get; set; } = default;

    public static List<Aluno> BuscarLista() => CsvPersistencia.ReadFromCsv();

    public static Aluno Buscar(int id)
    {
        List<Aluno> alunos = BuscarLista();
        Aluno? aluno = alunos.FirstOrDefault(a => a.Id == id);

        if (aluno == null)
            throw new Exception($"Aluno com o Id = {id} não encontrado");

        return aluno;
    }

    public static void Salvar(Aluno aluno)
    {
        if (string.IsNullOrEmpty(aluno.NomeAluno))
            return;

        List<Aluno> alunos = BuscarLista();

        int ultimoId = alunos.Count > 0 ? alunos.Max(a => a.Id) : 0;

        aluno.Id = ultimoId + 1;

        alunos.Add(aluno);

        CsvPersistencia.WriteToCsv(alunos);
    }

    public static void Editar(int id, Aluno alunoEditado)
    {
        List<Aluno> alunos = BuscarLista();

        Aluno? aluno = alunos.FirstOrDefault(a => a.Id == id);

        if (aluno == null)
            throw new Exception($"Aluno com o Id = {id} não encontrado");

        aluno.NomeAluno = alunoEditado.NomeAluno;

        CsvPersistencia.WriteToCsv(alunos);
    }

    public static void Deletar(int id)
    {
        List<Aluno> alunos = BuscarLista();

        Aluno? aluno = alunos.Find(a => a.Id == id);

        if (aluno == null)
            throw new Exception($"Aluno com o Id = {id} não encontrado");

        alunos.Remove(aluno);

        CsvPersistencia.WriteToCsv(alunos);
    }
};