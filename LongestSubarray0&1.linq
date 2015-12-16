<Query Kind="Program" />

// Longest subarray containing equal number of 1's and 0's
void Main()
{
	int[] inputArray =
	//{1,0,1,1,0,0,1,0,1,1,1,1,0,0};
	//{0,0,0,0,1,1};
	{0,1,0,1,1};
	var result = LongestSubarray(inputArray);
	
	Console.WriteLine("Length : {0}", result.Length);
	for(int i =0;i < result.Length; i++)
	{
		Console.Write("{0},", result[i]);
	}
}

static int[] LongestSubarray(int[] inputArray)
{
	int endIndex = 0;
	int sumIndex = 0;
	int maxLen = 0;
	int maxStart = 0;
	int maxEnd = 0;
	
	// dictionary of sum, first index
	Dictionary<int, int> set = new Dictionary<int, int>();
	//set.Add(0, 0); // whenever the sumIndex is Zero, we will compare with starting.
	
	while(endIndex < inputArray.Length)
	{
		sumIndex += (inputArray[endIndex] == 1 ? 1 : -1);
	
		if(sumIndex == 0)
		{
			if(endIndex + 1 > maxLen)
			{
				maxLen = endIndex + 1;
				maxStart = 0;
				maxEnd = endIndex;
			}
		}
		else if(!set.ContainsKey(sumIndex))
		{
			set.Add(sumIndex, endIndex);	
		}		
		else
		{
			int firstIndex = set[sumIndex];
			if((endIndex - firstIndex) + 1 > maxLen)
			{
				maxLen = (endIndex - firstIndex);
				maxStart = firstIndex;
				maxEnd = endIndex;
			}
		}
		
		endIndex++;		
	}
	
	int[] result = new int[maxLen];
	for(int i = maxStart; i <= maxEnd && maxLen != 0; i++)
	{
		result[i - maxStart] = inputArray[i];
	}	
	
	return result;
}

// Define other methods and classes here
