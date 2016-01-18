<Query Kind="Program" />

/*

1. Node (X) is child of Root
 				y                                     x
               / \     Zig (Right Rotation)          /  \
              x   T3   – - – - – - – - - ->         T1   y 
             / \       < - - - - - - - - -              / \
            T1  T2     Zag (Left Rotation)            T2   T3
			

2. Node (X) has parent and Grandparent

			Zig-Zig (Left Left Case):
       G                        P                           X       
      / \                     /   \                        / \      
     P  T4   rightRotate(G)  X     G     rightRotate(P)  T1   P     
    / \      ============>  / \   / \    ============>       / \    
   X  T3                   T1 T2 T3 T4                      T2  G
  / \                                                          / \ 
 T1 T2                                                        T3  T4 

Zag-Zag (Right Right Case):
  G                          P                           X       
 /  \                      /   \                        / \      
T1   P     leftRotate(G)  G     X     leftRotate(P)    P   T4
    / \    ============> / \   / \    ============>   / \   
   T2   X               T1 T2 T3 T4                  G   T3
       / \                                          / \ 
      T3 T4                                        T1  T2
	  
	  
	  
	  Zig-Zag (Left Right Case):
       G                        G                            X       
      / \                     /   \                        /   \      
     P   T4  leftRotate(P)   X     T4    rightRotate(G)   P     G     
   /  \      ============>  / \          ============>   / \   /  \    
  T1   X                   P  T3                       T1  T2 T3  T4 
      / \                 / \                                       
    T2  T3              T1   T2                                     

Zag-Zig (Right Left Case):
  G                          G                           X       
 /  \                      /  \                        /   \      
T1   P    rightRotate(P)  T1   X     leftRotate(P)    G     P
    / \   =============>      / \    ============>   / \   / \   
   X  T4                    T2   P                 T1  T2 T3  T4
  / \                           / \                
 T2  T3                        T3  T4  
	  
*/

void Main()
{

	int[] inputArray = {4,5,2,8,9,1,4,3};
	
	Tree t = new Tree();
	var root = t.CreateSplayTree(inputArray);
	
	Console.WriteLine("PreOrder Traversal");
	t.PreOrderTraversal(root); // as we are interested in what the root is
	
	Console.WriteLine("\nInorder Traversal");
	t.InorderTraversal(root);
	
	root = t.SearchTree(root, 8);
	
	Console.WriteLine("\nAfter Searching... ");	
	t.PreOrderTraversal(root);
	
	t.RemoveNode(root, 4);
	
	Console.WriteLine("\nAfter Removal.. Preorder Traversal... ");
	t.PreOrderTraversal(root);
	
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
	
	public TreeNode SearchTree(TreeNode root, int key)
	{
		return SplayTree(root, key);
	}
	
	// splay key in the tree rooted at Node h. If a node with that key exists,
    //   it is splayed to the root of the tree. If it does not, the last node
    //   along the search path for the key is splayed to the root.
	TreeNode SplayTree(TreeNode root, int key)
	{
		if(root == null || root.Value == key) return root;
		
		if(root.Value > key)
		{
			// node is in Left subtree;
			if(root.Left == null) return root;
			
			if(root.Left.Value > key)
			{
				// Zig Zig node is further in Left Subtree, bring it up
				root.Left.Left = SplayTree(root.Left.Left, key);
				
				root = this.RightRotate(root);
			}
			else if( root.Left.Value < key)
			{
				root.Left.Right = SplayTree(root.Left.Right, key);
				if(root.Left.Right != null)
				root.Left = LeftRotate(root.Left);
			}
			
			return root.Left == null ? root : RightRotate(root);
		}
		else
		{
			// node is in right subtree;
			if(root.Right == null) return root;
			
			if(root.Right.Value < key)
			{
				// Zig Zig
				root.Right.Right = SplayTree(root.Right.Right, key);
				root = LeftRotate(root);		
			
			}
			else if(root.Right.Value > key)
			{
				root.Right.Left = SplayTree(root.Right.Left, key);
				root = RightRotate(root);
			}
			
			return root.Right == null ? root : LeftRotate(root);
		}
	}
	
	TreeNode RightRotate(TreeNode root)
	{
		TreeNode leftNode = root.Left;
		root.Left = leftNode.Right;
		
		leftNode.Right = root;
		root = leftNode;
		
		return root;
	}
	
	TreeNode LeftRotate(Tree.TreeNode root)
	{
		TreeNode rightNode = root.Right;
		root.Right = rightNode.Left;
		
		rightNode.Left = root;
		root = rightNode;
		
		return root;
	}
		
	public TreeNode CreateSplayTree(int[] input)
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
		if(root == null) return new TreeNode(data);
		
		root = SplayTree(root, data);
		
		//if(root.Value == data) return root;
		
		// if root is greater than data, then make data as root
		// and root as Right child
		
		TreeNode dataNode = new TreeNode(data);
		if(root.Value > data)
		{	
			TreeNode left = root.Left;
			dataNode.Left = left;
			dataNode.Right = root;
			
			root.Left = null;
		}
		else
		{
			TreeNode right = root.Right;
			dataNode.Left = root;
			dataNode.Right = right;
			
			root.Right = null;
		}
		
		return dataNode;		
	}
	
	 /* This splays the key, then does a slightly modified Hibbard deletion on
     * the root (if it is the node to be deleted; if it is not, the key was 
     * not in the tree). The modification is that rather than swapping the
     * root (call it node A) with its successor, it's successor (call it Node B)
     * is moved to the root position by splaying for the deletion key in A's 
     * right subtree. Finally, A's right child is made the new root's right 
     * child.
     */
	public void RemoveNode(TreeNode root, int key)
	{
		root = SplayTree(root, key);
		
		if(root.Value != key) return;
		
		if(root.Left == null)
		{
			root = root.Right;
		}
		else
		{
			TreeNode right = root.Right;
			root = root.Left;
			root = SplayTree(root, key);
			root.Right = right;
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
