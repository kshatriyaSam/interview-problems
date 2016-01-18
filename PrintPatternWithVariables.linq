<Query Kind="Program" />

/*
simple pattern printing problem – for example, if 16 is given, to print :
    16 11 6 1 -4 1 6 11 16

    if input was 10

    10 5 0 5 10
	
	without declaring variables or loops
*/
void Main()
{
	
	PrintPattern(-10, -10);
}

bool invertValue = false;
public void PrintPattern(int range, int currentValue)
{
	if(currentValue <= 0)
	{
		invertValue = true;
	}
	
	if(currentValue == range && invertValue)
	{
		return;
	}
	
	if(currentValue == range && !invertValue)
	{
		Console.Write(" {0}  ", currentValue);
	}
	
	if(!invertValue)
	{
		currentValue = currentValue - 5;
		Console.Write(" {0}  ", currentValue);
	}
	else
	{
		currentValue = currentValue + 5;
		Console.Write(" {0} ", currentValue);
	}
	
	PrintPattern(range, currentValue);
}
