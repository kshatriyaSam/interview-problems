<Query Kind="Program" />

void Main()
{
	var board = new[,] {{'1', '1', '0', '0', '0'},
                    	{'0', '1', '0', '0', '1'},
                    	{'1', '0', '0', '1', '1'},
                    	{'0', '0', '0', '0', '0'},
                    	{'1', '0', '1', '0', '1'}};
					
	var sol = new Solution();				
	Console.WriteLine(sol.numIslands(board)); 
}

class Solution
{
	int[] a;	
	int n;
	
	public int parent(int x)
	{
		while(x!=a[x])
		{
			x = a[x];
		}
		
		return x;
	}
	
	public void union(int x, int y)
	{
		x = parent(x);
		y = parent(y);
		if(x!=y)
		{
			a[x] = y;
		}
	}
	
	public int numIslands(char[,] grid)
	{
		int l = grid.GetLength(0);
		
		if(l==0)return 0;
		
		int l1 = grid.GetLength(1);
		n = l*l1;
		a = new int[n];
	
		for(int i = 0, k = 0 ; i < l; i++)
		{
			for(int j = 0 ; j < l1; j++,k++)
			{
				if(grid[i, j]=='0')
				{
					a[k] = -1;
				}
				else
				{
					a[k] = k;
				}
			}
		}
	
		for(int i = 0, k = 0 ; i < l; i++)
		{
			for(int j = 0 ; j < l1; j++,k++)
			{
				if(grid[i, j]=='1')
				{
					if(i!=l-1 && grid[i+1, j]=='1')
					{
						union(k,k+l1);
					}
					if(j!=l1-1 && grid[i, j+1]=='1')
					{
						union(k,k+1);
					}
				}
			}
		}
		
		int count = 0;
		for(int i = 0 ; i < n ; i++)
		{
			if(a[i]!=-1 && a[i]==i)
			{
				count++;
			}
		}
	
		return count;
	}
}
    
