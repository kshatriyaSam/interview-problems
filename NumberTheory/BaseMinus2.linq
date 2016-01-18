<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

// code to convert a positive integer into base minus 2. That is, 
// whereas base 2 has a 1's place, a 2's place, a 4's place, etc., 
// base minus 2 has a 1's place, a minus 2's place, a 4's place, a minus 8's place, ... (-2)^n.
// 6 =        0(* 8) 1(*4) 1(* 2) 0(*1)
// 6 = 1(*16) 1(*-8) 0(*4) 1(*-2) 0(*1)
//6/-2 = -3 - 0
//-3/-2 = 2 - 1
//2/-2 = -1 - 0
//-1/-2 = 1 - 1
//1/-2 = 0 - 1
void Main()
{
	string baseMinus2rep = ConverttoBaseMinus2(6);
	baseMinus2rep.Dump();
}

static string ConverttoBaseMinus2(int num)
{
	StringBuilder builder = new StringBuilder();
	int numToWork = num;
	
	while(numToWork != 0)
	{
		int rem = numToWork % -2;
		numToWork = numToWork/-2;
		if (rem >= 0)
		{
		 builder.Append(rem);
		}
		else
		{
		  numToWork = numToWork + 1;
		  rem = rem * (-1);
		  builder.Append(rem);
		}
	}
   
   char[] reversedCharArray = builder.ToString().ToCharArray();
   RotateSubString(reversedCharArray, 0, builder.Length -1);
   
   return string.Join("", reversedCharArray);
}


static void RotateSubString(char[] stringArray, int startPos, int endPos)
{
	int pos = 0;
	int lengthOfSub = endPos - startPos;
	
	while(pos <= (lengthOfSub / 2))
	{
	  char tempChar = stringArray[startPos + pos];
	  stringArray[startPos + pos] = stringArray[endPos - pos];
	  stringArray[endPos - pos] = tempChar;
	  pos++;
	}
}
// Define other methods and classes here