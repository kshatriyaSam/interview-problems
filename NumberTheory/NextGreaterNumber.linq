<Query Kind="Program" />

/*
Find next greater number with same set of digits
*/
void Main()
{
	NextGreaterNumber("34765432".ToCharArray());
}

// Define other methods and classes here
void NextGreaterNumber(char[] input)
{
	// traverse from right to left to point where number is decreasing
	
	int i = 0;
	for(i = input.Length - 1; i > 0; i--)
	{
		if(input[i]> input[i-1])
		{
			break;
		}
	}
	
	if(i == 0)
	{
		Console.WriteLine("Cannot find a greater number");
		return;
	}
	
	int smaller = i - 1;
	
	// find the smallest number greater than input[smaller] in the right half of the array
	
	int smallest = i;
	for(int j = i + 1; j < input.Length;j++)
	{
		if(input[j] > input[smaller] && input[smallest] > input[j])
		{
			smallest = j;
		}
		else
		{
			break;
		}
	}
	
	Swap(input, smaller, smallest);
	
	// Sort elements from i + 1 to n
	Array.Sort(input, i, input.Length - i);
	
	Console.WriteLine("{0}", string.Join("", input));
}


void Swap(char[] input, int i, int j)
{
	var temp = input[i];
	input[i] = input[j];
	input[j] = temp;
}