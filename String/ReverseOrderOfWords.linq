<Query Kind="Program" />

/*
Given an input string, reverse the string word by word. 

For example,
 Given s = "the sky is blue",
 return "blue is sky the". 

*/
void Main()
{
	string reverseWords = "he    lo";
	
	ReverseWords(reverseWords);
	
	Console.WriteLine(reverseWords);
}

	public string ReverseWords(string s) 
    {
        var builder = new StringBuilder();
        
        int end = s.Length;
        for(int i = s.Length - 1; i >= 0; i--)
        {
            if(s[i] == ' ') 
            {
                end = i;
            }
            else if(i == 0 || s[i - 1] == ' ')
            {
                if(builder.Length != 0) builder.Append(" ");
                builder.Append(s.Substring(i, end - i));
            }
        }
        
        return builder.ToString();
    }

// Define other methods and classes here