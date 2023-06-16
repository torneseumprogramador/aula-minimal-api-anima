using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

class CadastroResource
{
    public static Dado Cadastro([FromBody] Dado dadosRequestPost)
    {
        return dadosRequestPost;
    }
}
