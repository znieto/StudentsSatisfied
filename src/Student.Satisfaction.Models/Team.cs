using Microsoft.VisualBasic;

namespace Student.Satisfaction.Models
{
  internal class Team
  {
    public string TeamName { get; set; }
    public Dictionary<string, Interaction> CompanyScores { get; set; }

  }
}
