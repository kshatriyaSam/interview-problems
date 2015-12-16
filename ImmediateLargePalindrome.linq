<Query Kind="Program" />

// Given an integer find the immediate larger integer that that which is a palindrome, example 1234212 -> 1234321, 345676 -> 346643.
// even digits ->
// odd digits -> 
void Main()
{
	
}

static double FindNextLargePalindrome(long num)
{
  List<int> numArray = new List<int>();
  long original = num;
  
  while(num != 0)
  {
  	numArray.Add(num % 10);
	num /= 10;
  }
  
  // if it is even
  long modulo = (long)Math.Pow(10, numArray.Count/2);
  if (numArray.Count % 2 == 0)
  {
  	long lefthalf = original/modulo;
	long righthalf = original % modulo;
	
	if (lefthalf > righthalf)
	{
		
	}
  
  }
  else
  {
    long lefthalf = original/(modulo * 10);
	long righthalf = original % modulo;
	
	if( lefthalf > righthalf)
	{
		
	}
  	
  }


}

// Define other methods and classes here
