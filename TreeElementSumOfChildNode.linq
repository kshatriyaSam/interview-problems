<Query Kind="Program" />

/*
	In a binary tree change each nodes value except leaf node, as sum of left and right subtree values
*/
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5, 9, 7, 2 };
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump("Binary Tree",10);
	TreeExtensions.InorderTraversal(root);
	
	TreeNode SummedRoot = Sumchildnode(root);
	
	Console.WriteLine("Summed Traversal");
	TreeExtensions.InorderTraversal(SummedRoot);
}

// Do Post Order Traversal and keep summing Nodes
static TreeNode Sumchildnode(TreeNode root)
{
	if(root == null)
	{
		return null;
	}
	
	TreeNode left = Sumchildnode(root.Left);
	TreeNode right = Sumchildnode(root.Right);
	
	if(left != null)
	{
		root.Value += left.Value;
	}
	
	if(right != null)
	{
		root.Value += right.Value;
	}
	
	return root;
}

// Define other methods and classes here
