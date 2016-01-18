<Query Kind="Program" />

// You have an infinite linked list which is not sorted and contains duplicate elements. 
// You have to convert it to a linked list which does not contain duplicate elements
void Main()
{
	int[] inputArray = 
	//{ 1, 2, 3, 5, 6, 2, 6, 8, 3, 6, 1, 9, 5};
	{ 0 };
	Node<int> head = LinkedListExtensions.CreateLinkedList(inputArray);
	
	LinkedListExtensions.TraverseLinkedList<int>(head);
	
	RemoveDuplicates(head);
	
	LinkedListExtensions.TraverseLinkedList<int>(head);
}

static void RemoveDuplicates(Node<int> head)
{
	HashSet<int> set = new HashSet<int>();
	Node<int> tempNode = head;
	Node<int> prevNode = head;
	
	while(tempNode != null)
	{
		if(!set.Contains(tempNode.Value))
		{
			set.Add(tempNode.Value);
			prevNode = tempNode;
			tempNode = tempNode.Next;
		}
		else
		{
			prevNode.Next = tempNode.Next;
			tempNode = tempNode.Next;			
		}
	}
}

// Define other methods and classes here
