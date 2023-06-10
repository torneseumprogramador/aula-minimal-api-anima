

using min_api_raissa.Models;

using min_api_raissa.Config;

var alunos = new List<Aluno>();


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

AlunoRouter.Register(app);
HomeRouter.Register(app);


// app.MapGet("/alunos", () =>
// {
//     return alunos.Any() ? JsonSerializer.Serialize(alunos) : " Nenhum Aluno Encontrado";
// })
// .WithName("ListarTodosAlunos").WithOpenApi();


// app.MapGet("/alunos/{id}", ([FromRoute] int id) =>
// {
//     var aluno = alunos.FirstOrDefault(a => a.Id == id);

//     return JsonSerializer.Serialize(alunos) ?? "Aluno não encontrado";

// }).WithName("ObterAlunoPorId").WithOpenApi();


// app.MapPost("/alunos", ([FromBody] Aluno aluno) =>
// {
//     var existeAluno = alunos.FirstOrDefault(a => a.Nome == aluno.Nome);
//     if (existeAluno == null)
//     {

//         aluno.Id = alunos.Count + 1;
//         alunos.Add(aluno);
//         return $"Aluno {aluno.Nome} cadastrado! ";
//     }
//     else
//     {
//         return $"Aluno com nome {aluno.Nome} já existe no sistema";
//     }


// }).WithName("CadastrarAluno").WithOpenApi();

// app.MapPut("/alunos/{id}", ([FromBody] Aluno aluno, [FromRoute] int id) =>
// {
//     var existeAluno = alunos.FirstOrDefault(a => a.Nome == aluno.Nome);
//     if (existeAluno != null)
//     {

//         existeAluno.Nome = aluno.Nome;
//         existeAluno.Notas = aluno.Notas;
//         return $"Aluno {aluno.Id} atualizado com sucesso ! ";
//     }
//     else
//     {
//         return $"Aluno com id {aluno.Id} não existe no sistema";
//     }


// }).WithName("AtualizarAluno").WithOpenApi();


// app.MapDelete("/alunos/{id}", ([FromRoute] int id) =>
// {
//     var existeAluno = alunos.FirstOrDefault(a => a.Id == id);
//     if (existeAluno != null)
//     {

//         alunos.Remove(existeAluno);

//         return $"Aluno {id} atualizado com sucesso ! ";
//     }
//     else
//     {
//         return $"Aluno com id {id} não existe no sistema";
//     }


// }).WithName("DeletarAluno").WithOpenApi();


app.Run();
