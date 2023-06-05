using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Minimal.Models;

public class Aluno{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AlunoId {get; set;}
    public string Nome { get; set; }
}