<Query Kind="Program" />

 //Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
 
 
 /* LeetCode=> Solution
    To find the cycle, move two pointers slow and fast. Slow goes one node at a time 
    and fast goes twice as fast. At some point slow and fast will catch up, in case there is a 
    cycle, else fast will hit the end node.
    
    Now to find the starting point of the loop, suppose the 
    distance from head to start of loop =>   A
    distance inside the loop where slow and fast met => B
    distance from where they met to start of loop => C
    
    distance travelled by slow => (A+B);
    distance travelled by fast = (A + 2B + C)
    
    A+ 2B+ C = 2(A+B)
    
    A = C.
    
    so, if we start a pointer from head and move the slow pointer. Where they will 
    meet is the starting point
    */
    public ListNode DetectCycle(ListNode head) {
        
        if(head == null) return null;
        
        ListNode slow = head;
        ListNode fast = head;
        
        while(fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            
            if(slow == fast)
            {
                // we found the cycle, lets find the meeting point
                ListNode slow2 = head;
                
                while(slow2 != slow)
                {
                    slow2 = slow2.next;
                    slow = slow.next;
                }
                
                return slow2;
            }
        }
        
        return null;
        
    }
