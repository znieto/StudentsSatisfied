using Student.Satisfaction.Csv;

namespace Student.Satisfaction.Matcher
{
  public class StudentMatchService
  {
    private readonly string csvFilePath;
    private readonly CsvService csvService = new CsvService();
    public StudentMatchService(string csvFilePath) => this.csvFilePath = csvFilePath;

    public void ProcessCsv()
    {
      csvService.ReadCsv(csvFilePath);

    }
  }
}
