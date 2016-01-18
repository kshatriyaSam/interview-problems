<Query Kind="Program" />

/*
Convert a Binary Search Tree to a Doubly Linked List
*/
void Main()
{
	Tree t = new Tree();
	var root = t.CreateBTree(new int[] {5,2,7,8,1,3,6});
	
	t.InorderTraversal(root);
	
	var result = CreateListFromBST(root);
	Console.WriteLine(result.Value);
	
	// throws null ref exception
	// var result2 = CreateListFromBST2(root);
	Console.WriteLine(result2.Value);
}

/*
Create LeftList and Right List separately and make root as the middle list
Complication in finding the successor after preparing each list
*/
public Node CreateListFromBST(Node root)
{
	if(root == null) return null;
	
	if(root.Left != null)
	{
		var leftList = CreateListFromBST(root.Left);
		
		for(; leftList.Right != null; leftList = leftList.Right);
		
		leftList.Right = root;
		
		root.Left = leftList;
	}
	
	if(root.Right != null)
	{
		var rightList = CreateListFromBST(root.Right);
		for(;rightList.Left != null; rightList = rightList.Left);
		
		rightList.Left = root;
		root.Right = rightList;
	}
	
	return root;	
}

/*
Keep storing the head, prev and root pointer, Whatever list we have prepared, 
make sure head.Left points to last node and head.right points to first node;
*/
public Node CreateListFromBST2(Node root)
{
	Node head = null;
	Node prev = null;
	
	CreateListFromBST2Internal(root, head, prev);
	
	return head;
}

void CreateListFromBST2Internal(Node root, Node head, Node prev)
{
	if(root == null) return;

	CreateListFromBST2Internal(root.Left, head, prev);
	
	root.Left = prev;
	if(prev != null)
	{
		prev.Right = root;
	}
	else
	{
		head = prev;
	}
	
	head.Left = root;
	
	Node right = root.Right;
	root.Right = head;
	
	// update the previous Node;
	prev = root;
	
	CreateListFromBST2Internal(right, head, prev);
}

// Define other methods and classes here

public class Node
{
	public int Value { get; set;}
	public Node Left { get; set;}
	public Node Right { get; set; }
		
	public Node(int value)
	{
		this.Value = value;
		this.Left = null;
		this.Right = null;
	}
}

public class Tree
{		
	public Node CreateBTree(int[] input)
	{
		Node root = null;
		for(int i =0;i < input.Length; i++)
		{
			root = InsertNode(root, input[i]);
		}
		
		return root;
	}

	Node InsertNode(Node root, int data)
	{
		Node node = new Node(data);
		if(root == null)
		{
			root = new Node(data);
			return root;
		}
		else
		{
			Node current = root;
			
			while(true)
			{
				Node tempParent = current;
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
	public void InorderTraversal(Node node)
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
	public void PreOrderTraversal(Node node)
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
	public void PostOrderTraversal(Node node)
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

