using Microsoft.AspNetCore.Mvc;
using Minimal.Infraestrutura.Database;
using Minimal.Models;

namespace Minimal.Resources;

public class AlunoResource
{
    private MySqlContext _context;  
    public AlunoResource(MySqlContext context)
    {
        _context = context;
    }
    public List<Aluno> GetAll()
    {
        return _context.Aluno.ToList();
    }

    public Aluno Get(int alunoId)
    {
        return _context.Aluno.Where(a => a.AlunoId == alunoId).FirstOrDefault();
    }

    public void Save([FromBody] Aluno aluno)
    {
        _context.Aluno.Add(aluno);
        _context.SaveChanges();
    }

    public void Update(int alunoId, [FromBody] Aluno aluno)
    {
        var alunoExistente = _context.Aluno.FirstOrDefault(a => a.AlunoId == alunoId);
        if(alunoExistente != null){
            alunoExistente.Nome = aluno.Nome;
        }
        _context.SaveChanges();
    }

}