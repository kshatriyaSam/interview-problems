<Query Kind="Program" />

/*
	Given a binary tree print it in level order zigzag form
*/
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5, 9, 7, 2 };
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump("Binary Tree",10);
	TreeExtensions.InorderTraversal(root);
}

static void PrintZigZag(TreeNode root)
{
	Queue queue = new Queue();
	Stack stack = new Stack();
	
	queue.Enqueue(root);
	TreeNode marker = new TreeNode(-1);
	queue.Enqueue(marker;
	
	while(queue.Count != 0)
	{
		TreeNode node = queue.Dequeue();
	}	
}

// Define other methods and classes here
