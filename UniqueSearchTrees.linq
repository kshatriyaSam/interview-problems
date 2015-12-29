<Query Kind="Program" />

/*
Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

For example,
Given n = 3, your program should return all 5 unique BST's shown below.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3
*/

void Main()
{
	var result = GenerateTrees(2);
}


// Define other methods and classes here
public IList<TreeNode> GenerateTrees(int n) 
{
   if(n < 1)
   {
       return new List<TreeNode>();
       
   }
 return GenerateTreesHelper(1, n);
}

/*

We partition the array using index, Generate Left and Right Subtree
and treat the ith index as the root of the Tree. With current index 
as Root, we create all possible tree from left and right subtree;

*/
IList<TreeNode> GenerateTreesHelper(int startIndex, int endIndex)
{
   var list = new List<TreeNode>();
   if(startIndex > endIndex)
   {
       list.Add(null);
       return list;
   }
   
   if( startIndex == endIndex)
   {
       list.Add(new TreeNode(startIndex));
       return list;
   }
   
   for(int i = startIndex; i <= endIndex; i++)
   {
       var leftSubtree = GenerateTreesHelper(startIndex, i -1);
       var rightSubtree = GenerateTreesHelper(i + 1, endIndex);
       
       foreach(TreeNode leftNode in leftSubtree)
       {
           foreach(TreeNode rightNode in rightSubtree)
           {
               TreeNode root = new TreeNode(i);
               root.Left = leftNode;
               root.Right = rightNode;
               list.Add(root);
           }
       }
   }
   
   return list;
}
