<Query Kind="Program" />

/*
	Find GCD of two numbers
*/
void Main()
{
	Console.WriteLine(GCD(25,35));
}

/*
Euclid Algorithm to determine Greatest Number	
*/
public int GCD(int a, int b)
{
	if(b == 0) return a;
	
	return GCD(b, a % b);	
}