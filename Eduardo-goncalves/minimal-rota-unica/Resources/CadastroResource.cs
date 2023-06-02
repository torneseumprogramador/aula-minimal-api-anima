using Microsoft.AspNetCore.Mvc;
using Minimal.Models;

class CadastroResource
{
    public static Aluno Cadastro([FromBody] Aluno dadoRequestPost)
    {
        return dadoRequestPost;
    }
}