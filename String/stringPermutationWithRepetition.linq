<Query Kind="Program" />

// string permutation with repetition allowed. AB => AA , BB, AB
void Main()
{
	string stringToPermute = "ABC";
	char[] stringArray = stringToPermute.ToCharArray();
	char[] permutedArray = new char[stringArray.Length];
	PermutationWithRepetition(stringArray, permutedArray, stringArray.Length, 0);	
}

static void PermutationWithRepetition(char[] originStringArray, char[] permutedArray, int lenght, int index)
{
	if( lenght == index)
	{
		Console.WriteLine(string.Join("", permutedArray));
		return;
	}
	
	for(int i = 0; i < lenght; i++)
	{
		permutedArray[index] = originStringArray[i];
		PermutationWithRepetition(originStringArray, permutedArray, lenght, index + 1);
	}
}

// Define other methods and classes here
