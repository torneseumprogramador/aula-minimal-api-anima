using System.IO;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using web_api_min.Models;

public class GerarPdf
{
    public static void GerarPDFAluno(AlunoModel aluno)
    {
        // Criação do documento PDF
        iTextSharp.text.Document doc = new iTextSharp.text.Document();

        // Definição do caminho e nome do arquivo PDF gerado
        string filePath = "C:/TestePDF/Certificao.pdf";

        // Criação do objeto PDFWriter para escrever no documento
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

        // Abertura do documento
        doc.Open();

        // Adicionar conteúdo ao documento
        Paragraph paragraph = new Paragraph();
        paragraph.Alignment = Element.ALIGN_CENTER;
        paragraph.Add($"Nome: {aluno.Nome}");
        paragraph.Add("\n");
        paragraph.Add($"Matrícula: {aluno.Matricula}");
        paragraph.Add("\n");
        paragraph.Add($"Notas: {aluno.Notas}");
        paragraph.Add("\n");
        paragraph.Add($"Média: {aluno.Media}");
        paragraph.Add("\n");
        paragraph.Add($"Situação: {aluno.Situacao}");

        doc.Add(paragraph);

        // Fechamento do documento
        doc.Close();
    }
}
