<Query Kind="Program" />

/*
Implement Post Order Traversal of Tree without using Recursion
*/
void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	Tree t = new Tree();
	var root = t.CreateBTree(inputArray);
	
	t.PostOrderTraversal(root);
	Console.WriteLine("\nIterative \n");
	this.PostOrderTraversalIterative(root);	
}

/*
	We implement using 2 stack
*/
public void PostOrderTraversalIterative(TreeNode root)
{
	if(root == null) return;
	
	var first = new Stack<TreeNode>();
	var second = new Stack<TreeNode>();
	
	// add root to First Stack
	first.Push(root);
	
	while(first.Count != 0)
	{
		// Pop the element from the First STack
		var currentNode = (TreeNode)first.Pop();
		
		// Add it to second Stack
		second.Push(currentNode);
		
		// Add its children to the first Stack
		if(currentNode.Left != null)
		{
			first.Push(currentNode.Left);
		}
		if(currentNode.Right != null)
		{
			first.Push(currentNode.Right);
		}
	}
	
	while(second.Count != 0)
	{
		var current = (TreeNode)second.Pop();
		Console.Write("{0} -> ", current.Value);
	}	
}

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
	
public class Tree
{	

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
		Console.Write(" {0} ->", node.Value);
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
}

