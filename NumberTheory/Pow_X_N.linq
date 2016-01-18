<Query Kind="Program" />

/*
Implement pow(x, n).
*/
 public double MyPow(double x, int n) 
 {     
    if(n==0) 
	{
		return 1;
	}
	
	// at this point n could overflow, hence copy it to a long variable
	long nCopy = n;
    if(nCopy < 0)
	{
        nCopy = -nCopy;
        x = 1/x;
    }
	
    double ans = 1;
    
	while (nCopy > 0)
	{    
		if((nCopy & 1) != 0) 
        {
            ans *= x;
        }
		
        x *= x;
        nCopy >>= 1;
    }
	
    return ans;
}
