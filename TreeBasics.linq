<Query Kind="Program" />

void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	Tree t = new Tree();
	var root = t.CreateBTree(inputArray);
	
	Console.WriteLine("In Order Traversal");
	t.InorderTraversal(root);
	
	Console.WriteLine("\nPost Order Traversal");
	t.PostOrderTraversal(root);
	
	Console.WriteLine("\nPre Order Traversal");
	t.PreOrderTraversal(root);	
}

// Define other methods and classes here

public class Tree
{	
	public class TreeNode
	{
		public int Value { get; set;}
		public TreeNode Left { get; set;}
		public TreeNode Right { get; set; }
			
		public TreeNode(int value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
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
		Console.Write("{0},", node.Value);
		InorderTraversal(node.Right);
	}
	
	/*
		Traverse the root, then Left and Right Subtree
	*/
	public void PreOrderTraversal(TreeNode node)
	{
		if(node == null)
		{
			return;
		}
		
		Console.Write("{0},", node.Value);
		PreOrderTraversal(node.Left);	
		PreOrderTraversal(node.Right);
	}
	
	/*
		Traverse the root, then Left and Right Subtree
	*/
	public void PostOrderTraversal(TreeNode node)
	{
		if(node == null)
		{
			return;
		}
			
		PostOrderTraversal(node.Left);	
		PostOrderTraversal(node.Right);
		Console.Write("{0},", node.Value);
	}
}
