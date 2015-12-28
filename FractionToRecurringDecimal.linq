<Query Kind="Program" />

/*
Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

If the fractional part is repeating, enclose the repeating part in parentheses.

For example,

Given numerator = 1, denominator = 2, return "0.5".
Given numerator = 2, denominator = 1, return "2".
Given numerator = 2, denominator = 3, return "0.(6)".
*/
void Main()
{
	var result  = FractionToDecimal(-2, 3);
}

/*
We have to be careful to handle all edge cases like overflow, negative numbers

*/
public string FractionToDecimal(int num, int denom) 
    {
        if(denom == 0)
        {
            throw new ArgumentException("denominator cannot be Zero");
        }
        		
        if(num == 0) return "0";
        
		long numerator = num; // this is necessary, as Negative IntMax can overflow
		long denominator = denom; // this is necessary, as Negative IntMin can overflow
		
		// check sign
        int sign = 1;
        if(numerator < 0)
        { 
            sign = -1;
            numerator = -numerator;
        }
        
        if(denominator < 0 )
        {
            sign *= -1;
            denominator = -denominator;
        }
        
        StringBuilder result = new StringBuilder();
        
        if(sign < 0)
        {
            result.Append("-");
        }
        
		// append the part before decimal
        var div = (long)numerator/denominator;
        result.Append(div);
        
        if(numerator % denominator != 0)
        {
            result.Append(".");
        }
        else
        {
            return result.ToString();
        }
        
        // implement division process
       var map = new Dictionary<long, int>();
       
       for (long r = numerator % denominator; r > 0; r %= denominator)
       {
            // meet a known remainder
            // so we reach the end of the repeating part
            if (map.ContainsKey(r) == true) 
            {
                result.Insert(map[r], "(", 1); // builder insert actually inserts an element at specified position and shift the other elements right.
                result.Append(")");
                break;
            }
    
            // the remainder is first seen
            // remember the current position for it
            map[r] = result.Length;
    
            r *= 10;
    
            // append the quotient digit
            result.Append(r / denominator);
        }
        
        return result.ToString();
       
    }
