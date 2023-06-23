using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

class CadastroRoute
{
    private WebApplication app;
    public CadastroRoute(WebApplication _api)
    {
        this.app = _api;
    }
    public void Register()
    {
        //Criando um método post
        app.MapPost("/cadastro", ([FromBody] Dado dadosRequestPost) =>
        {
            return dadosRequestPost;
        })
        .WithName("Cadastro")
        .WithOpenApi();

    }
}
