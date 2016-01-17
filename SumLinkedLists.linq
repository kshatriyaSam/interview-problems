<Query Kind="Program" />

void Main()
{
	ListNode node1 = CreateLinkedList(new int[] { 9,2,3});
	ListNode node2 = CreateLinkedList(null);
	ListNode node3 = CreateLinkedList(new int[] { 3, 5, 6});
	PrintLinkedList(node1);
	PrintLinkedList(node2);
	PrintLinkedList(node3);
	
	ListNode result = SumLinkedList(node1, node2, node3);
	
	PrintLinkedList(node1);
	PrintLinkedList(node2);
	PrintLinkedList(node3);
	PrintLinkedList(result);
}

// Define other methods and classes here
public ListNode SumLinkedList(ListNode node1, ListNode node2, ListNode node3)
{
	if(node1 == null && node2 == null && node3 == null) return null;
	
	var node1Rev = ReverseLinkedList(node1);
	var node2Rev = ReverseLinkedList(node2);
	var node3Rev = ReverseLinkedList(node3);
	
	var node1Iter = node1Rev;
	var node2Iter = node2Rev;
	var node3Iter = node3Rev;
	
	int carry = 0;
	ListNode result = null;
	
	while(node1Iter != null || node2Iter != null || node3Iter != null)
	{
		int sumDigit = (node1Iter != null ? node1Iter.val : 0) + (node2Iter != null ? node2Iter.val : 0) + (node3Iter != null ? node3Iter.val : 0) + carry;
		carry = sumDigit / 10;
		int digit = sumDigit % 10;
		
		ListNode d = new ListNode(digit);
		if(result == null)
		{
			result = d;
		}
		else
		{
			d.next = result;
			result = d;
		}
		
		node1Iter = node1Iter != null ? node1Iter.next : null;		
		node2Iter = node2Iter != null? node2Iter.next : null;		
		node3Iter = node3Iter != null? node3Iter.next : null;		
	}
	
	if(carry != 0)
	{
		ListNode d = new ListNode(carry);
		d.next = result;
		result = d;
	}
	
	node1 = ReverseLinkedList(node1Rev);
	node2 = ReverseLinkedList(node2Rev);
	node3 = ReverseLinkedList(node3Rev);
	
	return result;
}


ListNode ReverseLinkedList(ListNode root)
{
	if(root == null) return null;
	
	ListNode temp = root;
	ListNode prev = null;
	
	ListNode next = null;
	while(temp.next != null)
	{
		next = temp.next;
		temp.next = prev;
		
		prev = temp;
		temp = next;
	}
	
	temp.next = prev;
	
	return temp;
}

public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public static ListNode CreateLinkedList(int[] array)
{
	 	if( array == null) return null;
		
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


public static void PrintLinkedList(ListNode head)
{
	ListNode temp = head;
	
	while(temp != null)
	{
		Console.Write("{0} =>", temp.val);
		temp = temp.next;
	}
	
	Console.WriteLine();
	
}
