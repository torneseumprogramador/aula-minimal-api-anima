using Minimal.Models;

class WeatherForecastRoute
{
    private WebApplication app;

    public WeatherForecastRoute(WebApplication _app)
    {
        this.app = _app;
    }

    public void Register()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast") //Nome na documentação da rota
    .WithOpenApi(); //Utilizar a documentação da api
    }
}
