using CsvHelper.Configuration;
using Student.Satisfaction.Models;

namespace Student.Satisfaction.Csv
{
  internal class TeamCompanyMap: ClassMap<CompanyTeamScores>
  {
    public TeamCompanyMap() { 
    
    }
  }
}
