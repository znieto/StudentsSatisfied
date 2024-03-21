namespace Student.Satisfaction.Models.Dtos
{
  public class TeamDto
  {
    public string TeamName { get; set; }
    public Dictionary<string, int?> CompanyScores { get; set; } = [];

  }
}
