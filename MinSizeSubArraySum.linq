<Query Kind="Program" />

/*Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s. If there isn't one, return 0 instead.

For example, given the array [2,3,1,2,4,3] and s = 7,
the subarray [4,3] has the minimal length under the problem constraint.*/
void Main()
{
	
}

// Define other methods and classes here

    public int MinSubArrayLen(int s, int[] nums)
    {
        if( nums == null || nums.Length ==0)
        {
            return 0;
        }
        
        int countOfNum =0;
        int minSubArrayCount = Int32.MaxValue;
        int currSum =0;
        int startIndex = 0;
        
        int rear = 0;
        int length = nums.Length;
        
        // start counting elements and once sum is exceeded, move the front counter
        // to see if we can reduce the sum further
        while(rear < length)
        {
            if(currSum >=s)
            {
                if(countOfNum < minSubArrayCount)
                {
                    minSubArrayCount = countOfNum;
                }
                
                currSum = currSum - nums[startIndex];
                startIndex++;
                countOfNum--;
            }
            else
            {
                currSum = currSum + nums[rear];
                rear++;
                countOfNum++;
            }
        }
        
        // validate if we can still reduce the length of the subarray
        while(currSum >=s && rear > startIndex)
        {
            if (countOfNum < minSubArrayCount)
            {
                minSubArrayCount = countOfNum;
            }
            
            currSum = currSum - nums[startIndex];
            startIndex++;
            countOfNum--;
        }
        
        // requirement as per question
        if(minSubArrayCount == Int32.MaxValue)
        {
            minSubArrayCount =0;
        }
        
        return minSubArrayCount;
    }

