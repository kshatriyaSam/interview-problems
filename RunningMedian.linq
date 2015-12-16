<Query Kind="Program" />

// Find the running median after entering every number from a sequence of infinite integers
/*

Maintain 2 heaps - MinHeap and MaxHeap. Keep them balance, so that when the number of elements of MinHeap and
MaxHeap are equal, then median is average of top of each heap.
If any one heap has more elements, then median is top of that heap
	
*/
void Main()
{
	RunningMedian median = new RunningMedian(20);
	
	int[] inputArray = { 3, 6, 1, 8, 4, 9, 2 };
	foreach(int data in inputArray)
	{
		Console.WriteLine("Median : {0}", median.GetMedian(data));
	}
}

// Define other methods and classes here
public class RunningMedian
{
	MinHeap minHeap;
	
	MaxHeap maxHeap;
	
	public RunningMedian(int capacity)
	{
		this.minHeap = new MinHeap(capacity);
		this.maxHeap = new MaxHeap(capacity);
		this.minHeap.InsertKey(Int32.MaxValue);
		this.maxHeap.InsertKey(Int32.MinValue);
	}
	
	public double GetMedian(int value)
	{
		if(value > this.minHeap.GetMin())
		{
			this.minHeap.InsertKey(value);
		}
		else
		{
			this.maxHeap.InsertKey(value);
		}
		
		if(this.minHeap.Size() - this.maxHeap.Size() == 2)
		{
			this.maxHeap.InsertKey(this.minHeap.ExtractMin());
		}
		else if (this.maxHeap.Size() - this.minHeap.Size() == 2)
		{
			this.minHeap.InsertKey(this.maxHeap.ExtractMax());
		}
		
		if (this.minHeap.Size() == this.maxHeap.Size())
		{
			return ((this.minHeap.GetMin() + this.maxHeap.GetMax()) / 2);
		}
		
		if (this.maxHeap.Size() > this.minHeap.Size())
		{
			return this.maxHeap.GetMax();
		}
		else
		{
			return this.minHeap.GetMin();
		}		
	}
}


public class MinHeap
{
	int[] heapArray;
	
	int heapSize;
	
	int maxCapacity;
	
	public MinHeap(int capacity)
	{
		this.maxCapacity = capacity;
		this.heapArray = new int[capacity];
		this.heapSize = 0;
	}
	
	/*
	 check if we have not exhausted the capacity.
	 Insert the key at the end and then put it in 
	 correct place.	
	*/	
	public void InsertKey(int value)
	{
		if(this.heapSize == this.maxCapacity)
		{
			throw new OverflowException("Max heap reached");
		}
		
		this.heapSize++;
		int i = this.heapSize -1;
		this.heapArray[i] = value;
		
		while( i != 0 && this.heapArray[this.Parent(i)] > this.heapArray[i])
		{
			Swap(this.Parent(i), i);
			i = this.Parent(i);
		}
	}
	
	// Set value at i to Int32.MinValue
	public void DeleteKey(int i)
	{
		this.DecreaseKey(i, Int32.MinValue);
		this.ExtractMin();
	}
	
	/*
		Extract the top element and replace it with last element
		Then Heapify the stack
	*/
	public int ExtractMin()
	{
		 if (this.heapSize == 0)
		 {
		 	return Int32.MaxValue;
		 }
		 
		 if(this.heapSize == 1)
		 {
		 	this.heapSize--;
			return this.heapArray[0];
		 }
		 
		 int root = this.heapArray[0];
		 this.heapArray[0] = this.heapArray[this.heapSize - 1];
		 this.heapSize--;
		 this.MinHeapify(0);
		 
		 return root;
	}
	
	public void DecreaseKey(int i, int new_val)
	{
		this.heapArray[i] = new_val;
		while(i != 0 && this.heapArray[this.Parent(i)] > this.heapArray[i])
		{
			Swap(this.Parent(i), i);
			i = this.Parent(i);
		}
	}
	
	public int GetMin()
	{
		return this.heapArray[0];
	}
	
	public int Size()
	{
		return this.heapSize;
	}
	
	int Left(int i)
	{
		return (2 * i + 1);
	}
	
	int Right(int i)
	{
		return (2 * i + 2);
	}
	
	int Parent(int i)
	{
		return (i -1)/2;
	}
	
	void MinHeapify(int i)
	{
		int left = this.Left(i);
		int right = this.Right(i);
		int smaller = i;
		
		if(left < heapSize && this.heapArray[i] > this.heapArray[left])
		{
			smaller = left;
		}
		if(right < heapSize && this.heapArray[smaller] > this.heapArray[right])
		{
			smaller = right;
		}
		
		if(smaller != i)
		{
			Swap(i, smaller);
			MinHeapify(smaller);
		}	
	}
	
	void Swap(int i, int j)
	{
		int temp = this.heapArray[i];
		this.heapArray[i] = this.heapArray[j];
		this.heapArray[j] = temp;
	}
}

public class MaxHeap
{
	int[] heapArray;
	
	int heapSize;
	
	int maxCapacity;
	
	public MaxHeap(int capacity)
	{
		this.maxCapacity = capacity;
		this.heapArray = new int[capacity];
		this.heapSize = 0;
	}
	
	/*
	 check if we have not exhausted the capacity.
	 Insert the key at the end and then put it in 
	 correct place.	
	*/	
	public void InsertKey(int value)
	{
		if(this.heapSize == this.maxCapacity)
		{
			throw new OverflowException("Max heap reached");
		}
		
		this.heapSize++;
		int i = this.heapSize -1;
		this.heapArray[i] = value;
		
		while( i != 0 &&  this.heapArray[i] > this.heapArray[this.Parent(i)])
		{
			Swap(this.Parent(i), i);
			i = this.Parent(i);
		}
	}
	
	// Set value at i to Int32.MinValue
	public void DeleteKey(int i)
	{
		this.DecreaseKey(i, Int32.MaxValue);
		this.ExtractMax();
	}
	
	/*
		Extract the top element and replace it with last element
		Then Heapify the stack
	*/
	public int ExtractMax()
	{
		 if (this.heapSize == 0)
		 {
		 	return Int32.MaxValue;
		 }
		 
		 if(this.heapSize == 1)
		 {
		 	this.heapSize--;
			return this.heapArray[0];
		 }
		 
		 int root = this.heapArray[0];
		 this.heapArray[0] = this.heapArray[this.heapSize - 1];
		 this.heapSize--;
		 this.MaxHeapify(0);
		 
		 return root;
	}
	
	public void DecreaseKey(int i, int new_val)
	{
		this.heapArray[i] = new_val;
		while(i != 0 && this.heapArray[this.Parent(i)] < this.heapArray[i])
		{
			Swap(this.Parent(i), i);
			i = this.Parent(i);
		}
	}
	
	public int GetMax()
	{
		return this.heapArray[0];
	}
	
	public int Size()
	{
		return this.heapSize;
	}
	
	int Left(int i)
	{
		return (2 * i + 1);
	}
	
	int Right(int i)
	{
		return (2 * i + 2);
	}
	
	int Parent(int i)
	{
		return (i -1)/2;
	}
	
	void MaxHeapify(int i)
	{
		int left = this.Left(i);
		int right = this.Right(i);
		int larger = i;
		
		if(left < heapSize && this.heapArray[i] < this.heapArray[left])
		{
			larger = left;
		}
		if(right < heapSize && this.heapArray[larger] < this.heapArray[right])
		{
			larger = right;
		}
		
		if(larger != i)
		{
			Swap(i, larger);
			MaxHeapify(larger);
		}	
	}
	
	void Swap(int i, int j)
	{
		int temp = this.heapArray[i];
		this.heapArray[i] = this.heapArray[j];
		this.heapArray[j] = temp;
	}
}
