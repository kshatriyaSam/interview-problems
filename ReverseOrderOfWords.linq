<Query Kind="Program" />

//  reverse the order of the words (not the characters) in a string of length n in with constant extra space in linear time
// Approach:
// Reverse individual strings, then reverse the entire string
void Main()
{
	string reverseWords = "he    lo";
	
	char[] stringToReverse = reverseWords.ToCharArray();
	ReverseWord(stringToReverse);
	
	RotateSubString(stringToReverse, 0, stringToReverse.Length -1);
	Console.WriteLine(string.Join("", stringToReverse));
	
	string resultString = "you are how hello";
	
}

static void ReverseWord(char[] stringToReverse)
{
	int pos = 0;
	
	while(pos != stringToReverse.Length && stringToReverse[pos] == ' ')
	{
		pos++;
	}
	
	int start = pos;
	while(pos <= stringToReverse.Length)
	{
	  if(pos == stringToReverse.Length || stringToReverse[pos] == ' ')
	  {
	    RotateSubString(stringToReverse, start, pos -1);
		while(pos != stringToReverse.Length && stringToReverse[pos] == ' ')
		{
		  pos++;
		}
		
		start = pos;
	  }
	  
	  pos++;
	}	
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

// Define other methods and classes here
