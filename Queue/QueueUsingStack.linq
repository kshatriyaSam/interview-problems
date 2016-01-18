<Query Kind="Program" />

// Implement a queue using Stack
/* Queue is a FIFO list whereas Stack is LIFO
*/
void Main()
{
	int[] inputArray = { 3, 5, 1, 4, 8, 10 };
	QueueUsingStack q = new QueueUsingStack();
	
	Random r = new Random();
	for (int i = 0; i < inputArray.Length; i++)
	{
		q.Enqueue(inputArray[i]);
		if(r.Next(0, 200) % 2 == 0)
		{
			Console.WriteLine(q.Dequeue());
		}
	}
	
	while(!q.IsEmpty())
	{
		Console.WriteLine(q.Dequeue());
	}
}

// Define other methods and classes here
public class QueueUsingStack
{
	Stack One;
	
	Stack Two;
	
	public QueueUsingStack()
	{
		One = new Stack();
		Two = new Stack();
	}
	
	public void Enqueue(int value)
	{
		One.Push(value);
	}
	
	public int Dequeue()
	{
		if(Two.Count == 0 && One.Count == 0)
		{
			throw new InvalidOperationException("Queue is empty");
		}
		
		if(Two.Count == 0)
		{
			int temp;
			while(One.Count != 0)
			{
				temp = (int)One.Pop();
				Two.Push(temp);				
			}
		}
		
		return (int)Two.Pop();	
	}
	
	public bool IsEmpty()
	{
		return One.Count == 0 && Two.Count == 0;
	}
}