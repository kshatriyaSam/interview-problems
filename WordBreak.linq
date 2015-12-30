<Query Kind="Program" />

/*
Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".
*/
void Main()
{
	var list = new List<string>{ "leet", "code"};
	var s  = "leetcode";
	WordBreak(s, list);
}

// Define other methods and classes here
public bool WordBreak(string s, IList<string> wordDict) {
   
   var f = new bool[s.Length + 1];
   f[0] = true;
   
   for(int i=1; i <= s.Length; i++)
   {
       for(int j=0; j < i; j++)
	   {
           if(f[j] && wordDict.Contains(s.Substring(j, i - j)))
		   {
               f[i] = true;
               break;
           }
       }
   }
   
   return f[s.Length];
}
