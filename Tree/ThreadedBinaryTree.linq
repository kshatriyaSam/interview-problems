<Query Kind="Program" />

/*
The idea of threaded binary trees is to make inorder traversal faster and do it without stack and without recursion. 
In a simple threaded binary tree, 
the NULL right pointers are used to store inorder successor. 
Where-ever a right pointer is NULL, it is used to store inorder successor.
*/
void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	var t = new ThreadedTree();
	var root = t.CreateBTree(inputArray);
	
	Console.WriteLine("In Order Traversal");
	t.InorderTraversal(root);
	
	CreateThreadedTree(root);
	
	Console.WriteLine("\nIn Order Traversal - after Threading");
	// we have to be careful while doing iteration as Right node is not null
	// and it can lead to stack overflow exception.
	// so only do right traversal in case it is not Threaded Node
	InorderThreaded(root);	
	
}

public void CreateThreadedTree(ThreadedTree.TreeNode root)
{
	// first do a inorder traversal of the tree and save data in Queueu
	var q = new Queue<ThreadedTree.TreeNode>();
	this.PopulateQueue(root, q);
	
	// Next do Inorder Traversal Again and whenever we hit a RightNode null,
	// point it to the next Front Element in the Queue.
	this.CreateThreadedTree(root, q);
}

public void PopulateQueue(ThreadedTree.TreeNode node, Queue<ThreadedTree.TreeNode> q)
{
	if(node == null)
	{
		return;
	}
	
	PopulateQueue(node.Left, q);
	q.Enqueue(node);
	PopulateQueue(node.Right, q);
}

public void CreateThreadedTree(ThreadedTree.TreeNode root, Queue<ThreadedTree.TreeNode> q)
{
	if(root == null) return;
	
	CreateThreadedTree(root.Left, q);
	
	q.Dequeue();
	if( root.Right == null && q.Count != 0)
	{
		// point it to inorder successor and set IsThreaded to true
		root.Right = q.Peek();
		root.IsThreaded = true;
	}
	else
	{	
		CreateThreadedTree(root.Right, q);	
	}
}

public void InorderThreaded(ThreadedTree.TreeNode root)
{
	var temp = LeftMost(root);
	
	while(temp != null)
	{
		Console.Write("{0} - {1}, ", temp.Value, temp.IsThreaded);
		
		if(temp.IsThreaded)
		{
			temp = temp.Right;
		}
		else
		{
			temp = LeftMost(temp.Right);
		}
	}
}

ThreadedTree.TreeNode LeftMost(ThreadedTree.TreeNode current)
{
	while(current != null && current.Left != null)
	{
		current = current.Left;
	}
	
	return current;
}

public class ThreadedTree
{	
	public class TreeNode
	{
		public int Value { get; set;}
		public TreeNode Left { get; set;}
		public TreeNode Right { get; set; }
		public bool IsThreaded {get; set;}
			
		public TreeNode(int value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
			this.IsThreaded = false;
		}
	}
	
	public TreeNode CreateBTree(int[] input)
	{
		TreeNode root = null;
		for(int i =0;i < input.Length; i++)
		{
			root = InsertNode(root, input[i]);
		}
		
		return root;
	}

	TreeNode InsertNode(TreeNode root, int data)
	{
		TreeNode node = new TreeNode(data);
		if(root == null)
		{
			root = new TreeNode(data);
			return root;
		}
		else
		{
			TreeNode current = root;
			
			while(true)
			{
				TreeNode tempParent = current;
				if(data < current.Value)
				{
					current = current.Left;
					if(current == null)
					{
						tempParent.Left = node;
						return root;
					}				
				}
				else
				{
					current = current.Right;
					if (current == null)
					{
						tempParent.Right = node;
						return root;
					}				
				}			
			}
		}	
	}
	
	/*
	Traverse Left Subtree, Root and then Right Subtree
	*/
	public void InorderTraversal(TreeNode node)
	{
		if(node == null)
		{
			return;
		}
		
		InorderTraversal(node.Left);
		
		Console.Write("{0} - {1},", node.Value, node.IsThreaded);
		
		if(!node.IsThreaded)
		{
			InorderTraversal(node.Right);
		}
	}
}
