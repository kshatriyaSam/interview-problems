<Query Kind="Program" />

// whose digits are unique, find the next larger number that can be formed with those digits
// Test Cases
// 1. Single Digit
// Negative number
// In32.Max, Int32.Min
void Main()
{
	var larger = MakeLargerNumber(-50);
	Console.WriteLine("Larger: {0}", larger);
}

static double MakeLargerNumber(int number)
{
	int original= number;
	int sign = number < 0 ?-1:1;
	number = sign * number;
    // convert to array
	List<int> numberArry = new List<int>();
	while(number > 0)
	{		
		numberArry.Add(number % 10);
		number /= 10;
	}
	
	if(numberArry.Count < 2)
	{
		return original;
	}
	
	// find the decreasing sequence
	int i =1;
	for(; i< numberArry.Count; i++)
	{
	    // if +ve number then sequence should be increasing else decreasing
		if (sign > 0 && numberArry[i] < numberArry[i-1])
		{
			break;			
		}
		
		if (sign < 0 && numberArry[i] > numberArry[i-1])
		{
			break;
		}
	}
	
	if( i == numberArry.Count)
	{ 	
		// we traversed the entire array but did not find anything
		return original;
	}
	
	// swap the decreasing sequence
	int temp = numberArry[i];
	numberArry[i] = numberArry[i-1];
	numberArry[i-1] = temp;
	
	// sort the array from 0 to i-1
	sortArray(numberArry, 0, i-1);
	
	// convert to int
	double finalnumber = 0;
	for(int j = 0; j < numberArry.Count; j++)
	{
	  finalnumber+=numberArry[j]* Math.Pow(10,j);
	}
	
	return finalnumber * sign;	
}

static void sortArray(List<int> digits, int startIndex, int endIndex)
 {
   if(startIndex==endIndex)return;
  for(int k=startIndex;k<endIndex;++k)
   for(int l=startIndex+1;l<=endIndex;++l)
   {
    if(digits[k]<digits[l])
     swap(digits,k,l);
   }  
 }

 static void swap(List<int> digits, int i, int j)
 {
  int temp=digits[i];
  digits[i] = digits[j];
  digits[j] =  temp;
 }

// Define other methods and classes here
