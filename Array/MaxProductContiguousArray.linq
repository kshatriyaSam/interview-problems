<Query Kind="Program" />

/*
Find the contiguous subarray within an array (containing at least one number) which has the largest product.

For example, given the array [2,3,-2,4],
the contiguous subarray [2,3] has the largest product = 6.*/
void Main()
{
	MaxProduct(new [] {2,3, -2, -4, 1, -200});
}

// Define other methods and classes here
 public int MaxProduct(int[] nums) {
        
        // at each step keep calculating the max and min Product available.
        int maxHere = nums[0]; int minHere = nums[0]; int maxProd = nums[0];
        
        for (int i = 1; i < nums.Length; i++)
        {
            int tempMax = maxHere;
            maxHere = Math.Max(nums[i],Math.Max(maxHere*nums[i],minHere*nums[i]));
            minHere = Math.Min(nums[i],Math.Min(tempMax*nums[i],minHere*nums[i]));
            maxProd = Math.Max(maxProd,maxHere);
        }
        
        return maxProd;
    }
