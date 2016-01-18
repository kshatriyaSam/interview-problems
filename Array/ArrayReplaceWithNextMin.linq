<Query Kind="Program" />

// Given an integer array replace each number with its next minimum number in the array. 
// For example if input array is {3,4,2,6,5,1,8,4} output would be {2,2,1,5,1,0,4,0}


// Solution:
// Create Stack, once we reach the lower number, pop all elements till it is empty
void Main()
{
	int[] inputArray = { 3, 4, 2, 6, 5, 1, 8, 4 };
    ReplaceWithNextMin(inputArray);
	
	foreach(int i in inputArray)
	{
		Console.Write("{0},", i);
	}
}

// start with rightmost element
// if stack is empty add to stack
// 
static void ReplaceWithNextMin(int[] inputArray)
{
	Stack current = new Stack();
	current.Push(inputArray[inputArray.Length - 1]);
	
	inputArray[inputArray.Length -1] = 0;
	int top;
	for (int i = inputArray.Length - 2; i >= 0; i--)
	{
		int next = inputArray[i];
		top = (int)current.Peek();
		
		if (next > top)
		{
			inputArray[i] = top;
			current.Push(next);
		}
		else
		{
			while(current.Count != 0 && next < (int)current.Peek())
			{
				current.Pop();
			}
			
			if(current.Count == 0)
			{
				inputArray[i]= 0;
				current.Push(next);
			}
			else
			{
				top = (int)current.Peek();
				inputArray[i] = top;
				current.Push(next);
			}
		}
	}
}

// Define other methods and classes here
