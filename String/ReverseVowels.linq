<Query Kind="Program" />

void Main()
{
	var result = ReverseVowels("eeoo");	
	result.Dump();
}

/*
Write a function that takes a string as input and reverse only the vowels of a string.
*/
     public string ReverseVowels(string s) {
        
		if (s == null || s.Length == 0)
        {
            return s;
        }
        
        int startIndex = 0;
        int endIndex = s.Length;
        
		// To CharArray is 10 times faster than StringBuilder.
		
        var answer = s.ToCharArray();
        
        for(int index = endIndex - 1; index >= startIndex;index--)
        {
            if (IsVowel(s[index]))
            {
                while(startIndex < index && !IsVowel(s[startIndex]))
                {
                    startIndex++;
                }
                
                if (startIndex < index)
                {
                    var temp = s[index];
                    answer[index] = s[startIndex];
                    answer[startIndex] = temp;                   
                }
                
                startIndex++;
			}	
        }
        
        return new string(answer);
    }
    
    bool IsVowel(char data)
    {
        if (data == 'a' || data == 'e' || data == 'i' || data == 'o' || data == 'u' || data == 'A' || data == 'E' || data == 'I' || data == 'O' || data == 'U')
        {
            return true;
        }

	return false;
	}