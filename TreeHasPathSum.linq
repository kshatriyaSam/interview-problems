<Query Kind="Program" />

/*
Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1
return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
*/
 public bool HasPathSum(TreeNode root, int sum)
 {
        if(root == null)
        {
            return false;
        }
        
        return HasPathSumInternal(root, sum);
}
    
    bool HasPathSumInternal(TreeNode root, int sum)
    {
        if(root == null) return false;
        
		// if its a leaf node and sum has dropped to zero after negating this, return true.
        if(root.left == null && root.right == null && (sum - root.val) != 0) return false;
        if(root.left == null && root.right == null && (sum -root.val) == 0) return true;
        
		// else follow the inorder traversal
        var leftTree = HasPathSumInternal(root.left, sum - root.val);
        var rightTree = HasPathSumInternal(root.right, sum - root.val);
        
        return leftTree || rightTree;
    }
