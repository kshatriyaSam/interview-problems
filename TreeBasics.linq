<Query Kind="Program" />

void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump();
	
	Console.WriteLine("Inorder =>");
	TreeExtensions.InorderTraversal(root);
	Console.WriteLine("\nPreorder =>");
	TreeExtensions.PreOrderTraversal(root);
	Console.WriteLine("\nPostorder =>");
	TreeExtensions.PostOrderTraversal(root);
}


