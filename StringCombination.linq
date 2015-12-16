<Query Kind="Program" />

// print all possible combination of a string e.g. ABC = > A, AB, ABC, B, BC, etc
void Main()
{
	string stringComb = "ABC";
	char[] stringCombArray = stringComb.ToCharArray();
	char[] stringResult = new char[stringCombArray.Length];
	GenerateAllCombination(stringCombArray, stringResult, 0, stringCombArray.Length, 0);
}

static void GenerateAllCombination(char[] originalCharArray, char[] permutationArray, int start, int end, int index)
{
	if(start == end)
	{
		Console.WriteLine(string.Join("", permutationArray));
		return;
	}
	
	for(int i = start; i < end;i++)
	{
		permutationArray[index] = originalCharArray[i];
		GenerateAllCombination(originalCharArray, permutationArray, i + 1, end, index + 1);
	}
}

// Define other methods and classes here
