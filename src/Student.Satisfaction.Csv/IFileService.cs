using Student.Satisfaction.Models.Dtos;

namespace Student.Satisfaction.Csv
{
    public interface IFileService
  {
    CompanyTeamScoresDto ReadCsv(string filePath);
  }
}
