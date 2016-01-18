<Query Kind="Program" />

void Main()
{
	var qList = new QueueUsingLinkedList();
	
	qList.Push("a");
	var result  = qList.Pop();
}

/*
The trick here is to imagine the list in an inverted order

E=> 3->2->1 <=Start

So you push to End and Pop from Start;

*/
public class QueueUsingLinkedList
{
	// make startNode as End of the LinkList
	public QueueNode StartNode;
	
	// make EndNode as Start of the LinkList
	public QueueNode EndNode;

	public void Push(string data)
	{
		var temp = new QueueNode(data);
		if(this.StartNode == null && this.EndNode == null)
		{
			// The Queue is basically Empty.
			this.StartNode = temp;
			this.EndNode = temp;
		}
		else
		{
			this.StartNode.Next = temp;
			this.StartNode = temp;
		}
	}
	
	public string Pop()
	{
		if(this.StartNode == null && this.EndNode == null)
		{
			throw new Exception("Queue is Empty");
		}
		
		var result = this.EndNode;
		this.EndNode = this.EndNode.Next;
		
		// Queue is now Empty
		if(this.EndNode == null)
		{
			this.StartNode = null;
		}
	}
	
	public bool IsEmpty()
	{
		return this.EndNode == null && this.StartNode == null;
	}	
}

public class QueueNode
{
	public string Value;
	public QueueNode Next;
	
	public QueueNode(string input)
	{
		this.Value = input;
		this.Next = null;
	}	
}


