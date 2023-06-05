using Microsoft.AspNetCore.Mvc;
using Minimal.Infraestrutura.Database;
using Minimal.Models;

namespace Minimal.Resources;

public class AtividadeResource
{
    private MySqlContext _context;  
    public AtividadeResource(MySqlContext context)
    {
        _context = context;
    }
    public List<Atividade> GetAll()
    {
        return _context.Atividade.ToList();
    }

    public Atividade Get(int atividadeId)
    {
        return _context.Atividade.Where(a => a.AtividadeId == atividadeId).FirstOrDefault();
    }

    public void Save([FromBody] Atividade atividade)
    {
        _context.Atividade.Add(atividade);
        _context.SaveChanges();
    }

    public void Update(int AtividadeId, [FromBody] Atividade atividade)
    {
        var AtividadeExistente = _context.Atividade.FirstOrDefault(a => a.AtividadeId == AtividadeId);
        if(AtividadeExistente != null){
            AtividadeExistente.Nome = atividade.Nome;
            AtividadeExistente.Valor = atividade.Valor;
        }
        _context.SaveChanges();
    }

}