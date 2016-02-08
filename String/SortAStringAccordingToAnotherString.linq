<Query Kind="Program" />

void Main()
{
	var sortOrder = new SortOrder("dfbcae");
	
	var testOrder = "abcdeeabc".ToCharArray();
	Array.Sort(testOrder, sortOrder);
	
	Console.WriteLine(testOrder.ToString());
}

public class SortOrder : IComparer
{
	string sortOrder;
	
	public SortOrder(string sortOrder)
	{
		this.sortOrder = sortOrder;	
	}
	
	public int Compare(object obj1, object obj2)
	{
		var obj1Index = sortOrder.IndexOf((char)obj1);
		var obj2Index = sortOrder.IndexOf((char)obj2);
		
		if(obj1Index == -1 || obj2Index == -1)
		{
			throw new Exception("character not found");
		}
		
		if(obj1Index > obj2Index)
		{
			return 1;
		}
		else if (obj1Index == obj2Index)
		{
			return 0;
		}
		else
		{
			return -1;
		}
	}

}