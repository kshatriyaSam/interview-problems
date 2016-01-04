<Query Kind="Program" />

/*
You are given a setS of n numbers. You must pick a subset S of
k numbers from S such that the probability of each element of S occurring in S is equal 
(i.e., each is selected with probability k/n).
*/
void Main()
{
	var result = ReservoirSampling(new int[] {4,1,5,2,4,1,6,1,3,5,6}, 4);
}

// Define other methods and classes here
int[] ReservoirSampling(int[] data, int k)
{
	int[] kArray = new int[k];
	
	for(int i = 0; i < k; i++)
	{
		kArray[i] = data[i];
	}
	
	Random r = new Random();
	for(int j = k ; j < data.Length; j++)
	{
		int result = r.Next(j);
		if(j < k)
		{
			kArray[j] = data[result];
		}
	}
	
	return kArray;
}