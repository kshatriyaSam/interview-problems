<Query Kind="Program" />

void Main()
{
	var inputArray = new int[] { -1, 2, 3, 4,-1, 7};
	
	var output = LargestSumContiguousSub(inputArray);
	Console.WriteLine("Output : {0}", output);
}

// Define other methods and classes here
int LargestSumContiguousSub(int[] array)
{
	if(array == null || array.Length == 0)
	{
		throw new ArgumentException("array");
	}

	int maxSum = array[0];
	int sumTillNow = maxSum;
	
	for(int i = 1; i < array.Length; i++)
	{
		sumTillNow += array[i];
		
		if(sumTillNow < array[i])
		{
			sumTillNow = array[i];
		}
		
		if( sumTillNow > maxSum)
		{
			maxSum = sumTillNow;
		}
	}
	
	return maxSum;

}
