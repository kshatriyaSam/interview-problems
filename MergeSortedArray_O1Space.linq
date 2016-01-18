<Query Kind="Program" />

/*
e need to merge these two arrays such that the initial numbers 
(after complete sorting) are in the first array and the remaining numbers are in the second array. Extra space allowed in O(1).
*/
void Main()
{
	var first = new int[] {3, 7, 8, 11};
	var second = new int[] { 4, 5, 9, 12};
	
	MergeSortedArray(first, second);
	
	Console.WriteLine("First {0}", string.Join(",", first));
	Console.WriteLine("Second {0}", string.Join(",", second));
}

/*
	Start from the last element of the Second Array and save the last element of the
	First Array. Find the right place by shifting element right in the First Array
	Then replace the Element in the Second Array with the Last Element of the First Array.
*/
public void MergeSortedArray(int[] firstArray, int[] secondArray)
{
	for(int i = secondArray.Length - 1; i >=0; i--)
	{
		int last = firstArray[firstArray.Length - 1];
		
		int j;
		for(j = firstArray.Length - 1; j >= 0 && firstArray[j] > secondArray[i]; j--)
		{
			// move right elements in first array
			firstArray[j] = firstArray[j-1];
		}
		
		if( j != firstArray.Length -1)
		{
			firstArray[j + 1] = secondArray[i];
			secondArray[i] = last;
		}
	}
	
}
