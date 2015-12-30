<Query Kind="Program" />

/*
LeetCode problem
Sort a linked list using insertion sort.
/*


Insertion Sort works by picking the element and putting it in 
the right place in the sub array starting from beginning.

Sorting a linkedList is not recommended approach as the nodes in the linked list
might be distributed far and it might cause cache misses. If we copy the linked list to array
then it will be more localized.
*/

    public ListNode InsertionSortList(ListNode head) 
    {
        if( head == null) return null;
        ListNode current = head;
        
        ListNode prev = null;
        
        while(current != null)
        {
            if(current != head && current.val < prev.val) // we only need to sort if the last element in the subarray is greater than current element
            {
                ListNode iter = head;
                ListNode prevIter = null; // always keeps prevIter as Null
            
                while(iter != current) // previous value is smaller than equal to current, no need to check
                {
                    if(iter.val > current.val)
                    {
                        ListNode currentNext = current.next;
                        prev.next = currentNext;
                        
                        current.next = iter;
                        
                        if(prevIter == null)
                        {
                            head = current;
                        }
                        else
                        {
                            prevIter.next = current;
                        }
                        
                        // exit the inner while loop
                        break;
                    }
                    
                    prevIter = iter;
                    iter = iter.next;
                }
            }
            
            prev = current;
            current = current.next;
        }
        
        return head;
    }