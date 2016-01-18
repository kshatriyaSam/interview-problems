<Query Kind="Program" />

/*
The problem is basically destroying the Tree Structure,

Given a binary Tree, make the child Nodes point to its Parent.
*/

void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	Tree t = new Tree();
	var root = t.CreateBTree(inputArray);
	
}

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
	
	public TreeNode InvertBinaryTree(TreeNode root)
	{
		
	
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
