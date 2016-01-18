<Query Kind="Program" />

/*
mplement int sqrt(int x).

Compute and return the square root of x.
*/
void Main()
{
	var result = MySqrt(999);
	Console.WriteLine(result);
}

 public int MySqrt(int x)
 {        
   if(x <= 1) return x;
   
   int start = 1; int end = x;
   
   while(start < end)
   {
       int mid = (end - start)/2 + start;
       
       if( mid > x/mid)
       {
           end = mid;
       }
       else
       {
           start = mid +1;
       }
   }
   
   return start - 1;
        
}
