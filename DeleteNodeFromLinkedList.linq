<Query Kind="Program" />

/*
Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.

Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
*/
void Main()
{
	
}

/*
Idea is to copy the values to the previous node and then delete the last node.
This will only work for non-terminal nodes
*/
 public void DeleteNode(ListNode node)
 {
        
        if(node == null) return;
        
        ListNode temp = node;
        
        ListNode prev = temp;
        while(temp.next != null)
        {
            temp.val = temp.next.val;
            
            prev = temp;
            temp = temp.next;
        }
        
        prev.next = null;
        
    }