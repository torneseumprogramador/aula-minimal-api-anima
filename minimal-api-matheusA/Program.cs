using Microsoft.EntityFrameworkCore;
using Minimal.Config;
using Minimal.Infraestrutura.Database;
using Minimal.Resources;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<MySqlContext>(options =>
{
    options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
}, ServiceLifetime.Singleton);

builder.Services.AddScoped<AlunoResource>();
builder.Services.AddScoped<NotaAlunoResource>();
builder.Services.AddScoped<AtividadeResource>();
builder.Services.AddScoped<Router>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var router = scope.ServiceProvider.GetRequiredService<Router>();
    router.Register(app);
}

app.Run();
