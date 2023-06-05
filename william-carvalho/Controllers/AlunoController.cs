using MinimalAPIWilliam.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace MinimalAPIWilliam.Controllers;

class AlunoController{

    public static List<Aluno> alunos = new List<Aluno>();
    public static object Get()
    {
        return alunos;
    }

    public static object Post(Aluno aluno)
    {
        aluno.VerificaSituacao();
        alunos.Add(aluno);
        return new { mensagem = "Adicionado com sucesso na lista de alunos" };
    }

    public static object Put(Guid id, Aluno aluno)
    {
        var alunoExistente = alunos.FirstOrDefault(a => a.Id == id);
        if (alunoExistente != null)
        {
            alunoExistente.Nome = aluno.Nome;
            alunoExistente.Matricula = aluno.Matricula;
            alunoExistente.Notas = aluno.Notas;
            alunoExistente.VerificaSituacao();
            return new { mensagem = "Aluno atualizado com sucesso" };
        }
        else
        {
            return new { erro = true, mensagem = "ID não encontrado" };
        }
    }

    public static object Delete(Guid id)
    {
        var alunoExistente = alunos.FirstOrDefault(a => a.Id == id);
        if (alunoExistente != null)
        {
            alunos.Remove(alunoExistente);
            return new { mensagem = "Aluno removido com sucesso" };
        }
        else
        {
            return new { erro = true, mensagem = "ID não encontrado" };
        }
    }

    public static object GetByID(Guid id)
    {
        var aluno = alunos.FirstOrDefault(a => a.Id == id);
        if (aluno != null)
        {
            return aluno;
        }
        else
        {
            return new { erro = true, mensagem = "ID não encontrado" };
        }
    }

    public static object GetByMatricula(int matricula)
    {
        var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
        if (aluno != null)
        {
            return aluno;
        }
        else
        {
            return new { erro = true, mensagem = "Matrícula não encontrada" };
        }
    }

    public static object GetCertificadoByMatricula(int matricula){
        var aluno = alunos.FirstOrDefault(a => a.Matricula == matricula);
        if (aluno != null)
        {
            Document document = new Document(new Rectangle(792f, 612f));

            var memoryStream = new MemoryStream();

            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            var backgroundImage = Image.GetInstance(Path.Combine(AppContext.BaseDirectory, "fundo-certificado.jpg"));
            backgroundImage.SetAbsolutePosition(0, 0);
            backgroundImage.ScaleAbsolute(document.PageSize.Width, document.PageSize.Height);
            document.Add(backgroundImage);

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24);
            var title = new Paragraph("CERTIFICADO", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 120; 
            document.Add(title);

            var contentFont = FontFactory.GetFont(FontFactory.HELVETICA, 16);
            var content = new Paragraph("Certifico que o aluno " + aluno.Nome + " de matrícula " + matricula + " possui a situação " + aluno.Situacao + " e média " + decimal.Round((decimal)aluno.Media, 2).ToString("F2") + " no curso.", contentFont);
            content.Alignment = Element.ALIGN_CENTER;
            content.SpacingAfter = 80;
            document.Add(content);

            var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var date = new Paragraph(DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy"), dateFont);
            date.Alignment = Element.ALIGN_CENTER;
            document.Add(date);

            document.Close();

            var pdfBytes = memoryStream.ToArray();

            var fileContentResult = new FileContentResult(pdfBytes, "application/pdf");
            fileContentResult.FileDownloadName = "certificado.pdf";
            return fileContentResult;
        }
        else
        {
            return new { erro = true, mensagem = "Matrícula não encontrada" };
        }
    }
}