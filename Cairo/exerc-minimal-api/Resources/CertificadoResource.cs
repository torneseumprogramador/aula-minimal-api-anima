using System.Reflection.Metadata;
using Exercicio.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

public class CertificadoResource
{
    public static List<Certificado> GetAll()
    {
        MySqlRepositories repository = new MySqlRepositories();
        List<Certificado> certificados = repository.BuscarCertificados();
        return certificados;
    }
    public static Certificado GetId(int id)
    {
        MySqlRepositories repository = new MySqlRepositories();
        Certificado certificado = repository.BuscarCertificadoPorId(id);
        return certificado;
    }
    public static bool Post([FromBody] CertificadoDTO certificadoDTORequest)
    {
        if (certificadoDTORequest.matricula != null)
        {
            Matricula matricula = MatriculaResource.GetId(certificadoDTORequest.matricula.Id);
            if (matricula == null)
            {
                throw new Exception("Matricula não encontrada. ");
            }

            if (!matricula.Aprovado)
            {
                throw new Exception("Aluno não foi aprovado!");
            }
            MySqlRepositories repository = new MySqlRepositories();
            bool cadastroSucesso = repository.CadastrarCertificado(certificadoDTORequest);
            return cadastroSucesso;
        }
        throw new Exception("Todos os parâmetros devem ser preenchidos.");
    }

    /*public static IActionResult Download(int id)
    {
        Certificado certificado = CertificadoResource.GetId(id);

        //Verifica se o certificado foi encontrado
        if (certificado == null)
        {
            return new NotFoundResult();
        }

        //Cria documento PDF
        PdfDocument document = new PdfDocument();

        // Cria uma página no documento
        PdfPage page = document.AddPage();

        // Obtém um objeto XGraphics para desenhar na página
        XGraphics gfx = XGraphics.FromPdfPage(page);


        // Define as posições e estilos para os elementos de texto
        XFont fontTitulo = new XFont("Verdana", 24, XFontStyle.Bold);
        XFont fontDados = new XFont("Verdana", 12, XFontStyle.Regular);
    }*/
}
