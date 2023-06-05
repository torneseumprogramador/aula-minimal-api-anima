using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimal.Models;

public class Atividade{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AtividadeId{get;set;}
    [Required]
    public string Nome{get;set;}
    [Required]
    public double Valor{get;set;}
}