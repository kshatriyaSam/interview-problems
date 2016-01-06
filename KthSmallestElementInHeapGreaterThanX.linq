<Query Kind="Program" />

/*
Given an array-based heap on n elements and a real number x, eﬃciently determine whether the kth smallest element in the heap is greater than or equal to x. 
Your algorithm should be O(k) in the worst-case, independent of the size of the heap
*/
void Main()
{
	
}

// Define other methods and classes here
int heap_compare(priority_queue *q, int i, int k, int x) 
{
	if ((k <= 0) || (i > q->n)) return(k);
	
	if (q->q[i] < x)
	{
		k = heap_compare(q, pq_young_child(i), k-1, x);
		k = heap_compare(q, pq_young_child(i)+1, k, x); 
	}
	
	return(count);
} 
