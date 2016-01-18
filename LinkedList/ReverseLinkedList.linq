<Query Kind="Program" />

/*
Reverse a singly linked list.
*/
void Main()
{
	var array = new int[] { 13, 3,2,5};
	var headNode = CreateLinkedList(array);
	
	ReverseList(headNode);
}

/*
We need 3 pointers prev, current and next
*/
public ListNode ReverseList(ListNode head) 
{
   if(head == null) return null;
   
   ListNode current = head;
   ListNode prev = null;
   
   ListNode next = current.next;
   while(next != null)
   {
       current.next = prev;
       prev = current;
       current = next;
       
       next = next.next;
   }
   
   // assign the last pointer
   current.next = prev;
   return current;
}

//
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public static ListNode CreateLinkedList(int[] array)
{
		ListNode headListNode = null;
		ListNode nextListNode = null;
		int i = 0;
		while(i < array.Length)
		{
			ListNode newListNode = new ListNode(array[i]);
			if (i == 0)
			{
				headListNode = newListNode;
				nextListNode = headListNode;
			}
			else
			{
				nextListNode.next = newListNode;
				nextListNode = newListNode;			
			}
			
			i++;
		}
		
		return headListNode;
}
