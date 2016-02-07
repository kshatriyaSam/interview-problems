<Query Kind="Program" />

/*
Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. 
You must make sure your result is the smallest in lexicographical order among all possible results.

Example:
Given "bcabc"
Return "abc"

Given "cbacdcbc"
Return "acdb"
*/
void Main()
{
	var result = RemoveDuplicateLetters("abacb");
	Console.WriteLine(result);
}

// Define other methods and classes here
    public string RemoveDuplicateLetters(string s) {
        
        if(s == null || s.Length == 0)
        {
            return string.Empty;
        }
         
                
        int[] count = new int[26];
        for(int i =0; i < s.Length;i++)
        {
            count[(int)s[i] - (int)'a'] = count[(int)s[i] - (int)'a'] + 1; 
        }
        
		var instk = new bool[26];
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            while(stack.Count != 0 && stack.Peek() > s[i] && instk[(int)s[i] - 'a'] != true)
            {
                char top = (char)stack.Peek();
                if (count[(int)top - (int)'a'] > 1)
                {
                    // we have more occurences of this character, we can pop it out.
                    stack.Pop();
					count[(int)top - (int)'a'] = count[(int)top - (int)'a'] - 1;
					instk[(int)top - (int)'a'] = false;
                }
				else
				{
					break;
				}
            }
            
			if(instk[(int)s[i] - (int)'a'] == false)
			{
            	stack.Push(s[i]);
				instk[(int)s[i] - (int)'a'] = true;			
			}
			else
			{
			    count[(int)s[i] - (int)'a'] = count[(int)s[i] - (int)'a'] -1;
			}
        }      
		
        
        StringBuilder builder = new StringBuilder();
        while(stack.Count != 0)
        {
            builder.Append((char)stack.Pop());
        }
        
        return Reverse(builder.ToString());
       
    }
    
    static string Reverse(string input)
    {
        var charArray = input.ToCharArray();
		for(int i = 0 ;i < input.Length/2 ;i++)
		{
			char temp = charArray[i];
			charArray[i] = charArray[input.Length -i -1];
			charArray[input.Length -i -1] = temp;		
		}
		
		return new string(charArray);
    }