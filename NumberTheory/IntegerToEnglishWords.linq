<Query Kind="Program" />

/*Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.

For example,
123 -> "One Hundred Twenty Three"
12345 -> "Twelve Thousand Three Hundred Forty Five"
1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven" */

void Main()
{
	int[] testCases = { 0, 1, 13, 101, 1000000, 1000010, 100000000, 91, 80, 21, 100001};
	
	foreach(int test in testCases)
	{
		Console.WriteLine(NumberToWords(test));
	}
}

/*
 We need to divide the number in subgroups of 1000 and get the value.
*/
	string[] lessThan20 = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    string[] tens = new[] { "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
    string[] hundreds = new[] {"", "Thousand ", "Million ", "Billion " };
    
    public string NumberToWords(int num) {
        
        string result = string.Empty;
        
        if(num == 0) return "Zero";
        
        int pos = 0;
        while(num > 0)
        {
            if (num % 1000 != 0)
            {
                result = HundredsHelper(num % 1000).Trim() + " " + hundreds[pos] + result.Trim();
            }
            
            num = num / 1000;
            pos++;
        }
        
        return result.Trim();
    }
    
    string HundredsHelper(int hundred)
    {
        if(hundred < 20)
        {
            return lessThan20[hundred];
        }
        else if(hundred / 100 == 0)
        {
            return tens[hundred/10 - 1] + (hundred % 10 != 0 ? " " + lessThan20[hundred % 10] : ""); 
        }
        else
        {
            return lessThan20[hundred / 100] + " Hundred " + HundredsHelper(hundred % 100);
        }
    }
