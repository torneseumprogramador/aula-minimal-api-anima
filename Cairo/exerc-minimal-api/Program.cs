using Exercicio.Config.Router;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//faz o redirect para o sistema https.
app.UseHttpsRedirection();
AlunoRouter.Register(app);
DisciplinaRouter.Register(app);
MatriculaRouter.Register(app);
CertificadoRouter.Register(app);

app.Run();
