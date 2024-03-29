﻿using CsvHelper;
using CsvHelper.Configuration;
using Student.Satisfaction.Models.Dtos;
using System.Globalization;
using System.Text;

namespace Student.Satisfaction.Csv
{
  public class CsvService : IFileService
  {
    public CompanyTeamScoresDto ReadCsv(string filePath)
    {
      if (!File.Exists(filePath))
      {
        Console.WriteLine($"The file {filePath} does not exist.");
        return null;
      }
      using var reader = new StreamReader(filePath);
      using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = ";",
        Encoding = Encoding.UTF8,
        MissingFieldFound = null,
        HeaderValidated = null,
        IgnoreBlankLines = true,
      });


      csv.Read();
      csv.ReadHeader();
      var data = new CompanyTeamScoresDto();
      csv.HeaderRecord.Skip(1); // Skip the first header cell ("Team/Company")

      // Reading each row
      while (csv.Read())
      {
        string teamName = csv.GetField(0);
        var team = new TeamDto { TeamName = teamName }; // The first field is the team name

        for (int i = 1; i < csv.HeaderRecord.Length; i++)
        {
          string companyName = csv.HeaderRecord[i] ?? string.Empty;
          var score = CreateTeam(csv, team, i, companyName);
          CreateCompany(data, teamName, companyName, score);
        }

        data.Teams.Add(team);
      }

      return data;

    }

    private static ScoreDto CreateTeam(CsvReader csv, TeamDto team, int i, string companyName)
    {
      string field = csv.GetField(i);
      var score = ParseScore(field);
      team.CompanyScores.Add(companyName, score.CompanyScore);
      return score;
    }

    private static void CreateCompany(CompanyTeamScoresDto data, string teamName, string companyName, ScoreDto score)
    {
      var company = data.Companies.FirstOrDefault(c => c.CompanyName == companyName);

      if (company != null)
      {
        company.TeamScores.Add(teamName, score.TeamScore);
      }
      else
      {
        var companyDto = new CompanyDto()
        {
          CompanyName = companyName
        };
        companyDto.TeamScores.Add(teamName, score.TeamScore);
        data.Companies.Add(companyDto);
      }
    }

    private static ScoreDto ParseScore(string field)
    {
      if (string.IsNullOrWhiteSpace(field))
      {
        return new ScoreDto(); // Empty interaction
      }
      else if (field.Contains(","))
      {
        // It's a pair of values
        var parts = field.Split(',');
        _ = int.TryParse(parts[0], out int value1);
        _ = int.TryParse(parts[1], out int value2);
        return new ScoreDto { TeamScore = value1, CompanyScore = value2 };
      }
      else
      {
        // It's a single value
        int.TryParse(field, out int intValue);
        return new ScoreDto { CompanyScore = intValue, TeamScore = intValue };
      }
    }
  }

}
