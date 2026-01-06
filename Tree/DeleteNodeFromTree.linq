<Query Kind="Program" />

/*
Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

    Search for a node to remove.
    If the node is found, delete the node.

*/
void Main()
{
	int[] inputArray = { 7, 3, 4, 5, 8, 1 };

	TreeNode t = new TreeNode();
	var root = t.CreateBTree(inputArray);
	
	root = t.DeleteNode(root, 5);
}

public class TreeNode
{
	public int val;
	
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int value = 0)
	{
		val = value;
		left = null;
		right = null;
	}

	
	public TreeNode DeleteNode(TreeNode root, int key)
	{
		if (root == null)
		{
			return root;
		}
		// find the node and keep a pointer to the previous
		TreeNode curr = root;
		TreeNode prev = null;

		while (curr != null && curr.val != key)
		{
			prev = curr;
			if (curr.val > key)
			{
				curr = curr.left;
			}
			else
			{
				curr = curr.right;
			}
		}

		// key does not exist in the Tree
		if (curr == null)
		{
			return root;
		}

		// Node to be remove is either a leaf node
		// or the node has no left or right child
		if (curr.left == null || curr.right == null)
		{
			TreeNode newNode;
			if (curr.left == null)
			{
				newNode = curr.right;
			}
			else
			{
				newNode = curr.left;
			}
			if (prev == null)
			{
				return newNode;
			}

			if (curr == prev.left)
			{
				prev.left = newNode;
			}
			else
			{
				prev.right = newNode;
			}
		}
		else
		{
			// the node to be deleted has both left and right child
			TreeNode successorParent = null;
			// then we fnd the successor.
			TreeNode successor = curr.right;
			while (successor.left != null)
			{
				successorParent = successor;
				successor = successor.left;
			}

			if (successorParent != null)
			{
				successorParent.left = successor.right;
			}
			else
			{
				curr.right = successor.right;
			}

			// replace they key of the current with the key of the successor.
			curr.val = successor.val;
		}

		return root;
	}

	public TreeNode CreateBTree(int[] input)
	{
		TreeNode root = null;
		for (int i = 0; i < input.Length; i++)
		{
			root = InsertNode(root, input[i]);
		}

		return root;
	}

	TreeNode InsertNode(TreeNode root, int data)
	{
		TreeNode node = new TreeNode(data);
		if (root == null)
		{
			root = new TreeNode(data);
			return root;
		}
		else
		{
			TreeNode current = root;

			while (true)
			{
				TreeNode tempParent = current;
				if (data < current.val)
				{
					current = current.left;
					if (current == null)
					{
						tempParent.left = node;
						return root;
					}
				}
				else
				{
					current = current.right;
					if (current == null)
					{
						tempParent.right = node;
						return root;
					}
				}
			}
		}
	}
}
