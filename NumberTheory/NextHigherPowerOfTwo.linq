<Query Kind="Program" />

void Main()
{
	var result = NextHigherPower(129);
	Console.WriteLine(result);
}

/*
Next Higher Power of 2
*/
public uint NextHigherPower(uint input)
{
	input --;
	input = input | input >> 1;
	input = input | input >> 2;
	input = input | input >> 4;
	input = input | input >> 8;
	input = input | input >> 16;
	
	input++;
	return input;
}
