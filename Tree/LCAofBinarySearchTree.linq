<Query Kind="Program" />

/*
	LCA of the Binary Search 
*/
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5, 9, 7, 2 };
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump("Binary Tree",10);
	TreeExtensions.InorderTraversal(root);
	
}

/*
	Binary Search Tree Has the property that Node greater than element
	lie on the Right Side and Node less than lie on the Left Side
*/
public TreeNode LCABinarySearchTree(TreeNode root, int a, int b)
{
	if(root == null) return root;

	// if root is greater than lca is on left side
	if(root.Value > a && root.Value > b) 
	{
		return LCABinarySearchTree(root.Left, a, b);
	}
	// if root is less than lca lies on right side
	else if(root.Value < a && root.Value < b)
	{
		return LCABinarySearchTree(root.Right, a, b);
	}
	
	// else one element is greater and 
	// other lesser and hence root is the lca.
	return root;
}