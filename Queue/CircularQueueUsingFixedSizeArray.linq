<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

/*
	Circular queue using Array of Fixed Size
	
*/

void Main()
{
	CircularQueue q = new CircularQueue(3);
	q.Push(1);
	q.Push(2);
	q.Push(3);
	q.Push(4);
}

public class CircularQueue
{
	int[] array;
	int size;
	int head;
	int foot;
	
	public CircularQueue(int size)
	{
		this.head = -1;
		this.foot = -1;
		this.size = size;
		this.array = new int[size];
	}
	
	public void Push(int data)
	{
		if(this.Count() == this.size)
		{
			throw new Exception("Overflow Exception");
		}
		
		if(this.head == this.size - 1)
		{ 
			// queue has reach end of array, reset to 0
			this.head = 0;
		}
		else if (this.head == -1)
		{
			// first entry to empty queue
			this.head = 0;
			this.foot = this.head;
		}
		else
		{	// normal case
			this.head++;
		}
		
		this.array[this.head] = data;
	}
	
	public int Pop()
	{
		if(this.foot == -1)
		{
		 	throw new Exception("Underflow");
		}
		
		int data = this.array[this.foot];
		
		if(this.foot == this.size - 1)
		{
			this.foot = 0;
		}
		else if(this.foot == this.head)
		{
			// last element in the queue
			this.foot = -1;
			this.head = this.foot;
		}
		else
		{
			this.foot++;
		}
		
		return data;
	}
	
	int Count()
	{
		if(this.head == -1)
		{
			return 0;
		}
		
		if(this.head >= this.foot)
		{
			return this.head - this.foot + 1;
		}
		else
		{
			return this.size - this.foot + this.head + 1;
		}
	}
}