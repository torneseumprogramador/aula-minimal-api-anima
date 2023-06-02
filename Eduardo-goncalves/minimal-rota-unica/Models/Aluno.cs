namespace Minimal.Models;

public class Aluno
{
    public string NomeAluno { get; set; } = string.Empty;
    public double NotaAluno { get; set; } = default;

    public static List<Aluno> BuscarLista()
    {
        List<Aluno> listaAlunos = new List<Aluno>();

        listaAlunos.Add(new Aluno
        {
            NomeAluno = "Aluno teste 01",
            NotaAluno = 7
        });

        listaAlunos.Add(new Aluno
        {
            NomeAluno = "Aluno teste 02",
            NotaAluno = 7
        });

        listaAlunos.Add(new Aluno
        {
            NomeAluno = "Aluno teste 03",
            NotaAluno = 7
        });

        return listaAlunos;
    }

    public static Aluno Buscar(int id)
    {
        return new Aluno() { NomeAluno = $"Aluno com id {id}", NotaAluno = 8 };
    }

    public static void Salvar(Aluno aluno)
    {
        if (!string.IsNullOrEmpty(aluno.NomeAluno))
        {
            Aluno alunoNovo = new Aluno()
            {
                NomeAluno = aluno.NomeAluno,
                NotaAluno = aluno.NotaAluno
            };
        }
    }

    public static void Editar(int id, Aluno alunoEditado)
    {
        Aluno aluno = Buscar(id);

        aluno.NomeAluno = alunoEditado.NomeAluno;
        aluno.NotaAluno = alunoEditado.NotaAluno;
    }
};