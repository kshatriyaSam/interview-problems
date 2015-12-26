<Query Kind="Program" />

/*
Compare two version numbers version1 and version2.
If version1 > version2 return 1, if version1 < version2 return -1, otherwise return 0.

You may assume that the version strings are non-empty and contain only digits and the . character.
The . character does not represent a decimal point and is used to separate number sequences.
For instance, 2.5 is not "two and a half" or "half way to version three", it is the fifth second-level revision of the second first-level revision.

Here is an example of version numbers ordering:

0.1 < 1.1 < 1.2 < 13.37
*/
void Main()
{
	var result = CompareVersion("1.1", "1.1.3");
}

// Define other methods and classes here
public int CompareVersion(string version1, string version2) {
        
        if(version1 == null && version2 == null)
        {
            return 0;
        }
        else if (version1 == null)
        {
            return -1;
        }
        else if (version2 == null)
        {
            return 1;
        }
        
        var version1Array = version1.Split(new [] {'.'});
        var version2Array = version2.Split(new [] {'.'});
        
        int i;
        int j;
        for(i = 0, j = 0; i < version1Array.Length && j < version2Array.Length; i++, j++)
        {
            var data1 = Convert.ToInt32(version1Array[i].Trim());
            var data2 = Convert.ToInt32(version2Array[j].Trim());
            
            if(data1 == data2)
            {
                continue;
            }
            else if(data1 > data2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        
        
        if( i != version1Array.Length)
        {
			// if the extra version digits are Zero, ignore them
			// as 1.0.0.0.0 == 1
            for(int k = i ;k < version1Array.Length; k++)
            {
                var data1 = Convert.ToInt32(version1Array[k]);
                if (data1 != 0)
                {
                    return 1;
                }
            }
        }
        
        if (j != version2Array.Length)
        {
            for(int k = j ;k < version2Array.Length; k++)
            {
                var data1 = Convert.ToInt32(version2Array[k]);
                if (data1 != 0)
                {
                    return -1;
                }
            }
        }
        
        return 0;
        
    }
