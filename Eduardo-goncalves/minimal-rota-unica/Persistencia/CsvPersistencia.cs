using System.Globalization;
using CsvHelper;
using Minimal.Models;

namespace Minimal.Persistencia;

public class CsvPersistencia
{
    public static List<Aluno> ReadFromCsv()
    {
        if (!File.Exists("./bin/Debug/net7.0/notasAlunos.csv"))
            return new List<Aluno>();

        using (StreamReader reader = new StreamReader("./bin/Debug/net7.0/notasAlunos.csv"))
        using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csvReader.GetRecords<Aluno>().ToList();
        }
    }

    public static void WriteToCsv(List<Aluno> alunos)
    {
        using (StreamWriter writer = new StreamWriter("./bin/Debug/net7.0/notasAlunos.csv"))
        using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(alunos);
        }
    }
}