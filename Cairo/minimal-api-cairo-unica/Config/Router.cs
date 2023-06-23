namespace Minimal.Config;

public class Router
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/", HomeResource.Index).WithName("Home").WithOpenApi();
        app.MapPost("/cadastro", CadastroResource.Cadastro).WithName("Cadastro").WithOpenApi();
        app.MapGet("/weatherForecast", WeatherForecastResource.Index).WithName("WeatherForecast").WithOpenApi();
        app.MapGet("/weatherForecast/{id}", WeatherForecastResource.Get).WithName("weatherForecastGet").WithOpenApi();

    }

}
