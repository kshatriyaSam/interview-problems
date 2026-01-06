<Query Kind="Program" />

void Main()
{
	var input = new[] { 2, 20, 4, 10, 3, 4, 5};
	var length = LongestConsecutive(input);
}

/*
Given an array of integers nums, return the length of the longest consecutive sequence of elements that can be formed.

A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than the previous element. The elements do not have to be consecutive in the original array.

You must write an algorithm that runs in O(n) time.
*/

/*
LEARNING:
1. Problem did not care for elements to be consecutive, just the elements to be there.
2. We could have done using Sorting, but that is O(nlongn), the solution wanted O(n)
3. It was okay to create an extra memory HashSet, to find the longest sequnece.
*/
public int LongestConsecutive(int[] nums)
{

	if (nums == null || nums.Length == 0)
	{
		return 0;
	}

	var hashSet = new HashSet<int>();
	for (int i = 0; i < nums.Length; i++)
	{
		hashSet.Add(nums[i]);
	}

	int longest = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		// is it start of sequence
		var previousNum = nums[i] - 1;
		if (hashSet.Contains(previousNum))
		{
			// then not;
		}
		else
		{
			// yes it is;
			int seqLen = 1;
			var nextNum = nums[i] + 1;
			while (hashSet.Contains(nextNum))
			{
				seqLen++;
				nextNum = nextNum + 1;
				// keep iterating till we have a number in the set.
			}

			if (seqLen > longest)
			{
				// if we found a longer sequence reset it to that.
				longest = seqLen;
			}
		}
	}

	return longest;

}
