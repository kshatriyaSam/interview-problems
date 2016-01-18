<Query Kind="Program" />

void Main()
{
	Tree t = new Tree();
	var root = t.CreateBTree(new int[] {7,4,6,9,1,2});
	t.InorderTraversal(root);
	Console.WriteLine();
	t.TopViewTree(root);
}

/*
 Top View Tree can be found by keeping another variable width distance from the root.
 if Root is at Distance Hd and Left is at Distance Hd - 1 and Right is at distance Hd + 1
 
 Keep a Map and do a Level Order Traversal. Store the first Element at each 
 horizontal distance in the Map and that the the Top View of the Tree
 
*/
public class Tree
{	
	public void TopViewTree(TreeNode root)
	{
		var dictionary = new SortedDictionary<int, int>();
		
		int hd = 0;
		
		var q = new Queue<TreeNode>();
		root.Horizontal = hd;
		
		q.Enqueue(root);
		
		dictionary.Add(hd, root.Value);
		
		while(q.Count != 0)
		{
			var temp = q.Dequeue();
			hd = temp.Horizontal;
			
			if(temp.Left != null)
			{
				if(!dictionary.ContainsKey(hd - 1))
				{
					dictionary.Add(hd - 1, temp.Left.Value);
				}
				
				temp.Left.Horizontal = hd -1;
				q.Enqueue(temp.Left);
			}
			
			if(temp.Right != null)
			{
				if(!dictionary.ContainsKey(hd + 1))
				{
					dictionary.Add(hd + 1, temp.Right.Value);
				}
				
				temp.Right.Horizontal = hd + 1;
				q.Enqueue(temp.Right);
			}
		}
		
		foreach(var data in dictionary.Keys)
		{
			Console.Write("{0}=> ", dictionary[data]);
		}
	}
	
	public class TreeNode
	{
		public int Value { get; set;}
		public TreeNode Left { get; set;}
		public TreeNode Right { get; set; }
		public int Horizontal { get; set; }
			
		public TreeNode(int value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
			this.Horizontal = int.MaxValue;
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
}
