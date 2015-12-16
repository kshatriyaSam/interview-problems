<Query Kind="Program" />

// Find k maximum integers from an array of infinite integers.
/*
	In the minHeap when it full of capacity, add elements to heap 
	when it is greater than minElement and then remove the Min element
*/
void Main()
{
	MinHeap heap = new MinHeap(5);
	int[] inputArray = {1,2,3,4,5,6,7,8,9,10,11,12,13,14};
	for(int i = 0; i< inputArray.Length; i++)
	{
		heap.InsertKey(inputArray[i]);
	}
	
	for(int i = 0; i < 5;i++)
	{
		Console.WriteLine(heap.ExtractMin());
	}
}

// Define other methods and classes here
public class MinHeap
{
	int[] heapArray;
	
	int heapSize;
	
	int maxCapacity;
	
	public MinHeap(int capacity)
	{
		this.maxCapacity = capacity;
		this.heapArray = new int[capacity];
	}
	
	public int Left(int i)
	{
		return (2 * i + 1);
	}
	
	public int Right(int i)
	{
		return (2 * i + 2);
	}
	
	public int Parent(int i)
	{
		return (i -1)/2;
	}
	
	/*
	 check if we have not exhausted the capacity.
	 Insert the key at the end and then put it in 
	 correct place.	
	*/	
	public void InsertKey(int value)
	{
		if(this.heapSize >= this.maxCapacity)
		{
			if(value > this.GetMin())
			{
				this.ExtractMin();
				this.InsertKey(value);				
			}
			
			return;
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