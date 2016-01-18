<Query Kind="Program" />

/*
Find prime numbers smaller than N

http://www.geeksforgeeks.org/segmented-sieve/
*/
void Main()
{
	SegmentedSieve(100);
}

List<int> SimpleSieve(int limit)
{
	var mark = new bool[limit];
	
	for(int i = 2; i * i < limit; i++)
	{
		if(mark[i] == false)
		{
			for(int j = 2 *i; j < limit; j += i)
			{
				mark[j] = true;
			}		
		}
	}
	
	var result = new List<int>();
	for(int i = 2; i< limit; i++)
	{
		if (mark[i] == false)
		{
			result.Add(i);
			Console.Write("{0} =>", i);
		}
	}
	
	return result;
}

void SegmentedSieve(int n)
{
	// Divide the array into sqrt(n) groups and find Primes within them;	
	int limit = (int)(Math.Floor(Math.Sqrt(n)) + 1);	
	var primes = SimpleSieve(limit);
	
	int low = limit;
	int high = 2*limit;
	
	while(low < n)
	{
		var mark = new bool[limit];
		
		for(int i = 0; i < primes.Count; i++)
		{
			// Find the minimum number in [low..high] that is
            // a multiple of prime[i] (divisible by prime[i])
            // For example, if low is 31 and prime[i] is 3,
            // we start with 33.
            int loLim = (int)(Math.Floor((double)(low/primes[i]))) * primes[i];
            if (loLim < low)
                loLim += primes[i];
 
            /*  Mark multiples of prime[i] in [low..high]:
                We are marking j - low for j, i.e. each number
                in range [low, high] is mapped to [0, high-low]
                so if range is [50, 100]  marking 50 corresponds
                to marking 0, marking 51 corresponds to 1 and
                so on. In this way we need to allocate space only
                for range  */
            for (int j=loLim; j<high; j+=primes[i])
                mark[j-low] = true;
        }
		
		for(int k = low ; k < high; k++)
		{
			if(mark[k - low] == false)
			{
				Console.Write("{0} => ", k);
			}
		}
		
		low = low + limit;
		high = high + limit;
		
		if(high >= n)
		{
			high = n;
		}
	}	
}


