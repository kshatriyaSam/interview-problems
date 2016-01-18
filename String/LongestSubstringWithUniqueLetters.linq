<Query Kind="Program" />

// Given a string find out the longest substring which has all unique letters, i.e. no letter is repeated.
void Main()
{
	string inputString = 
	//"abcdaecs";
	//"abcdabcd";
	//"absdfsjkloiup";
	"qwertyuiopasdfg";
	
	string result = LongestSubString(inputString);
	Console.WriteLine(result);
}

/*
Start incrementing the start and EndIndex counters and find the longest substring with unique characters
Once we reach a duplicate counter, increment StartIndex till we reach the duplicate character and remove
characters from the hash set.
Be careful to check for longest substring as last substring.
*/
static string LongestSubString(string inputString)
{
	int startIndex = 0;
	int endIndex = 0;
	int maxLength = 0;
	int maxstart = startIndex;
	int maxEnd = endIndex;
		
	HashSet<char> set = new HashSet<char>();
	while(endIndex < inputString.Length)
	{
		if(!set.Contains(inputString[endIndex]))
		{
			set.Add(inputString[endIndex++]);
		}
		else
		{
			// calculate max length and update the startIndex.
			if((endIndex - startIndex) > maxLength)
			{
				maxstart = startIndex;
				maxEnd = endIndex;
				maxLength = (endIndex) - startIndex;
			}
			
			while(inputString[startIndex] != inputString[endIndex])
			{
				set.Remove(inputString[startIndex++]);				
			}
			
			while(inputString[startIndex] == inputString[endIndex])
			{
				set.Remove(inputString[startIndex++]);				
			}			
		}
	}
	
	// if the longest string is the last string
	if((endIndex - startIndex) > maxLength)
	{
		maxstart = startIndex;
		maxEnd = endIndex;
		maxLength = (endIndex) - startIndex;
	}
	
	return inputString.Substring(maxstart, maxLength); 
}

// Define other methods and classes here
