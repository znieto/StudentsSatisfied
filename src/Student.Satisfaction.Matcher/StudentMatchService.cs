using Student.Satisfaction.Csv;
using Student.Satisfaction.Models.Model;

namespace Student.Satisfaction.Matcher
{
  public class StudentMatchService
  {
    private readonly string csvFilePath;
    private readonly CsvService csvService = new CsvService();
    readonly List<Team> teams = [];
    readonly List<Company> companies = [];
    private readonly PreferenceService preferenceService;
    private readonly MatchingService matchingService;
    Models.Dtos.CompanyTeamScoresDto companyTeamScores = new Models.Dtos.CompanyTeamScoresDto();

    public StudentMatchService(string csvFilePath)
    {
      this.csvFilePath = csvFilePath;
      this.preferenceService = new PreferenceService(teams, companies);
      this.matchingService = new MatchingService(teams, companies);
    }

    public void Process()
    {
      // Load data
      companyTeamScores = csvService.ReadCsv(csvFilePath);
      // Generate preferences
      preferenceService.GeneratePreferences(companyTeamScores);

      // Perform matching
      var matches = matchingService.PerformMatching();

      var outputService = new OutputService();
      // Display output
      outputService.DisplayMatches(matches);
    }
  }
}
