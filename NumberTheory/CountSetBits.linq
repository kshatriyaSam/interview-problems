<Query Kind="Program" />

//quickly count the number of set bits in a 32-bit integer in linear time (with respect to the number of set bits)? In constant time? 
//1101. Substraction of 1 toggles all the bits from right to left including the rightmost set bit.

void Main()
{
	Console.WriteLine(countSetBits(Int32.MaxValue));
}

static uint countSetBits(int n)
{
	uint count = 0;
	
	while(n != 0)
	{
		n &= (n-1);
		count++;
	}
	
	return count;
}

// Define other methods and classes here
