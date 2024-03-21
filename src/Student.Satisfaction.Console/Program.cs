using Student.Satisfaction.Matcher;

string csvFilePath = Environment.GetCommandLineArgs()[1];
Console.WriteLine($"File to process, {csvFilePath}!");

var studentMatch = new StudentMatchService(csvFilePath);
studentMatch.Process();



