namespace web_api_min.Service.Response;

public record AlunoResponse(string Nome, int Matricula, string Notas, int Media, string Situacao);