namespace MinimalAPIWilliam.Models;

public class Aluno{
    
    public Aluno(){
        this.Id = Guid.NewGuid();
    }
    public Guid Id {get; set;}    
    public int Matricula {get; set;}
    public String? Nome {get; set;}
    public List<double>? Notas {get; set;}

    public double? Media {get; set;}

    public String? Situacao {get; set;}

    public void calculaMedia(){
        double soma = 0;
        if(Notas != null && Notas.Count() > 0){
            for(int i = 0; i < Notas.Count(); i++){
                soma += Notas[i];
            }
            Media = soma /  Notas.Count();
        }else{
            Media = 0;
        }
    }

    public void VerificaSituacao(){
        calculaMedia();

        if(Media < 3){
            Situacao = "Reprovado";
        }else if(Media < 7){
            Situacao = "Recuperação";
        }else{
            Situacao = "Aprovado";
        }
    }
}