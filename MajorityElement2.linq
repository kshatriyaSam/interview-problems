<Query Kind="Program" />

/*
n an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times. The algorithm should run in linear time and in O(1) space.
*/
void Main()
{
	var result = MajorityElement(new int[] {3,4,5,2,3,3});
}

/*
Solution is based on Moores Voting Algorithm.
Thing to note is that there were will be Only 2 elements in the solution as you will have to find number having more occurences 
than n/3 times.

So you can keep two variables and keep counting occurences of these and decreasing the two variables in case they dont match
You have to do second pass again to verify that we are not inadvertently adding the last element in the result.
*/
 public IList<int> MajorityElement(int[] nums) {
        
        if(nums == null)
        {
            return null;
        }
        
        int count1 = 0;
        int count2 = 0; 
        int num1 = 0;
        int num2 = 0;
        
        for(int i = 0; i < nums.Length; i++)
        {
            if (count1 == 0 || num1 == nums[i])
            {
                num1 = nums[i];
                count1++;
            }
            else if (count2 == 0 || num2 == nums[i])
            {
                num2 = nums[i];
                count2++;
            }
            else 
            {
                count1--;
                count2--;
            }
        }
        
        int countNum1=0;
        int countNum2 =0;
        
        for(int i =0; i < nums.Length; i++)
        {
            if (nums[i] == num1) countNum1++;
            else if (nums[i] == num2) countNum2++;
        }
        
        var result = new List<int>();
        if(countNum1 > nums.Length/3)
        {
            result.Add(num1);
        }
        
        if(countNum2 > nums.Length/3)
        {
            result.Add(num2);
        }
        
        return result;
        
    }
