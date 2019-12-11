<Query Kind="Program" />

void Main()
{
	var logs = new[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"};
	
	var result = ReorderLogFiles(logs);
	for(int i = 0;i < result.Length;i++)
	{
		Console.WriteLine(result[i]);
	}	
}

/*
You have an array of logs.  Each log is a space delimited string of words.

For each log, the first word in each log is an alphanumeric identifier.  Then, either:

Each word after the identifier will consist only of lowercase letters, or;
Each word after the identifier will consist only of digits.
We will call these two varieties of logs letter-logs and digit-logs.  It is guaranteed that each log has at least one word after its identifier.

Reorder the logs so that all of the letter-logs come before any digit-log.  The letter-logs are ordered lexicographically ignoring identifier, with the identifier used in case of ties.  The digit-logs should be put in their original order.

Return the final order of the logs.
*/
public string[] ReorderLogFiles(string[] logs)
{

	if (logs == null || logs.Length == 0)
	{
		return logs;
	}

	var answer = new string[logs.Length];
	int letterIndex = 0;
	int digitIndex = logs.Length - 1;
	for (int strIndex = logs.Length - 1; strIndex >= 0; strIndex--)
	{
		if (IsDigitLog(logs[strIndex]))
		{
			answer[digitIndex--] = logs[strIndex];
		}
		else
		{
			answer[letterIndex++] = logs[strIndex];
		}
	}

	var strComparer = new StrComparer();
	Array.Sort(answer, 0, letterIndex, strComparer);

	return answer;
}

bool IsDigitLog(string log)
{
	return Char.IsDigit(log, log.IndexOf(' ') + 1);
}

public class StrComparer : IComparer<string>
{
	int IComparer<string>.Compare(string x, string y)
	{
		var cmp = x.Substring(x.IndexOf(' ') + 1).CompareTo(y.Substring(y.IndexOf(' ') + 1));
		if (cmp == 0)
		{
			return x.CompareTo(y);
		}

		return cmp;
	}
}
