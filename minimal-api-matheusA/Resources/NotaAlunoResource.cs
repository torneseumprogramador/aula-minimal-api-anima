using Microsoft.AspNetCore.Mvc;
using Minimal.Infraestrutura.Database;
using Minimal.Models;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

using PdfSharp.Pdf;

namespace Minimal.Resources;

public class NotaAlunoResource
{
    private MySqlContext _context;  
    public NotaAlunoResource(MySqlContext context)
    {
        _context = context;
    }

    public List<NotaAluno> GetAll(int? alunoId = null, int? atividadeId = null, int? notaAlunoId = null)
    {
        var query = _context.NotaAluno.AsQueryable();

        if (alunoId.HasValue)
        {
            query = query.Where(a => a.AlunoId == alunoId.Value);
        }

        if (atividadeId.HasValue)
        {
            query = query.Where(a => a.AtividadeId == atividadeId.Value);
        }

        if (notaAlunoId.HasValue)
        {
            query = query.Where(a => a.NotaAlunoId == notaAlunoId.Value);
        }

        return query.ToList();
    }

    public NotaAluno Get(int notaAlunoId)
    {
        return _context.NotaAluno.Where(a => a.NotaAlunoId == notaAlunoId).FirstOrDefault();
    }

    public void Save([FromBody] NotaAluno NotaAluno)
    {
        _context.NotaAluno.Add(NotaAluno);
        _context.SaveChanges();
    }

    public void Update(int notaAlunoId, [FromBody] NotaAluno notaAluno)
    {
        var notaAlunoExistente = _context.NotaAluno.FirstOrDefault(a => a.NotaAlunoId == notaAlunoId);
        if(notaAlunoExistente != null){
            notaAlunoExistente.Nota = notaAluno.Nota;
        }
        _context.SaveChanges();
    }

    public double Media(int alunoId)
    {
        var media = _context.NotaAluno.Where(a => a.AlunoId == alunoId).Select(a => a.Nota).Sum();
        return media;
    }

    public void ExportPdf(double Media)
    {
    // Criar um novo documento PDF
    PdfDocument document = new PdfDocument();
    PdfPage page = document.AddPage();

    // Definir o conteúdo do documento
    XGraphics gfx = XGraphics.FromPdfPage(page);
    XFont font = new XFont("Helvetica", 12);
    gfx.DrawString("Exemplo de PDF exportado", font, XBrushes.Black,
        new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

    // Salvar o documento em um arquivo
    string filePath = @"C:\temp\arquivo.pdf";
    document.Save(filePath);
    }


}