<Query Kind="Program" />

/*
Implement Post Order Traversal of Tree without using Recursion
*/
void Main()
{
	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	Tree t = new Tree();
	var root = t.CreateBTree(inputArray);
	
	t.InOrderTraversal(root);
	Console.WriteLine("\nIterative \n");
	var result = this.InorderTraversalIterative(root);	
	Console.WriteLine(string.Join(" -> ", result));
}

/*
	We implement using 1 Stack
*/
public IList<int> InorderTraversalIterative(TreeNode root)
{
   var result = new List<int>();
   if(root == null) return result;
   
   var stack = new Stack<TreeNode>();
   
   while(true)
   {
   		// go down the left subtree
       while(root != null)
       {
           stack.Push(root);
           root = root.Left;
       }
       
       if(stack.Count == 0) break;
       
	   // pop one element from stack
       root = stack.Pop();
	   result.Add(root.Value);
       
	   // go down its right node.
       root = root.Right;
   }
   
   return result;
   
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
	public void InOrderTraversal(TreeNode node)
	{
		if(node == null)
		{
			return;
		}
			
		InOrderTraversal(node.Left);	
		Console.Write(" {0} ->", node.Value);
		InOrderTraversal(node.Right);		
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