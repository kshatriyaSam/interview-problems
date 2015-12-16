<Query Kind="Program" />

// Reverse a string containing special characters.
/*
Input:   str = "Ab,c,de!$"
Output:  str = "ed,c,bA!$"
*/
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5 };
	
	NeigbourTree treeClass = new NeigbourTree();
	var root = treeClass.CreateBTree(inputArray);
	
	treeClass.LevelOrderTraversalLine(root);
	
	treeClass.FillNeighbourNode(root);
	
	treeClass.InorderTraversal(root);
}

// Define other methods and classes here

public class NeigbourTree
{
		
	public NeighbourTreeNode CreateBTree(int[] input)
	{
		NeighbourTreeNode root = null;
		for(int i =0;i < input.Length; i++)
		{
			root = InsertNode(root, input[i]);
		}
		
		return root;
	}

	NeighbourTreeNode InsertNode(NeighbourTreeNode root, int data)
	{
		NeighbourTreeNode node = new NeighbourTreeNode(data);
		if(root == null)
		{
			root = new NeighbourTreeNode(data);
			return root;
		}
		else
		{
			NeighbourTreeNode current = root;
			
			while(true)
			{
				NeighbourTreeNode tempParent = current;
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
	
	public void LevelOrderTraversalLine(NeighbourTreeNode root)
	{
		Queue q = new Queue();
		q.Enqueue(root);
		
		Console.WriteLine();
		Console.WriteLine("Level Order Traversal- Line wise");
		while(true)
		{
			int nodeCount = q.Count;
			
			if(nodeCount == 0)
			{
				break;
			}
			
			while(nodeCount != 0)
			{
				NeighbourTreeNode node = (NeighbourTreeNode)q.Dequeue();
								
				Console.Write(node.Value + " ");
				
				if(node.Left != null)
				{
					q.Enqueue(node.Left);
				}
				
				if(node.Right != null)
				{
					q.Enqueue(node.Right);
				}
				
				nodeCount--;
			}
			
			Console.WriteLine();
		}		
	}
	
	/*
	Traverse Left Subtree, Root and then Right Subtree
	*/
	public void InorderTraversal(NeighbourTreeNode node)
	{
		if(node == null)
		{
			return;
		}
		
		InorderTraversal(node.Left);
		Console.WriteLine("{0}, Neighbour: {1}", node.Value, node.Neighbour != null ? node.Neighbour.Value.ToString() : "null");
		InorderTraversal(node.Right);
	}
	
	
	public void FillNeighbourNode(NeighbourTreeNode root)
	{
		Queue q = new Queue();
		q.Enqueue(root);
		
		Console.WriteLine();
		Console.WriteLine("Fill Neighbour Node");
		while(true)
		{
			int nodeCount = q.Count;
			
			if(nodeCount == 0)
			{
				break;
			}
			
			while(nodeCount != 0)
			{
				NeighbourTreeNode node = (NeighbourTreeNode)q.Dequeue();
								
				Console.Write(node.Value + " ");
				
				if(node.Left != null)
				{
					q.Enqueue(node.Left);
				}
				
				if(node.Right != null)
				{
					q.Enqueue(node.Right);
				}
				
				nodeCount--;
				if (nodeCount != 0 )
				{
					NeighbourTreeNode neighbour = (NeighbourTreeNode)q.Peek();
					node.Neighbour = neighbour;
				}
			}
			
			Console.WriteLine();
		}		
	}	
}

public class NeighbourTreeNode
{
	public int Value { get; set;}
	public NeighbourTreeNode Left { get; set;}
	public NeighbourTreeNode Right { get; set; }
	public NeighbourTreeNode Neighbour { get; set; }
	
	public NeighbourTreeNode(int value)
	{
		this.Value = value;
		this.Left = null;
		this.Right = null;
		this.Neighbour = null;
	}
}
