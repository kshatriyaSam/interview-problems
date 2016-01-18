<Query Kind="Program" />

//rotate a string of length n by m characters with constant extra space in linear time (wrt n)

void Main()
{   
    //0 1 2 3 4 5 6 7 8 9 10 11 12 13
	string stringToRotate = "hellohowareyoudoing";
	int m = -5;
	int lengthOfString = stringToRotate.Length;
	
	if(!ValidateInputs(stringToRotate,m))
	{
		return;
	}
	
	if (m > lengthOfString || -m > lengthOfString)
	{
		m = m % lengthOfString;
	}	
	
	if (m < 0)
	{
		m = lengthOfString + m;		
	}	
	
	char[] charArrayOfString = stringToRotate.ToCharArray();
	
	RotateSubString(charArrayOfString, 0, lengthOfString -1);
	RotateSubString(charArrayOfString, 0, m -1 );
	RotateSubString(charArrayOfString, m, lengthOfString -1);
	
	Console.WriteLine(string.Join("", charArrayOfString));
}

static bool ValidateInputs(string stringToRotate, int m)
{
	if(string.IsNullOrWhiteSpace(stringToRotate))
	{
		Console.WriteLine("Null Or Empty String");
		return false;
	}
	
	if (m == 0)
	{
		Console.WriteLine("No string to rotate");
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
