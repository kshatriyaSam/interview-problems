<Query Kind="Program" />

void Main()
{
	var matches = kmp("abababa", "aba");
	matches.Dump();
/*
	matches = kmp("abc", "abcdef");
	System.out.println(matches); // []

	matches = kmp("P@TTerNabcdefP@TTerNP@TTerNabcdefabcdefabcdefabcdefP@TTerN", "P@TTerN");
	System.out.println(matches); // [0, 13, 20, 51]
	*/
}

// You can define other methods, fields, classes and namespaces here
// Given a pattern and a text kmp finds all the places that the pattern
// is found in the text (even overlapping pattern matches)
public static List<int> kmp(String txt, String pat)
{
	List<int> matches = new List<int>();
	if (txt == null || pat == null) return matches;

	int m = pat.Length, n = txt.Length, i = 0, j = 0;
	if (m > n) return matches;

	int[] arr = kmpHelper(pat, m);

	while (i < n)
	{
		if (pat[j] == txt[i])
		{
			j++;
			i++;
		}
		if (j == m)
		{
			matches.Add(i - j);
			j = arr[j - 1];
		}
		else if (i < n && pat[j] != txt[i])
		{
			if (j != 0)
			{
				j = arr[j - 1];
			}
			else
			{
				i = i + 1;
			}
		}
	}

	return matches;
}

// For each index i compute the longest match between the proper
// prefix starting at 0 and the proper suffix starting at i
private static int[] kmpHelper(String pat, int m)
{
	int[] arr = new int[m];
	for (int i = 1, len = 0; i < m;)
	{
		if (pat[i] == pat[len])
		{
			arr[i++] = ++len;
		}
		else
		{
			if (len > 0)
			{
				len = arr[len - 1];
			}
			else
			{
				i++;
			}
		}
	}
	arr.Dump();
	return arr;
}