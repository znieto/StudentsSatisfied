using CsvHelper;
using CsvHelper.Configuration;
using Student.Satisfaction.Models.Dtos;
using System.Globalization;
using System.Text;

namespace Student.Satisfaction.Csv
{
    public class CsvService : IFileService
  {
    public CompanyTeamScoresDto ReadCsv(string filePath)
    {
      using var reader = new StreamReader(filePath);
      using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = ";",
        Encoding = Encoding.UTF8,
        MissingFieldFound = null,
        HeaderValidated = null,
        IgnoreBlankLines = true,
      });


      csv.Read();
      csv.ReadHeader();
      var data = new CompanyTeamScoresDto();

      data.Companies.AddRange(csv.HeaderRecord.Skip(1)); // Skip the first header cell ("Team/Company")

      // Reading each row
      while (csv.Read())
      {
        var team = new TeamDto { TeamName = csv.GetField(0) }; // The first field is the team name

        for (int i = 1; i < csv.HeaderRecord.Length; i++)
        {
          string companyName = data.Companies[i - 1];
          string field = csv.GetField(i);
          var score = ParseInteraction(field);
          team.CompanyScores.Add(companyName, score);
        }

        data.Teams.Add(team);
      }

      return data;

    }

    private static ScoreDto ParseInteraction(string field)
    {
      if (string.IsNullOrWhiteSpace(field))
      {
        return new ScoreDto(); // Empty interaction
      }
      else if (field.Contains(","))
      {
        // It's a pair of values
        var parts = field.Split(',');
        int.TryParse(parts[0], out int value1);
        int.TryParse(parts[1], out int value2);
        return new ScoreDto { PairValue = new Tuple<int?, int?>(value1, value2) };
      }
      else
      {
        // It's a single value
        return new ScoreDto { SingleValue = int.Parse(field) };
      }
    }
  }

}
