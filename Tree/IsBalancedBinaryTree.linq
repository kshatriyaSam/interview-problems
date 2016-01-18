<Query Kind="Program" />

/*
Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
*/

public boolean isBalanced(TreeNode root)
{
    return isBalancedHelper(root);        
}
    
private boolean isBalancedHelper(TreeNode root)
{
   if(root == null) 
   {
       return true;
   }   
   else
   {
       int left = height(root.left);
       int right = height(root.right);
       
       int diff = Math.abs(left-right);
       if(diff > 1) return false;
       
	   // either Left tree is not balanced or Right Tree is not balanced.
       return isBalancedHelper(root.left) && isBalancedHelper(root.right);
   }
}

private int height(TreeNode root)
{
   if(root == null)
   return 0;
   else
   return (1 + Math.max(height(root.left), height(root.right)));
}
