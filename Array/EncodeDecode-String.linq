<Query Kind="Program" />

void Main()
{
	var encodeData = Encode(new[] {"we","say",":","yes","!@#$%^&*()"});
	encodeData.Dump();
	var decodeResult = Decode(encodeData);
	decodeResult.Dump();
}

public string Encode(IList<string> strs)
{
	if (strs == null)
	{
		return null;
	}
	var encoderBuilder = new StringBuilder();
	foreach (var str in strs)
	{
		encoderBuilder.Append(str.Length);
		//NOTE: Capture the character to denote end of length
		encoderBuilder.Append(".");
		encoderBuilder.Append(str);
	}

	return encoderBuilder.ToString();

}

// You can define other methods, fields, classes and namespaces here
public List<string> Decode(string s)
{
	if (s == null)
	{
		return null;
	}
	var result = new List<string>();
	if (string.IsNullOrEmpty(s))
	{
		return result;
	}	

	int i = 0;
	
	do
	{
		Console.WriteLine($"Start : i={i}, {s[i]}");		
		// NOTE::identify the count, which can be more than 1 character long
		int lengthOfNextString = GetLength(s, i);
		int numberOfDigits = lengthOfNextString.ToString().Length;
		if (lengthOfNextString == 0)
		{
			result.Add(string.Empty);
		}
		else
		{
			Console.WriteLine($"Substring i={i}, {lengthOfNextString}, {numberOfDigits}");
			// NOTE: StartIndex is i + 1 (for the .) + number of Digits
			var encodedString = s.Substring(i + numberOfDigits + 1, lengthOfNextString);
			result.Add(encodedString);
		}
		i = i + lengthOfNextString + numberOfDigits + 1;
	} while (i < s.Length);

	return result;
}

int GetLength(string s, int startIndex)
{
	var numData = string.Empty;
	for (int j = startIndex; s[j] != '.'; j++)
	{
		numData += s[j];
	}
	Console.WriteLine(numData);
	return Convert.ToInt32(numData);
}
