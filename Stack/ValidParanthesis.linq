<Query Kind="Program" />

/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.
Example 1:
Input: s = "()"
Output: true
Example 2:
Input: s = "()[]{}"
Output: true
*/
void Main()
{
	var testPoints = new Dictionary<string, bool>() {
		{"()[]{}", true},
		{"(", false },
		{"]", false},
		{"", true}
	};
	
	foreach(var test in testPoints)
	{
	   var result = IsValid(test.Key);
	   if (result != test.Value)
	   {
	   	throw new Exception($"TestCase: {test.Key} : Result {test.Value}");
	   }
	}
}

// You can define other methods, fields, classes and namespaces here

Dictionary<char, int> paranthesisDefinition = new Dictionary<char, int>()
    {
        { '(',  1 },
        { ')', -1 },
        { '{', 2  },
        { '}', -2 },
        { '[', 3  },
        { ']', -3 },
    };
    
    public bool IsValid(string s) {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }
        var charArray = s.ToCharArray();
        Stack paraStack = new Stack();

        foreach(var dataPoint in charArray)
        {
            if (paranthesisDefinition.ContainsKey(dataPoint))
            {
                var paranthesisValue = paranthesisDefinition[dataPoint];
                if (paranthesisValue > 0)
                {
                    paraStack.Push(dataPoint);
                }
                else 
                {
                    if (!IsEmpty(paraStack))
                    {
                        var topOfStackChar = (char)paraStack.Pop();
                        var topOfStackCharValue = paranthesisDefinition[topOfStackChar];

                        var netStackResult = topOfStackCharValue + paranthesisValue;
                        if (netStackResult != 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // we have an invalid sequence
                        return false;
                    }
                }
            }
            else
            {
                // not a paranthesis
                continue;
            }
        }

        if (IsEmpty(paraStack))
        {
            return true;
        }

        // there is still some unresolved paranthesis
        return false;
    }

    static bool IsEmpty(Stack paraStack)
    {
        return paraStack.Count == 0;
    }
