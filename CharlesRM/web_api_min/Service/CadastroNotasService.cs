namespace web_api_min.Service;
class CadastroNotasService
{
    

         public static int ObterMediaNotas(string notasString)
        {
            string[] notasArray = notasString.Split(',');

            int[] notas = new int[notasArray.Length];
            var soma = 0;
            for (int i = 0; i < notasArray.Length; i++)
            {
                if (int.TryParse(notasArray[i], out int nota))
                {
                    notas[i] = nota;
                    soma += nota;
                }
                else
                {
                    // Lógica para tratar o caso em que uma nota não é um número inteiro válido
                    // Você pode optar por atribuir um valor padrão, lançar uma exceção, etc.
                }
            }

            return soma / notas.Length;
        }

      public static  string GetUpdateQuery(AlunoUpDateRequest aluno)
        {
            string query = "UPDATE Aluno SET ";

            if (aluno.Nome != null)
                query += "nome = @nome";

            if (aluno.Notas != null)
            {
                if (aluno.Nome != null)
                    query += ", ";

                query += "notas = @notas";
            }

            query += " WHERE matricula = @matricula";

            return query;
        }
}