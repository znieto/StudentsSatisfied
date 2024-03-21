using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Satisfaction.Matcher
{
  internal class OutputService
  {
    public void DisplayMatches(Dictionary<string, string> matches)
    {
      // Output matches
      foreach (var match in matches)
      {
        Console.WriteLine($"Team {match.Key} is matched with Company {match.Value}");
      }
    }
  }
}
