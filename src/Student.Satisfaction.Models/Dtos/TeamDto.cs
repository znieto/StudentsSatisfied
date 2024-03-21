namespace Student.Satisfaction.Models.Dtos
{
  public class TeamDto
  {
    public string TeamName { get; set; }
    public Dictionary<string, ScoreDto> CompanyScores { get; set; } = [];

  }
}
