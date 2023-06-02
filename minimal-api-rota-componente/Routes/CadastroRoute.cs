using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

class CadastroRoute
{
    public CadastroRoute(WebApplication _app)
    {
        this.app = _app;
    }

    private WebApplication app;

    public void Register()
    {
        app.MapPost("/cadastro", ([FromBody] Dado dadoRequestPost) =>
        {
            return dadoRequestPost;
        })
        .WithName("Cadastro")
        .WithOpenApi();
    }
}
