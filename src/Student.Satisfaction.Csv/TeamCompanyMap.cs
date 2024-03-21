using CsvHelper.Configuration;
using Student.Satisfaction.Models.Dtos;

namespace Student.Satisfaction.Csv
{
    internal class TeamCompanyMap: ClassMap<CompanyTeamScoresDto>
  {
    public TeamCompanyMap() { 
    
    }
  }
}
