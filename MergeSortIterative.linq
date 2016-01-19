<Query Kind="Program" />

void Main()
{
	var input = new int[] { 7, 6, 5, 2, 4};
	MergeSortIterative(input);
	
	input.Dump();
}

/*
Start with 2 elements, and iterate through the array.
Then select 4 elements array .. 8  and so on.

It sorts both odd and Even Array
For Odd Array the Last element will not be touched on first iteration, 
but it will eventually come when {2,5,6,7} {4}
*/
public void MergeSortIterative(int[] array)
{
	for (int i = 1; i < array.Length; i = i + i)
	{
		for(int j = 0 ; j < array.Length - i ; j += i + i)
		{
			int low = j;
			int mid = j + i - 1;
			int high = Math.Min( j + 2*i -1, array.Length -1);
			Merge(array, low, mid, high);
		}
	}
}

public void Merge(int[] array, int low, int mid, int end)
{
	var merge = new int[end - low + 1];
	
	int l = low; 
	int r = mid + 1;
	int k = 0;
	for(k = 0; k < end - low + 1; k++)
	{
		if(l > mid) 
		{
			// if the first array is exhausted
			merge[k] = array[r++];
		}
		else if(r > end) 
		{
			// if the second array is exhausted
			merge[k] = array[l++];
		}
		else if(array[l] > array[r]) 
		{
			// select the greater of the two array
			merge[k] = array[r++];
		}
		else
		{			
			merge[k] = array[l++];
		}
	}
		
	// Array.Copy to original array
	Array.Copy(merge, 0, array, low, merge.Length);
}
