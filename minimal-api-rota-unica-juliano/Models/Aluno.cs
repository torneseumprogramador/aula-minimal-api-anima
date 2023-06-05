namespace Minimal.Models;

record Aluno
{
    public int? Matricula { get;set; }
    public string? Nome { get;set; }
    public float? GrauA { get;set; }
    public float? GrauB { get;set; }
}