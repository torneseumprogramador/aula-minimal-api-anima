namespace Exercicio.Config.Router;

public class CertificadoRouter
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/certificados", CertificadoResource.GetAll).WithName("BuscarCertificados").WithOpenApi();
        app.MapGet("/certificado/id", CertificadoResource.GetId).WithName("BuscarCertificadoPorId").WithOpenApi();
        app.MapPost("/certificado/cadastro", CertificadoResource.Post).WithName("CadastrarCertificado").WithOpenApi();
        //app.MapGet("/certificado/{id}/pdf", CertificadoResource.Download).WithName("ImprimirPdf").WithOpenApi();
    }
}
