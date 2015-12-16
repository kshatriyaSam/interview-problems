<Query Kind="Program" />

// Given an array of integers, find the maximum and minimum of the array.
void Main()
{
FindMinMaxArray(new int[] { -11, -11, -11, -11, -11, -11, -11, 10, -12});	
}

static void FindMinMaxArray(int[] array)
{
	int max = array[0];
	int min = array[0];
	int i =0;
	for(; i < array.Length /2; i++)	
	{
		int num1 = array[i*2];
		int num2 = array[i*2 +1];
		if (num1 >= num2)
		{
			if (num1 > max)
			{
				max = num1;
			}
			if (num2 < min)
			{
				min = num2;
			}		
		}
		else
		{
			if (num1 < min)
			{
				min = num1;
			}
			
			if (num2 > max)
			{
				max = num2;
			}
		}	
	}
	
	if (i*2 < array.Length)
	{
		int num = array[i*2];
		if (num > max)
		{
			max = num;
		}
		
		if (num < min)
		{
			min = num;
		}
	}
	
	Console.WriteLine("Min: {0} ; Max: {1}", min, max);
}

// Define other methods and classes here
