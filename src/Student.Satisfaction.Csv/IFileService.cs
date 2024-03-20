using Student.Satisfaction.Models;

namespace Student.Satisfaction.Csv
{
  public interface IFileService
  {
    CompanyTeamScores ReadCsv(string filePath);
  }
}
