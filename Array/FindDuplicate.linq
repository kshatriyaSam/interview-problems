<Query Kind="Program" />

//Given an array of size N that contains values between 1 and N-1, find the duplicate element (assuming there is only one).
//If it contains values between 1 and N+1, how would you find the missing element (again assuming there is only one missing)
// e.g [ 1, 2, 3, 2]
// e.g.[ 1, 2, 4, 5]
void Main()
{
	int[] arrayData = {1,2,4,5};
	//Console.WriteLine(FindDuplicate(arrayData));
	Console.WriteLine(FindMissing(arrayData));
}

static int FindDuplicate(int[] arrayData)
{
	int missingElement =0;
	for(int i =0;i < arrayData.Length; i++)
	{
		missingElement ^= arrayData[i];
	}
	
	return missingElement;
}

static int FindMissing(int[] arrayData)
{
	int missing = FindDuplicate(arrayData);
	int notMissing = ~missing;
	return notMissing * -1;
}

// Define other methods and classes here
