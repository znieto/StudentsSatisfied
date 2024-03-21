using Student.Satisfaction.Matcher;

string csvFilePath = "C:\\temp\\studentdompany.csv";
var studentMatch = new StudentMatchService(csvFilePath);
studentMatch.ProcessCsv();



