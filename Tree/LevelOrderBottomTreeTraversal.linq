<Query Kind="Program" />

/*
Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its bottom-up level order traversal as:
[
  [15,7],
  [9,20],
  [3]
]
*/
public IList<IList<int>> LevelOrderBottom(TreeNode root) 
    {
        var result = new List<IList<int>>();
        if(root == null) return result;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(true)
        {
            int nodeCount = queue.Count;
            if(nodeCount == 0)
            {
                break;
            }
            
            var subList = new List<int>();
            while(nodeCount > 0)
            {
                var dataNode = (TreeNode)queue.Dequeue();
                
                subList.Add(dataNode.val);
                
                if(dataNode.left != null)
                {
                    queue.Enqueue(dataNode.left);
                }
                
                if(dataNode.right != null)
                {
                    queue.Enqueue(dataNode.right);
                }
                
                nodeCount--;
            }
            
            result.Insert(0, subList);
        }
        
        return result;
    }
