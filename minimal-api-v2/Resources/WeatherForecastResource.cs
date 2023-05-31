using Minimal.Models;

class WeatherForecastResource
{
    public static WeatherForecast[] Index()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast =  Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    }

    public static WeatherForecast Get(int id)
    {
        return new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
            Random.Shared.Next(-20, 55),
            ""
        );
    }
}
