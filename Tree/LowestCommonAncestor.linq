<Query Kind="Program" />

/* A binary tree is given and two nodes of this tree is given,
 we have to find out the algorithm for lowest common ancestor of the two given nodes. 
 Common ancestor are the nodes which can be reached from two nodes by following the parent links.
 Lowest common ancestor is the common ancestor which has the highest depth. 
 */
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5, 9, 7, 2 };
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump("Binary Tree",10);
	TreeExtensions.InorderTraversal(root);
	
	TreeNode common = LowestCommonAncestor(2,5, root);
	
	// verify that common node contains the data
	if(FindNode(common, 2) && FindNode(common, 5))
	{
		Console.WriteLine("Data:{0}", common.Value);		
	}
	else
	{
		Console.WriteLine("NULL data");
	}
}

static TreeNode LowestCommonAncestor(int right, int left, TreeNode root)
{		 
	if(root == null)
	return null;
	
	if(root.Value == left || root.Value == right)
	{
		return root;
	}
		
	TreeNode leftNode = LowestCommonAncestor(right, left, root.Left);
	TreeNode rightNode = LowestCommonAncestor(right, left, root.Right);
	
	if (leftNode != null && rightNode != null)
	{
		return root;
	}
	else
	{
		//return null;
		return (leftNode == null ? (rightNode  == null ? null : rightNode) : leftNode);
	}	
}

static bool FindNode(TreeNode root, int value)
{
	if(root == null)
	{
		return false;
	}
	
	if(root.Value == value)
	{
		return true;
	}
	
	return FindNode(root.Left, value) || FindNode(root.Right, value);
}

// Define other methods and classes here
