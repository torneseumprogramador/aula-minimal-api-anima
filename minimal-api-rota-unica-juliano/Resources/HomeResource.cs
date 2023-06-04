using Minimal.Models;

class HomeResource
{
    public static dynamic Index()
    {
        return new {
            Mensagem = "Bem vindo a minha api minima"
        };
    }
}
