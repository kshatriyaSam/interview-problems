<Query Kind="Program" />

void Main()
{
	var input = new List<int[]>();
	input.Add(new[] { 1, -2, 2, 1, 3});
	input.Add(new[] {7, 7, 7, 7});
	input.Add(new[] {1,2,3,4,5,6});
	input.Add(new[] {1,2,1,2,5,6});
	
	foreach(var d in input)
	{
		var result = TopKFrequent(d, 2);
		Console.WriteLine("================================");
		result.Dump();
		Console.WriteLine("================================");
	}
}

/*
Given an integer array nums and an integer k, return the k most frequent elements within the array.

The test cases are generated such that the answer is always unique.

You may return the output in any order.
*/
public int[] TopKFrequent(int[] nums, int k)
{

	if (nums == null)
	{
		throw new ArgumentNullException(nameof(nums));
	}

	if (k < 0)
	{
		throw new ArgumentException($"The value of {k} must be non-negative");
	}

	// build a hashset which stores the count of the values
	var kfrequency = new Dictionary<int, int>();
	foreach (var num in nums)
	{
		if (kfrequency.ContainsKey(num))
		{
			kfrequency[num] = kfrequency[num] + 1;
		}
		else
		{
			kfrequency[num] = 1;
		}
	}

	// put elements into buckets based on frequency
	// NOTE::remember to allocate more space as all the elements can be the same.
	var bucketList = new List<int>[nums.Length+1];
	foreach (var element in kfrequency)
	{
		if (bucketList[element.Value] == null)
		{
			var newList = new List<int>();
			newList.Add(element.Key);
			bucketList[element.Value] = newList;
		}
		else
		{
			bucketList[element.Value].Add(element.Key);
			
		}
	}

	// build the output result array
	var result = new List<int>();
	int counter = 0;
	for (int i = nums.Length; i >= 0; i--)
	{
		if (bucketList[i] != null)
		{
			result.AddRange(bucketList[i]);
			// NOTE:: remember to increment the counter by the number of elements added.
			counter = counter + bucketList[i].Count;
		}

		if (counter >= k)
		{
			break;
		}
	}

	return result.ToArray();

}
