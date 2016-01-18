<Query Kind="Program" />

/*Given a singly linked list, determine if it is a palindrome.

Follow up:
Could you do it in O(n) time and O(1) space?*/

void Main()
{
	
}

// Define other methods and classes here
 /*
    we need 3 pointers next, prev, current
    next and prev are null intially.
    
    1. First you go to next node;
    2. then point current.next to prev;
    3. move prev to curent
    4. move current to next
    
    */
    ListNode Reverse(ListNode head)
    {
         // reverse the second half
        ListNode next = null;
        ListNode temp = head;
        ListNode prev = null;
        
        while(temp != null)
        {
            next = temp.next;
            temp.next = prev;
            
            prev = temp;
            temp = next;
        }
        
        return prev;
    }
 
 /*
 1. Find mid Pointer
 2. Reverse Second Half
 3. Do comparison of first half with second half
 4. Restore the state of second half
 
 
 */
 public bool IsPalindrome(ListNode head) {
        
        if (head == null) return true;
        
        ListNode midNode = head;
        ListNode fastTemp = head;
        
        // need to find the middle
        while(fastTemp.next != null && fastTemp.next.next != null)
        {
            midNode = midNode.next;
            fastTemp = fastTemp.next.next;
        }

        // reverse the second half.                
        midNode.next = Reverse(midNode.next);
        
        // now do the comparison of first half with second half.
        ListNode start = head;
        ListNode secondHalf = midNode.next;
        
        while(secondHalf != null)
        {
            if(start.val == secondHalf.val)
            {
                start = start.next;
                secondHalf = secondHalf.next;
            }
            else
            {
                return false;
            }
        }
        
        // as good practise restore the original state of the linked list
        
        return true;
    }
    
    
    
