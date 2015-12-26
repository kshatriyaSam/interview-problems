<Query Kind="Program" />

/*

There are N gas stations along a circular route, where the amount of gas at station i is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). You begin the journey with an empty tank at one of the gas stations.

Return the starting gas station's index if you can travel around the circuit once, otherwise return -1.
*/

void Main()
{
	var gas = new int[] { 5,2,8,3,2};
	var cost = new int[] {2,4,6,2,3};
	
	var result = CanCompleteCircuit(gas, cost);
}

/*
	keep a running sum of difference of Gas and Cost at each pivot
	If the sum is negative at a point, reset the start pointer
	
	if at the end the totalSum is less than Zero return -1 else return the last 
	saved location
*/
public int CanCompleteCircuit(int[] gas, int[] cost) 
{
        
        int sum = 0;
        int totalSum = 0;
        int location =0;
        
        for(int i = 0; i < gas.Length; i++)
        {
            sum += (gas[i] - cost[i]);
            
            if(sum < 0)
            {
                totalSum += sum;
                sum = 0;
                location = i+1;
            }
        }
        
        totalSum += sum;
        
        return (totalSum < 0) ? -1 : location;
    }