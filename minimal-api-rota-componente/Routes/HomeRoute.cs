using Minimal.Models;

class HomeRoute
{
    public HomeRoute(WebApplication _app)
    {
        this.app = _app;
    }

    private WebApplication app;

    public void Register()
    {
        app.MapGet("/", () =>
        {
            return new {
                Mensagem = "Bem vindo a minha api minima"
            };
        })
        .WithName("Home")
        .WithOpenApi();
    }
}
