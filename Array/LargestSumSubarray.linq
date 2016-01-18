<Query Kind="Program" />

// Given an integer array find the subarray which has the largest sum.
void Main()
{
 	int[] array = {-1, -3, -4, -5, 9, -3, 9, -2, -4, 1};
	LargestSumSubarray(array);
}

static void LargestSumSubarray(int[] array)
{
	int startIndex = 0;
	int maxStartIndex = 0;
	int maxEndIndex = 0;
	long maxSum = array[startIndex];
	long subSum = maxSum;
	
	for (int i = 1; i < array.Length; i++)
	{
	    subSum += array[i];
		if(subSum > maxSum)
		{
			maxStartIndex = startIndex;
			maxEndIndex = i;
			maxSum = subSum;
		}
		
		if (subSum < array[i])
		{
			startIndex = i;
			subSum = array[i];
			
			if (subSum > maxSum)
			{
				maxSum = subSum;
				maxStartIndex = startIndex;
				maxEndIndex = startIndex;
			}
		}
	}
	
	Console.WriteLine("Start: {0} End: {1}, Sum: {2}", maxStartIndex, maxEndIndex, maxSum);
}

// Define other methods and classes here
