<Query Kind="Program" />

/*
Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

Note: 
You may assume k is always valid, 1 ≤ k ≤ BST's total elements.
*/


/*
Solution: We have to do Inorder Traversal. 

We will follow DFS iteration model, using Stack and keep counting elements.

// We could also have followed the DFS recursive model
// We also could have done Binary Search, by first counting all the elements in the Tree and trying to figure out where the
k value will lie
*/
	public int KthSmallest(TreeNode root, int k) 
	{
       return KthSmallestInternal(root, k); 
    }
    
    int KthSmallestInternal(TreeNode root, int k)
    {
        var stk = new Stack<TreeNode>();
        
        // reach the leftmost node
        while(root != null)
        {
            stk.Push(root);
            root = root.left;
        }
        
        // now start popping from the stack and decrementing k;
        while(stk.Count != 0)
        {
            var dataNode = (TreeNode)stk.Pop();
            k--;
            if(k == 0)
            {
                return dataNode.val;
            }
            
            var rightNode = dataNode.right;
            while(rightNode != null)
            {
                stk.Push(rightNode);
                rightNode = rightNode.left;
            }
        }
        
        return -1;
    }
