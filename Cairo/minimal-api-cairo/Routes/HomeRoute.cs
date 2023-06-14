class HomeRoute
{
    private WebApplication app;
    public HomeRoute(WebApplication _app)
    {
        this.app = _app;
    }
    public void Register()
    {
        //Criando a Home
        app.MapGet("/", () =>
        {
            return new
            {
                Mensagem = "Bem vindo a minha API"
            };
        })
            .WithName("Home")
            .WithOpenApi();
    }
}
