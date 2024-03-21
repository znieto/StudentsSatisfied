using Student.Satisfaction.Csv;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Student.Satisfaction.Matcher
{
  public class StudentMatchService
  {
    private readonly string csvFilePath;
    private readonly CsvService csvService = new CsvService();
    public StudentMatchService(string csvFilePath) => this.csvFilePath = csvFilePath;

    public void Process()
    {
      var companyTeamScores = csvService.ReadCsv(csvFilePath);

      //var matches = PerformMatching(data.Teams, data.Companies);

      //// Output matches
      //foreach (var match in matches)
      //{
      //  Console.WriteLine($"Team {match.Key} is matched with Company {match.Value}");
      //}

    }
  }
}
