using Student.Satisfaction.Matcher;

string csvFilePath = "C:\\temp\\studentdompany3.csv";
var studentMatch = new StudentMatchService(csvFilePath);
studentMatch.Process();



