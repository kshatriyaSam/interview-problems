<Query Kind="Program" />

// Implement a stack which provides an efficient get minimum function along with regular push and pop functionality.
// There are 2 approaches to solving the problem
/* First approach with Extra Stack with maintains the current minimum along with the 
regular data stack
Second approach which stores the minimum in just one variable min and the element inserted to the 
top of the stack is 2 value - prev minimum. In this way we save the previous minimum
*/
void Main()
{
	int[] dataArray = {4, 3, 5, 6, 2, 7 };
	//MinimumStack minStack = new MinimumStack();
	MinimumStack2 minStack = new MinimumStack2();
	
	foreach(int data in dataArray)
	{
		minStack.Push(data);		
	}	
	
	foreach(int data in dataArray)
	{
		Console.WriteLine("{0} => {1}", minStack.Min(), minStack.Pop());			
	}    
}


// with O(1) extra space for minimum value
public class MinimumStack2
{
	Stack dataStack;
	int miniMum;
	
	public MinimumStack2()
	{
		dataStack = new Stack();
		miniMum = Int32.MaxValue;
	}
	
	public void Push(int value)
	{
		if (value < miniMum)
		{
			int data = 2 * value - miniMum;
			miniMum = value;
			dataStack.Push(data);
		}
		else
		{
			dataStack.Push(value);
		}	
	}
	
	public int Pop()
	{
		if(dataStack.Count == 0)
		{
			throw new InvalidOperationException("Data stack is empty");
		}
		
		int valueToReturn;
		int top = (int)dataStack.Peek();
		if(top < miniMum) 
		{
			// This means that the top of stack is minimum Value.
			int nextMin = 2 * miniMum - top;
			valueToReturn = miniMum;
			miniMum = nextMin;			
			dataStack.Pop();			
		}
		else
		{
			valueToReturn = (int)dataStack.Pop();
		}
		
		return valueToReturn;
	}
	
	public int Min()
	{
		if(dataStack.Count == 0)
		{
			throw new InvalidOperationException("Data Stack is Empty");
		}
		
		return miniMum;
	}	
}

// with auxiliary Stack
public class MinimumStack
{
	Stack dataStack;
	Stack minStack;
	
	public MinimumStack()
	{
		dataStack = new Stack();
		minStack = new Stack();
	}
	
	public void Push(int value)
	{
		if (minStack.Count != 0 && value < (int)minStack.Peek())
		{
			minStack.Push(value);
			dataStack.Push(value);
		}
		else if (minStack.Count == 0)
		{
			minStack.Push(value);
			dataStack.Push(value);
		}
		else
		{
			int minValue = (int)minStack.Peek();
			minStack.Push(minValue);
			dataStack.Push(value);			
		}		
	}
	
	public int Pop()
	{
		if (dataStack.Count == 0)
		{
			throw new InvalidOperationException("Stack empty");
		}
		
		minStack.Pop();
		
		return (int)dataStack.Pop();
	}
	
	public int Min()
	{
		if(minStack.Count == 0)
		{
			throw new InvalidOperationException("Empty Stack");
		}
		
		return (int)minStack.Peek();
	}
}