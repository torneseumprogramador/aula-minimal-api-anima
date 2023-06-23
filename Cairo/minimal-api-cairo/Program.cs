using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

//ROTA-COMPONENTE


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger a principio é habilitado apenas para desenvolvimento, por segurança.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//faz o redirect para o sistema https.
app.UseHttpsRedirection();

new WeatherForecastRoute(app).Register();
new HomeRoute(app).Register();
new CadastroRoute(app).Register();

app.Run();

#region Anotacoes
//class é para um objeto mais robusto, onde posso usar mais recursos.
//Tem propriedades, métodos, herança e etc
/*class Pessoa
{
    public string? Nome { get; set; }
}

//struct é um ítem mais simples, usado para DTO. Entidade simples que vai ser transitada.
// sem recursos avançados.
struct PessoaStruct
{
    public string? Nome { get; set; }
}*/

//Utilizado para casos de api, Dto, ModelVies. Não possui complexidade de recursos(herança e etc)
//Usado para mostrar algo ou capturar

/*
class WeatherForecastClass
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

}*/


//Caso eu quise separar o método de rota
/*class Teste
{
    public static Object rota(string[] summaries)
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
    }
}*/

#endregion



