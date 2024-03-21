namespace Student.Satisfaction.Models.Dtos
{
  public class CompanyDto
  {
    public string CompanyName { get; set; }
    public Dictionary<string, int?> TeamScores { get; set; } = [];

  }
}
