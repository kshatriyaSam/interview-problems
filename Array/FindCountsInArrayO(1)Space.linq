<Query Kind="Program" />

/*
	Find the count of Frequencies of an element in O(1) space and O(n) time
	
	The input array will Only contain elements between 1 and n
*/
void Main()
{
	FindCountsInArray(new [] {4,4,4,4});
}

/*
Frequency can be found using Hashtable and incrementing, but we need to do this in 
O(1) space.
*/
void FindCountsInArray(int[] array)
{

	// bring the elements in range of 0 to n-1 from 1 -n
	for(int i =0 ; i < array.Length; i++)
	{
		array[i] = array[i] -1;	
	}
	
	int n = array.Length;
	for(int i =0 ; i < array.Length; i++)
	{
		array[array[i] %n] = array[array[i] % n] + n;
	}
	
	for(int i =0 ; i < array.Length; i++)
	{
		// there will be some elements which did not even occur.
		if(array[i] >= n)
		{
			Console.WriteLine("{0} -> {1}", i + 1, array[i] /n);
		}
	}
}
