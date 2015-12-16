<Query Kind="Program" />

/*
Count triplets with sum smaller than a given value

Given an array of distinct integers and a sum value. Find count of triplets with sum smaller than given sum value. Expected Time Complexity is O(n2).
*/

void Main()
{
	var arr = new int[] {2, 5, 6, 1, 3, 0};
	int sum = 4;
	Console.WriteLine(CountTriplets(arr, sum));
}

/*
	Sort the Array and pivot the starting element.
	Then run two pointers from pivot+1 and end
*/
public static int CountTriplets(int[] arr, int sum)
{
	Array.Sort(arr);
	
	int ans = 0;
	for (int i = 0;i < arr.Length -2; i++)
	{
		int j = i+1;
		int k = arr.Length -1;
		
		while(j < k)
		{
			if( arr[i] + arr[j] + arr[k] > sum)
			{
				k--;
			}
			else
			{
				ans += (k-j);
				j++;
			}
		}
	}
	
	return ans;
	
}


