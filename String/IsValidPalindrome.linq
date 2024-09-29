<Query Kind="Program" />

/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.
Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

*/
void Main()
{
    IsPalindrome("A man, a plan, a canal: Panama").Dump();
	IsPalindrome("race a car").Dump();
}


/*
We start 2 pointers from start and End and compare each character, till we reach the middle.
*/
    public bool IsPalindrome(string s) {

        int start = 0;
        int end = s.Length -1;

        while(start < end)
        {		   
            var startAlpha = IsAlpahnumeric(s[start]);
            var endAlpha = IsAlpahnumeric(s[end]);
            if (startAlpha && endAlpha)
            {
                if (char.ToLower(s[start]) == char.ToLower(s[end]))
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }
            else if (startAlpha)
            {
                // decrement end to find the next alphanumeric character
                end--;
            }
            else if (endAlpha)
            {
                start++;
            }
            else
            {
                start++;
                end--;
            }
        }

        return true;
    }

    bool IsAlpahnumeric(char c)
    {
        return char.IsLetterOrDigit(c);
    }
