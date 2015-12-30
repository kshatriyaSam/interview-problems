<Query Kind="Program" />

/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].

Note:
You must do this in-place without making a copy of the array.
Minimize the total number of operations.
*/
void Main()
{
	MoveZeroes(new int[] {0,1,0,3,12});
}

// Define other methods and classes here

public void MoveZeroes(int[] nums) 
{
   int countOfZeros = 0;
   for(int i = 0; i < nums.Length;i++)
   {
       if(nums[i] == 0)
       {
           countOfZeros++;
       }
       else
       {
           nums[i-countOfZeros] = nums[i];
       }
   }
   
   for(int i = nums.Length - countOfZeros; i < nums.Length;i++)
   {
       nums[i] = 0;
   }
}
