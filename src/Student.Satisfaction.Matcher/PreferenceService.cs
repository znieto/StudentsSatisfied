using Student.Satisfaction.Models.Model;

namespace Student.Satisfaction.Matcher
{
  internal class PreferenceService
  {
    readonly List<Team> teams = [];
    readonly List<Company> companies = [];

    public List<Team> Teams => teams;

    public List<Company> Companies => companies;

    public PreferenceService(List<Team> teams, List<Company> companies)
    {
      this.companies = companies;
      this.teams = teams;
    }

    public void GeneratePreferences(Models.Dtos.CompanyTeamScoresDto companyTeamScores)
    {
      companyTeamScores?.Teams.ForEach(team =>
      {
        var preferences = team.CompanyScores.OrderBy(pair => pair.Value).Select(pair => pair.Key).ToList();
        Teams.Add(new Team { Name = team.TeamName, Preferences = preferences });

      });

      companyTeamScores?.Companies.ForEach(company =>
      {
        var preferences = company.TeamScores.OrderBy(pair => pair.Value).Select(pair => pair.Key).ToList();
        Companies.Add(new Company { Name = company.CompanyName, Preferences = preferences });

      }
      );
    }
  }
}
