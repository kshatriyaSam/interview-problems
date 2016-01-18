<Query Kind="Program" />

/*
	Given a binary tree print it in level order zigzag form
*/
void Main()
{
	int[] inputArray = { 6, 3, 8, 1, 5, 9, 7, 2 };
	TreeNode root = TreeExtensions.CreateBTree(inputArray);
	
	root.Dump("Binary Tree",10);
	TreeExtensions.InorderTraversal(root);
	
	var result = ZigzagLevelOrder(root);
	
}


// Using LinkedList to insert at beginning or insert at End.
// using Queue to do iterative Level Order Traversal
// Keeping Counter to determine if we need to add First or Add Last
 public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root == null) return result;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        bool isForward = true;
        
        while(true)
        {
            int nodeCount = queue.Count;
            if(nodeCount == 0)
            {
                break;
            }
            
            var subList = new LinkedList<int>();
            while(nodeCount > 0)
            {
                var dataNode = (TreeNode)queue.Dequeue();
                
                if(isForward)
                {
                    subList.AddLast(dataNode.Value);
                }
                else
                {
                    subList.AddFirst(dataNode.Value);
                }
                
                if(dataNode.Left != null)
                {
                    queue.Enqueue(dataNode.Left);
                }
                
                if(dataNode.Right != null)
                {
                    queue.Enqueue(dataNode.Right);
                }
                
                nodeCount--;
            }
            
            isForward = !isForward;
            result.Add(subList.ToList());
        }
        
        return result;
    }


// Define other methods and classes here