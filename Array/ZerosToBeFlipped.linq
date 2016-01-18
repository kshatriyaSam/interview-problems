<Query Kind="Program" />

// find zeros to be flipped to maximize consecutive 1's
/*
	Given a binary array and an integer m, find the position of zeroes flipping which creates maximum number of consecutive 1s in array.
*/

void Main()
{ 
 	int[] arr = new int[] {1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1};
	int m = 2;
	
	MaximizeConsecutive1s(arr, 2);
 
}

public static void MaximizeConsecutive1s(int[] arr, int m)
{
	int currentCount = 0;
	int maxCount = 0;
	List<int> maxPosition = new List<int>();
	List<int> positions = new List<int>();
	for (int i = 0;i < arr.Length; i++)
	{
		if (arr[i] == 1)
		{
			currentCount++;						
		}
		else if(arr[i] == 0)
		{
			if (positions.Count == m)
			{
				// then we need to store the max 1s and list if 
				// it is the greatest till now and remove the First element.
				if(currentCount > maxCount)
				{
					maxCount = currentCount;
					maxPosition = new List<int>(positions);					
				}
				
				int index = positions.First();
				positions = new List<int>();
				
				i = index; 
				currentCount = 0;
			}
			else
			{
				// add elements to the positions array
				positions.Add(i);
				currentCount++;
			}
		}
	}
	
	if(currentCount > maxCount)
	{
		maxCount = currentCount;
		maxPosition = new List<int>(positions);
	}
	
	Console.WriteLine("Max Consecutive 1s: {0} and index: {1}", maxCount, string.Join(",", maxPosition.Select(j => j.ToString()).ToArray()));
}

// Define other methods and classes here
