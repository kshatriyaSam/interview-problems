<Query Kind="Program" />

/*
Given a binary tree, return all root-to-leaf paths.

For example, given the following binary tree:

   1
 /   \
2     3
 \
  5
All root-to-leaf paths are:

["1->2->5", "1->3"]
*/

public IList<string> BinaryTreePaths(TreeNode root)
{   
   var result = new List<string>();
   var builder = new StringBuilder();
   
   BinaryTreePathInternal(result, builder, root);
   
   return result;
}

void BinaryTreePathInternal(List<string> result, StringBuilder temp, TreeNode root)
{
	// in case of null root just return
   if(root == null)
   {
       return;
   }
   
   // using this variable to backtrack what we append in this function
   int length = temp.Length;
   
   // we have reached a leaf node, time to add to our result
   if(root.left == null && root.right == null)
   {
   		// COPY THE temp String to new variable, so that we can backtrack
       var substr = new StringBuilder(temp.ToString());
       
       if(temp.Length == 0)
       {
           substr.Append(root.val);
       }
       else
       {
           substr.AppendFormat("->{0}", root.val);
       }
       
       var path = substr.ToString();
       
       result.Add(path);
       return;
   }
   
   if(temp.Length == 0)
   {
       temp.Append(root.val);
   }
   else
   {
       temp.AppendFormat("->{0}", root.val);
   }
   
   BinaryTreePathInternal(result, temp, root.left);
   
   BinaryTreePathInternal(result, temp, root.right);
   
   // remove what we added to the temp string
   temp.Remove(length, temp.Length - length);
}
