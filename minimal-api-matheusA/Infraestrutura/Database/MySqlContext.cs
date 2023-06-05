using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal.Infraestrutura.Database;
public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {

    }

    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Atividade> Atividade {get; set;}
    public DbSet<NotaAluno> NotaAluno {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Aluno>(a => 
        {
            a.HasKey(x => x.AlunoId);
            a.Property(x => x.Nome).IsRequired();
        });

        builder.Entity<Atividade>(a =>
        {
            a.HasKey(x => x.AtividadeId);
        });

        builder.Entity<NotaAluno>(a =>
        {
            a.HasKey(x => x.NotaAlunoId);
        });

        builder.Entity<NotaAluno>()
        .HasOne(n => n.Aluno)
        .WithMany()
        .HasForeignKey(n => n.AlunoId);

        builder.Entity<NotaAluno>()
            .HasOne(n => n.Atividade)
            .WithMany()
            .HasForeignKey(n => n.AtividadeId);

        builder.Entity<NotaAluno>()
        .HasIndex(n => new { n.AlunoId, n.AtividadeId })
        .IsUnique();    
    }
    
}
