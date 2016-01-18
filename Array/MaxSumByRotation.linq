<Query Kind="Program" />

/*
Find maximum value of Sum( i*arr[i]) with only rotations on given array allowed
*/

void Main()
{
	
}

/*Solution
Let us calculate initial value of i*arr[i] with no rotation
R0 = 0*arr[0] + 1*arr[1] +...+ (n-1)*arr[n-1]

After 1 rotation arr[n-1], becomes first element of array, 
arr[0] becomes second element, arr[1] becomes third element
and so on.
R1 = 0*arr[n-1] + 1*arr[0] +...+ (n-1)*arr[n-2]

R1 - R0 = arr[0] + arr[1] + ... + arr[n-2] - (n-1)*arr[n-1]

After 2 rotations arr[n-2], becomes first element of array, 
arr[n-1] becomes second element, arr[0] becomes third element
and so on.
R2 = 0*arr[n-2] + 1*arr[n-1] +...+ (n?1)*arr[n-3]

R2 - R1 = arr[0] + arr[1] + ... + arr[n-3] - (n-1)*arr[n-2] + arr[n-1]

If we take a closer look at above values, we can observe 
below pattern

Rj - Rj-1 = arrSum - n * arr[n-j]

Where arrSum is sum of all array elements, i.e., 

arrSum = ∑ arr[i]
        i<=0<=n-1 
*/

public static int MaxSumByRotation(int[] arr)
{
	int arrSum =0
	for (int i = 0; i < arr.Length; i++)
	{
		arrSum += arr[i];	
	}
	
	long R0 = 0;
	for (int i = 0; i< arr.Length;i++)
	{
		R0 += (i * arr[i]);
	}
	 
	int maxValue = R0;
	int currentVal = maxValue;
	
	for (int j = 1 ; j < arr.Length;j++)
	{
		currentVal = currentVal + arrSum - arr.Length * (arr[arr.Length - j]);
		
		if (currentVal > maxValue)
		{
			maxValue = currentVal;
		}		
	}
	
	Console.WriteLine(maxValue);
}
