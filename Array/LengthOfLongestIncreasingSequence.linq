<Query Kind="Program" />

/*
Given an unsorted array of integers, find the length of longest increasing subsequence.

For example,
Given [10, 9, 2, 5, 3, 7, 101, 18],
The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. 
Note that there may be more than one LIS combination, it is only necessary for you to return the length.
*/
void Main()
{
	var array = new int[] {0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15};
	
	Console.WriteLine(LengthOfLongestIncreasingSub(array));
}

public int findPositionToReplace(int[] a, int low, int high, int x) 
{
    int mid;
    while (low <= high) 
	{
        mid = low + (high - low) / 2;
        if (a[mid] == x)
		{
            return mid;
		}
        else if (a[mid] > x)
		{
            high = mid - 1;
		}
        else
		{
            low = mid + 1;
		}
    }
	
    return low;
}

public int LengthOfLongestIncreasingSub(int[] nums)
{
    if (nums == null || nums.Length == 0)
        return 0;

	int n = nums.Length, len = 0;
    int[] increasingSequence = new int[n];
    increasingSequence[len++] = nums[0];
    
	for (int i = 1; i < n; i++)
	{
        if (nums[i] > increasingSequence[len - 1])
		{
            increasingSequence[len++] = nums[i];
		}
        else
		{
            int position = findPositionToReplace(increasingSequence, 0, len - 1, nums[i]);
            increasingSequence[position] = nums[i];
        }
    }
	
    return len;
}
// Define other methods and classes here
