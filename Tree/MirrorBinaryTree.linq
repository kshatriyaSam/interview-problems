<Query Kind="Program" />

/*

LeetCode

Invert a binary tree.

     4
   /   \
  2     7
 / \   / \
1   3 6   9
to
     4
   /   \
  7     2
 / \   / \
9   6 3   1
*/

 public TreeNode InvertTree(TreeNode root) 
 {
 	return InvertTreeHelper(root);
 }
    
TreeNode InvertTreeHelper(TreeNode root)
{
   if(root == null) return null;
   
   TreeNode left = InvertTreeHelper(root.left);
   
   TreeNode right = InvertTreeHelper(root.right);
   
   root.left = right;
   root.right = left;
   
   return root;
}