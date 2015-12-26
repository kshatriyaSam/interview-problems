<Query Kind="Program" />

/*
Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 
*/
void Main()
{
	var result = ConvertToTitle(52);
}

/*
	It just about converting to base of 26 but the 
	interesting thing to note here is the n-- intially.
	
	Also take a look at how efficiently we can reverse a stringbuilder
*/

 public string ConvertToTitle(int n) {
        
        StringBuilder builder = new StringBuilder();
        int rem = 0;
        while(n > 0)
        {
            n--;
            rem = n % 26;
            builder.Append((char)((int)'A' + rem ));
            
            n /= 26;
        }
      
        string reverseResult = builder.ToString();
        
        if(reverseResult.Length == 1) 
        {
            return reverseResult;
        }
        else
        {
            var charArray = reverseResult.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
