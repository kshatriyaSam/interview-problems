<Query Kind="Program" />

/*

Reverse a linked list from position m to n. Do it in-place and in one-pass.

For example:
Given 1->2->3->4->5->NULL, m = 2 and n = 4,

return 1->4->3->2->5->NULL.

Note:
Given m, n satisfy the following condition:
1 ≤ m ≤ n ≤ length of list.
*/

void Main()
{
	var array = new int[] { 13, 3,2,5};
	var headNode = CreateLinkedList(array);
	
	ReverseBetween(headNode, 2, 4);
}

// Define other methods and classes here
public ListNode ReverseBetween(ListNode head, int m, int n) 
{
   if(head == null) return null;
   
   ListNode dummy = new ListNode(0); // create a dummy node to mark the head of this list
   dummy.next = head;
   
   ListNode pre = dummy; // make a pointer pre as a marker for the node before reversing
   
   for(int i = 0; i<m-1; i++) 
   {
   		pre = pre.next;
   }

   ListNode start = pre.next; // a pointer to the beginning of a sub-list that will be reversed
   ListNode then = start.next; // a pointer to a node that will be reversed

   // 1 - 2 -3 - 4 - 5 ; m=2; n =4 ---> pre = 1, start = 2, then = 3
   // dummy-> 1 -> 2 -> 3 -> 4 -> 5

   for(int i=0; i < n-m; i++)
   {
       start.next = then.next;
       then.next = pre.next;
       pre.next = then;
       then = start.next;
   }

   // first reversing : dummy->1 - 3 - 2 - 4 - 5; pre = 1, start = 2, then = 4
   // second reversing: dummy->1 - 4 - 3 - 2 - 5; pre = 1, start = 2, then = 5 (finish)

   return dummy.next;
}


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