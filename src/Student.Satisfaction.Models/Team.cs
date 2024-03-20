namespace Student.Satisfaction.Models
{
  public class Team
  {
    public string TeamName { get; set; }
    public Dictionary<string, Score> CompanyScores { get; set; } = [];

  }
}
