<Query Kind="Program" />

void Main()
{
	HashSet<string> setOfData = new HashSet<string>();
		setOfData.Add("a");
		setOfData.Add("b");
		setOfData.Add("v");
		
	using (StreamWriter writer = new StreamWriter(@"E:\Dumps\testhashset", true))
	{
		writer.Write(string.Join(",", setOfData));
	}
	
	using (StreamReader reader = new StreamReader(@"E:\Dumps\testhashset"))
	{
		string dataresult = reader.ReadToEnd();
		string[] resultArrary = dataresult.Split(',');
		Console.WriteLine(resultArrary.ToList());
	}
}

// Define other methods and classes here
