using web_api_min.Enums;
namespace web_api_min.Models;

public record AlunoModel(string Nome, int Matricula, string Notas, int Media, SituacaoAluno Situacao);