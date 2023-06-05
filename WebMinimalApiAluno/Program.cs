using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var alunos = new List<Aluno>
{
    new Aluno { Id = 1, Nome = "Alberto Santamaria"},
    new Aluno { Id = 2, Nome = "Roanna Neves"},
    new Aluno { Id = 3, Nome = "Calista Maia"},
    new Aluno { Id = 4, Nome = "Joao Feitosa"},
    new Aluno { Id = 5, Nome = "Felipe Cavalcante"},
    new Aluno { Id = 6, Nome = "Daniel Martins"}
};

var cursos = new List<Curso>
{
    new Curso { Id = 1, NomeCurso = ".NET 7 Minimal WebAPI" }
};

var disciplinas = new List<Disciplina>
{
    new Disciplina { Id = 1, NomeDisciplina = ".NET Basico", CursoId = 1 },
    new Disciplina { Id = 2, NomeDisciplina = ".NET Nivel medio", CursoId = 1 },
    new Disciplina { Id = 3, NomeDisciplina = ".NET Avançado", CursoId = 1 },
    new Disciplina { Id = 4, NomeDisciplina = "Azure DevOps", CursoId = 1 },
    new Disciplina { Id = 5, NomeDisciplina = "Fundamentos de Redes de Computadores", CursoId = 1 },
    new Disciplina { Id = 6, NomeDisciplina = "Computação Paralela", CursoId = 1 },
    new Disciplina { Id = 7, NomeDisciplina = "Sistemas Distribuídos", CursoId = 1 },
    new Disciplina { Id = 8, NomeDisciplina = "Projeto e Otimização de Algoritmos", CursoId = 1 },
    new Disciplina { Id = 9, NomeDisciplina = "Inteligência Artificial", CursoId = 1 }
};

var notas = new List<Nota>
{
    new Nota { Id = 1, DisciplinaId = 1, CursoId = 1, AlunoId = 1, NotaDiciplina = 10 },
    new Nota { Id = 2, DisciplinaId = 2, CursoId = 1, AlunoId = 1, NotaDiciplina = 8 },
    new Nota { Id = 3, DisciplinaId = 3, CursoId = 1, AlunoId = 1, NotaDiciplina = 9 },
    new Nota { Id = 4, DisciplinaId = 4, CursoId = 1, AlunoId = 1, NotaDiciplina = 1 },
    new Nota { Id = 5, DisciplinaId = 5, CursoId = 1, AlunoId = 1, NotaDiciplina = 5 },
    new Nota { Id = 6, DisciplinaId = 6, CursoId = 1, AlunoId = 1, NotaDiciplina = 6 },
    new Nota { Id = 7, DisciplinaId = 7, CursoId = 1, AlunoId = 1, NotaDiciplina = 7 },
    new Nota { Id = 8, DisciplinaId = 8, CursoId = 1, AlunoId = 1, NotaDiciplina = 4 },
    new Nota { Id = 9, DisciplinaId = 9, CursoId = 1, AlunoId = 1, NotaDiciplina = 4 }
};

app.MapGet("/aluno", () =>
{
    return alunos;
});

app.MapGet("/aluno{id}", (int id) =>
{
    var aluno = alunos.Find(a => a.Id ==id);
    if (aluno is null)
        return Results.NotFound("Aluno não encontrado.");

    return Results.Ok(aluno);
});

app.MapPost("/aluno", (Aluno aluno ) =>
{
    alunos.Add(aluno);
    return alunos;
});

app.MapPut("/aluno{id}", (Aluno updateAluno, int id) =>
{
    var aluno = alunos.Find(a => a.Id ==id);
    if (aluno is null)
        return Results.NotFound("Aluno não encontrado.");

    aluno.Nome = updateAluno.Nome;

    return Results.Ok(aluno);
});

app.MapDelete("/aluno{id}", (int id) =>
{
    var aluno = alunos.Find(a => a.Id ==id);
    if (aluno is null)
        return Results.NotFound("Aluno não encontrado.");

    alunos.Remove(aluno);

    return Results.Ok(aluno);
});


app.MapGet("/diciplina", () => {
    return disciplinas;
});

app.MapGet("/aluno/promedio{id}", (int id) =>
{
    var aluno = alunos.Find(a => a.Id ==id);
    if (aluno is null)
        return Results.NotFound("Aluno não encontrado.");
    var alunoPromedio = notas.Average(p => p.NotaDiciplina);

    return Results.Ok(alunoPromedio);
});

app.MapGet("/aluno/certificado{id}", (int id) =>
{
    var aluno = alunos.Find(a => a.Id ==id);
    if (aluno is null)
        return Results.NotFound("Aluno não encontrado.");
    var alunoPromedio = notas.Average(p => p.NotaDiciplina);

    // gerar PDF
    if (alunoPromedio >= 5) {
        // Create a new PDF document.
        var document = new PdfDocument();
        document.Info.Title = "RELATORIO DE NOTAS";
        document.Info.Subject = "GAMMA DEV";

        // Create an empty page in this document.
        var page = document.AddPage();

        // Get an XGraphics object for drawing on this page.
        var gfx = XGraphics.FromPdfPage(page);

        // Draw two lines with a red default pen.
        var width = page.Width;
        var height = page.Height;
        gfx.DrawLine(XPens.Red, 0, 0, width, height);
        gfx.DrawLine(XPens.Red, width, 0, 0, height);

        // Create a font.
        var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);

        // Draw the text.
        gfx.DrawString("Relatorio de Notas", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

        // Save the document...
        var filename = "relatorio_de_notas.pdf";
        document.Save(filename);
        // ...and start a viewer.
        Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
    }
    else
        return Results.NotFound("Aluno com nota < 5. Certificado não disponível.");

    return Results.Ok("PDFfile");
});


app.Run();

class Aluno
{
    public int Id { get ; set; }
    public string? Nome { get ; set; }

}

class Curso
{
    public int Id { get ; set; }

    public string? NomeCurso { get ; set; }
}

class Disciplina
{
    public int Id { get ; set; }
    public string? NomeDisciplina { get ; set; }
    public int CursoId { get ; set; }
   
}

class Nota
{
    public int Id { get ; set; }
    public int CursoId { get ; set; }
    public int DisciplinaId { get ; set; }
    public int AlunoId { get ; set; }
    public float NotaDiciplina { get ; set; }
   
}

