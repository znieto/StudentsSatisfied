using Student.Satisfaction.Models.Model;

namespace Student.Satisfaction.Matcher
{
  internal class MatchingService
  {
    public MatchingService(List<Team> teams, List<Company> companies)
    {
      Teams = teams;
      Companies = companies;
    }

    public List<Team> Teams { get; } = [];

    public List<Company> Companies { get; } = [];

    public Dictionary<string, string> PerformMatching()
    {
      var matches = new Dictionary<string, string>(); // Matches between teams and companies
      var companyPreferences = new Dictionary<string, List<string>>(); // Company preferences for teams
      var proposals = new Dictionary<string, int>(); // Tracks proposals to companies to ensure progressing through preferences

      // Initialize company preferences and proposal counts
      foreach (var company in Companies)
      {
        companyPreferences.Add(company.Name, company.Preferences);
        proposals.Add(company.Name, 0);
      }

      bool allMatched;
      do
      {
        allMatched = true;
        foreach (var team in Teams.Where(t => !matches.ContainsKey(t.Name)))
        {
          allMatched = false; // If we're in this loop, not all are matched
          if (team.Preferences.Count == 0)
          {
            continue; // This team has no preferences left, can't be matched
          }

          string preferredCompany = team.Preferences[0]; // Get top preferred company
          team.Preferences.RemoveAt(0); // Remove from preferences as it's now being proposed to

          if (!companyPreferences.ContainsKey(preferredCompany))
          {
            continue; // This company doesn't exist in our preferences list
          }

          if (!matches.ContainsValue(preferredCompany))
          {
            // If the company has no matches, match them
            matches[team.Name] = preferredCompany;
          }
          else
          {
            var competingTeam = matches.FirstOrDefault(x => x.Value == preferredCompany).Key;
            var companyPrefList = companyPreferences[preferredCompany];
            // If the company prefers the proposing team over its current match
            if (companyPrefList.IndexOf(team.Name) < companyPrefList.IndexOf(competingTeam))
            {
              matches.Remove(competingTeam); // Unmatch the competing team
              matches[team.Name] = preferredCompany; // Match the proposing team
            }
          }
        }
      } while (!allMatched);

      return matches;
    }
  }
}
