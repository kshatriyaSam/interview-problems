<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
</Query>

// Find all the permutations of a given string whose letters are unique
void Main()
{
	string stringToPermute = "abc";
	char[] stringarray = stringToPermute.ToCharArray();
	Permutation(stringarray, 0, stringToPermute.Length - 1);
}

static void Permutation(char[] stringToPermute, int startIndex, int endIndex)
{
 	if(startIndex == endIndex)
	{
		Console.WriteLine(string.Join("", stringToPermute));
		return;
	}
	
	for(int i = startIndex; i <= endIndex; i++)
	{
		Swap(stringToPermute, startIndex, i);
		Permutation(stringToPermute, startIndex + 1, endIndex);
		Swap(stringToPermute, startIndex, i);
	}
}

static void Swap(char[] stringArray, int left, int right)
{
	char temp  = stringArray[left];
	stringArray[left] = stringArray[right];
	stringArray[right] = temp;
}

// Define other methods and classes here
