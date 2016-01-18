<Query Kind="Program" />

void Main()
{
	int[] inputArray = { 3, 5, 8, 11, 10};
	
	MinQueue minQ = new MinQueue();
	Random r = new Random();
	for(int i = 0; i < inputArray.Length ; i++)
	{
		minQ.Enqueue(inputArray[i]);
		if(r.Next(0,10) % 2 == 0)
		{
			Console.WriteLine("MinVal: {0}", minQ.MinValue());
			Console.WriteLine("Data: {0}", minQ.Dequeue());
		}
	}
	
	Console.WriteLine("Dump data");
	while(!minQ.IsEmpty())
	{
		Console.WriteLine("MinVal: {0}", minQ.MinValue());
		Console.WriteLine("Data: {0}", minQ.Dequeue());	
	}

}

// Define other methods and classes here
public class MinQueue
{
	MinimumStack2 stack1 {get; set;}
	MinimumStack2 stack2 {get; set;}
	
	public MinQueue()
	{
		this.stack1 = new MinimumStack2();
		this.stack2 = new MinimumStack2();
	}
	
	public void Enqueue(int value)
	{
		this.stack1.Push(value);
	}
	
	public int Dequeue()
	{
		if(this.stack2.IsEmpty())
		{
			while(!this.stack1.IsEmpty())
			{
				this.stack2.Push(this.stack1.Pop());
			}
		}
		
		return this.stack2.Pop();
	}
	
	public int MinValue()
	{
		return Math.Min(this.stack1.IsEmpty()? Int32.MaxValue : this.stack1.Min(),
		this.stack2.IsEmpty()? Int32.MaxValue : this.stack2.Min());
	}
	
	public bool IsEmpty()
	{
		return this.stack1.IsEmpty() && this.stack2.IsEmpty();
	}
	
}
public class MinimumStack2
{
	Stack dataStack;
	int miniMum;
	
	public MinimumStack2()
	{
		dataStack = new Stack();
		miniMum = Int32.MaxValue;
	}
	
	public bool IsEmpty()
	{
		return this.dataStack.Count == 0;
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
