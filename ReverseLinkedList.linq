<Query Kind="Program" />

void Main()
{
	string[] array = {"a", "b", "c", "d", "e"};
	Node<string> headNode = LinkedListExtensions.CreateLinkedList(array);
	LinkedListExtensions.TraverseLinkedList(headNode);
	
	Node<string> tempNode = headNode.Next;
	Node<string> reversedHeadNode = LinkedListExtensions.ReverseList(tempNode.Next);
	tempNode.Next = reversedHeadNode;
	LinkedListExtensions.TraverseLinkedList(headNode);
}