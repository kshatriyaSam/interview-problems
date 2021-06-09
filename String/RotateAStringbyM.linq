<Query Kind="Program" />

//rotate a string of length n by m characters with constant extra space in linear time (wrt n)


// Test Cases
// 1. null String
// 2. Empty String 
// 3. M > N
// 4. M < 0
// 5. M == 0
// 6. M == -Infinity || M == + Infinity
// 7. Very Large String greater thant Int32.MaxValue
// 8. String with all Identical char
// 9. String with all Vowels
// 10. Even Length String
// 11. Odd Length String
// 12. String with Unicode chars

void Main()
{
	//0 1 2 3 4 5 6 7 8 9 10 11 12 13
	string[] data = new[] { "hellohowareyoudoing", "", "  ", null, "aeiou", "hhhhhh", "@3#$^2^", "hello"};
	
	int[] testCases = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 21, 25, -1, -3, -6, -15, -200, int.MaxValue};

	for (int i = 0; i < data.Length; i++)
	{
		Console.WriteLine($"=================Input: `{data[i]?? null}`=================");
		foreach (int m in testCases)
		{
			var result = RotateStringByM(data[i], m);
			Console.WriteLine($"M = {m}, Result : {result}");
		}
		Console.WriteLine($"=================Done: `{data[i] ?? null}`=================");
	}
}

static string RotateStringByM(string stringToRotate, int m)
{
	if (!ValidateInputs(stringToRotate, m))
	{
		return "invalid input";
	}
	
	// length should be peeked after we validated inputs
    int lengthOfString = stringToRotate.Length;

	if (m >= lengthOfString || -m >= lengthOfString)
	{
		m = m % lengthOfString;
	}

    // dont need to rotate anythiung
	if (m == 0)
    {
		return stringToRotate;		
	}

	if (m < 0)
	{
		m = lengthOfString + m;
	}

	char[] charArrayOfString = stringToRotate.ToCharArray();

	RotateSubString(charArrayOfString, 0, lengthOfString - 1);
	RotateSubString(charArrayOfString, 0, m - 1);
	RotateSubString(charArrayOfString, m, lengthOfString - 1);
	
	return new string(charArrayOfString);
}

static bool ValidateInputs(string stringToRotate, int m)
{
	if(string.IsNullOrWhiteSpace(stringToRotate))
	{
		Console.WriteLine("Null Or Empty String");
		return false;
	}
	
	return true;
}

static void RotateSubString(char[] stringArray, int startPos, int endPos)
{
	int pos = 0;
	int lengthOfSub = endPos - startPos;
	
	while(pos <= (lengthOfSub / 2))
	{
	  char tempChar = stringArray[startPos + pos];
	  stringArray[startPos + pos] = stringArray[endPos - pos];
	  stringArray[endPos - pos] = tempChar;
	  pos++;
	}
}
