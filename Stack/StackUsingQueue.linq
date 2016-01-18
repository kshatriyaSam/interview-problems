<Query Kind="Program" />

/*
Implement the following operations of a stack using queues.

push(x) -- Push element x onto stack.
pop() -- Removes the element on top of the stack.
top() -- Get the top element.
empty() -- Return whether the stack is empty.

*/


/*
Solution:
Keep One Queue and take the hit when doing the Push operation

Push the element on queue and then dequeue all the elements and enqueue them back again.

Another approach to keep using two Queue, then you can take the hit when doing the Pop operation
*/
public class Stack {
    // Push element x onto stack.
    
    private Queue q;
    public void Push(int x) {
        
        q.Enqueue(x);
		// dequeue all but the last element and enqueu it back again
        for(int i = 0; i < q.Count -1; i++)
        {
            var data = q.Dequeue();
            q.Enqueue(data);
        }
        
    }

    // Removes the element on top of the stack.
    public void Pop() {
    
        if( q.Count > 0)
        {
            q.Dequeue();
        }
    }

    // Get the top element.
    public int Top() {
        
       return (int)q.Peek();
        
    }

    // Return whether the stack is empty.
    public bool Empty() {
        
        return q.Count == 0;
    }
    
    public Stack()
    {
        q = new Queue();
    }
}