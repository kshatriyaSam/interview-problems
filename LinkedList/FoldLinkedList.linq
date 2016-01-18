<Query Kind="Program" />

//Fold a linked list such that the last element becomes second element, last but one element becomes 4 th element and so on.
// For example input linked list: 1->2->3->4->5->6->7->8->9-> output linked list 1->9->2->8->3->7->4->6->5->
void Main()
{
	int[] inputArry = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
	Node<int> headNode = LinkedListExtensions.CreateLinkedList(inputArry);
	LinkedListExtensions.TraverseLinkedList(headNode);
	
	FoldLinkedList(headNode);
}

static Node<int> FoldLinkedList(Node<int> headNode)
{
	// identify middle of linked list
	Node<int> midNode = headNode;
	Node<int> fastNode = midNode;
	Node<int> prevNode = null;
	
	while(fastNode.Next != null && fastNode.Next.Next != null)
	{
		prevNode = midNode;
		fastNode = fastNode.Next.Next;
		midNode = midNode.Next;
	}
	
	// reverse the second half of linked list
	Node<int> reversedHead = LinkedListExtensions.ReverseList(midNode.Next);
	
	midNode.Next = reversedHead;
	LinkedListExtensions.TraverseLinkedList(headNode);
	
	// now mix first half with reversed half
	Node<int> tempNode = headNode;
	Node<int> nextHeadNode;
	Node<int> nextMidNode;
	while(reversedHead.Next != null)
	{
		nextHeadNode = tempNode.Next;
		nextMidNode = reversedHead.Next;
		
		tempNode.Next = reversedHead;
		reversedHead.Next = nextHeadNode;
		midNode.Next = nextMidNode;
		
		reversedHead = nextMidNode;
		tempNode = nextHeadNode;
	}
	
	LinkedListExtensions.TraverseLinkedList(headNode);
	
	return headNode;	
}