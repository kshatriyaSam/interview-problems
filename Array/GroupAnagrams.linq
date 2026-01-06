<Query Kind="Program" />

void Main()
{
	var input = new[] { "act", "pots", "tops", "cat", "stop", "hat"};
	var result = GroupAnagrams(input);
	result.Dump();
}

/*
Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order.

An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.

Example 1:

Input: strs = ["act","pots","tops","cat","stop","hat"]

Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]
*/
public List<List<string>> GroupAnagrams(string[] strs)
{
	if (strs == null)
	{
		throw new ArgumentNullException(nameof(strs));
	}

	if (strs.Length == 1)
	{
		var strList = strs.ToList();
		var result = new List<List<string>>();
		result.Add(strList);
		return result;
	}

	// build map for each string
	var charMap = new Dictionary<string, List<string>>();
	foreach (var str in strs)
	{
		var mapKey = BuildCharacterMapKey(str);
		bool foundMapMatch = false;
		if (charMap.ContainsKey(mapKey))		
		{
			charMap[mapKey].Add(str);
			foundMapMatch = true;
			continue;
		}

		if (false == foundMapMatch)
		{
			var strList = new List<string>();
			strList.Add(str);
			charMap.Add(mapKey, new List<string>(strList));
		}
	}

	// build final result 
	var finalResult = new List<List<string>>();
	foreach (var map in charMap)
	{
		finalResult.Add(map.Value);
	}

	return finalResult;
}

string BuildCharacterMapKey(string str)
{
	var map = new int[26];
	foreach (var c in str)
	{
		var index = (int)c - (int)'a';
		map[index] = map[index] + 1;
	}

	return string.Join(",", map);
}

bool DoesCharMapMatch(int[] existingMap, int[] maptoCompare)
{
	for (int i = 0; i < 26; i++)
	{
		if (existingMap[i] != maptoCompare[i])
		{
			return false;
		}
	}

	return true;
}
