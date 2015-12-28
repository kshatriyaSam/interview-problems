<Query Kind="Program" />

/*

Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

For example:
Given the following binary tree,
   1            <---
 /   \
2     3         <---
 \     \
  5     4       <---
You should return [1, 3, 4].

*/

// Solution
/*
    Do a level order traversal and store the last value in the that level
    to the list
    
    Things to note: To identify end of the level, either use Special node, which 
    is not a neat solution or use the count of nodes before entering the while node
    and keep track when we have exhausted that count
    */
    public IList<int> RightSideView(TreeNode root) {
        
        var result = new List<int>();
        
        if(root == null)
        {
            return result;
        }
        
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        
        while(true)
        {
            int nodeCount = q.Count;
            if(nodeCount == 0)
            {
                break;
            }
            
            while(nodeCount > 0)
            {
                TreeNode data = (TreeNode)q.Dequeue();
                
                if(data.left != null)
                {
                    q.Enqueue(data.left);
                }
                
                if(data.right != null)
                {
                    q.Enqueue(data.right);
                }
                
                nodeCount--;
                
                // this was the last node in that level, add it to the result
                if(nodeCount == 0)
                {
                    result.Add(data.val);
                }
            }
        }
        
        return result;
    }
