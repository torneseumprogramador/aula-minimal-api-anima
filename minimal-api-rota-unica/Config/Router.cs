namespace Minimal.Config;

public class Router
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/", HomeResource.Index).WithName("Home").WithOpenApi();

        app.MapGet("/cadastro", CadastroResource.Cadastro).WithName("Cadastro").WithOpenApi();

        app.MapGet("/weatherforecast", WeatherForecastResource.Index).WithName("Weatherforecast").WithOpenApi();
        app.MapGet("/weatherforecast/{id}", WeatherForecastResource.Get).WithName("WeatherforecastGet").WithOpenApi();
    }
}
