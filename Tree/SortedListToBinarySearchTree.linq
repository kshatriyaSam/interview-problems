<Query Kind="Program" />

/*
Convert a Sorted LinkedList to a Binary Search Tree

*/

/*
This is interesting problem as we can traverse only one way in the List

Beauty of the solution lies in the fact that we never know the tail, but we keep splitting
the list till the very end.

for a 2 Node list, the mid is the lastNode;
*/
 public TreeNode SortedListToBST(ListNode head) 
    {
        return SortedListToBstHelper(head, null);
    }
    
    private TreeNode SortedListToBstHelper(ListNode head, ListNode tail)
    {
        if(head == tail)
        return null;
        
        if(head.next == tail)
        {
            TreeNode root = new TreeNode(head.val);
            return root;
        }
        
		/*
			Find the midNode and create a root out of it.
		*/
        ListNode mid = head; ListNode fast = head;
        while(fast != tail && fast.next != tail)
        {
            mid = mid.next;
            fast = fast.next.next;
        }
        
        TreeNode midroot = new TreeNode(mid.val);
        
		/*
			Now recursively create the Left and Right Subtree.
		*/
        midroot.left = SortedListToBstHelper(head, mid);
        midroot.right = SortedListToBstHelper(mid.next, tail);
        
        return midroot;
        
    }
	
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
 
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }
