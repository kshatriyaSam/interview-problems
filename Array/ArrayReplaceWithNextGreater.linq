<Query Kind="Program" />

// Given an array, print the Next Greater Element (NGE) for every element. 
// The Next greater Element for an element x is the first greater element on the right side of x in array. 
// Elements for which no greater element exist, consider next greater element as -1.
// [ 12, 4, 7, 13, 9, 2, 8 ] => [ 13, 7, 8, -1, -1, 8, -1]

void Main()
{
	int[] input = {12, 4, 7, 13, 9, 2, 8};
	//int[] input = { 13, 7, 5, 6, 12 };
	NextGreaterElement2(input);
	
	foreach(int data in input)
	{
		Console.Write("{0},", data);
	}	
}

static void NextGreaterElement(int[] inputArray)
{
	Stack current = new Stack();
	current.Push(inputArray[inputArray.Length - 1]);
	
	inputArray[inputArray.Length - 1] = -1;
	
	int top;
	for(int i = inputArray.Length - 2; i >=0;i--)
	{
		int next = inputArray[i];
		top = (int)current.Peek();
		
		if (top > next)
		{
			inputArray[i] = top;
			current.Push(next);
		}
		else
		{	
			while(current.Count != 0 && (int)current.Peek() < next)
			{
				current.Pop();
			}
			
			if (current.Count == 0)
			{
				inputArray[i] = -1;
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


/* prints element and NGE pair for all elements of
arr[] of size n */
static void NextGreaterElement2(int[] arr)
{
    int i = 0;
    Stack current = new Stack();
    int element, next;
 
    /* push the first element to stack */
    current.Push(arr[0]);
 
    // iterate for rest of the elements
    for (i=1; i<arr.Length; i++)
    {
        next = arr[i];
 
        if (current.Count != 0)
        {
            // if stack is not empty, then pop an element from stack
            element = (int)current.Pop();
 
            /* If the popped element is smaller than next, then
                a) print the pair
                b) keep popping while elements are smaller and
                stack is not empty */
            while (element < next)
            {
                Console.WriteLine("{0} --> {1}", element, next);
                if(current.Count == 0)
                   break;
                element = (int)current.Pop();
            }
 
            /* If element is greater than next, then push
               the element back */
            if (element > next)
                current.Push(element);
        }
 
        /* push next to stack so that we can find
           next greater for it */
        current.Push(next);
    }
 
    /* After iterating over the loop, the remaining
       elements in stack do not have the next greater
       element, so print -1 for them */
    while (current.Count != 0)
    {
        element = (int)current.Pop();
        next = -1;
        Console.WriteLine("{0} --> {1}", element, next);
    }
}
// Define other methods and classes here
