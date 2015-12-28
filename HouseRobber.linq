<Query Kind="Program" />


/*

LeetCode - House Robber
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
*/void Main()
{
	return Rob(new int[] {2,1,1,2});
}

/*
This problem uses DP programming to determine the max Robbery amount
SubProblem: Determine the max till now at each point with alternating between
two adjacent variables.
*/
public int Rob(int[] nums) 
{        
   if(nums == null || nums.Length == 0) return 0;

   int oddSum = 0;
   int evenSum = 0;
   
   for(int i= 0; i < nums.Length; i++)
   {
       if(i % 2 == 0)
       {
           evenSum = Math.Max(evenSum + nums[i], oddSum);
       }
       else
       {
           oddSum = Math.Max(evenSum, oddSum + nums[i]);
       }
   }
   
   return oddSum > evenSum ? oddSum : evenSum;
        
}
