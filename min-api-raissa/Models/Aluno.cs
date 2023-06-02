namespace min_api_raissa.Models;


public class Aluno
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public List<Nota>? Notas { get; set; }

    public double Media
    {
        get
        {
            if (Notas != null && Notas.Any())
                return Notas.Select(n => n.NotaDaUnidade).Average();
            else
                return 0.0;
        }
    }

}
