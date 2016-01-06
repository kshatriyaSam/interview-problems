<Query Kind="Program" />

void Main()
{
	var input = new [,] {
	{'1', '1', '0', '0', '0'},
	{'0', '1', '0', '0', '1'},
	{'1', '0', '0', '1', '1'},
	{'0', '0', '0', '0', '0'},
	{'1', '0', '1', '0', '1'},
	};
	
	var result = numOfIslands(input);
	result.Dump();
}

// Define other methods and classes here
public int numOfIslands(char[,] grid)
{
	if(grid == null || grid.GetLength(0) == 0)
	{
		return 0;
	}
	
	var visited = new bool[grid.GetLength(0), grid.GetLength(1)];
	
	int numOfIsland = 0;
	for(int i = 0; i < grid.GetLength(0); i++)
	{
		for(int j = 0; j < grid.GetLength(1); j++)
		{
			if(visited[i, j] == false && grid[i, j] == '1')
			{
				DFS(grid, visited, i, j);
				numOfIsland++;
			}
		}
	}
	
	return numOfIsland;
}

void DFS(char[,] grid, bool[,] visited, int row, int column)
{
	if(row < 0 || row > grid.GetLength(0) -1 
	|| column < 0 || column > grid.GetLength(1) -1 || 
	visited[row, column] == true || grid[row, column] == '0')
	{
		return;
	}
	
	visited[row, column] = true;
	DFS(grid, visited, row + 1, column);
	DFS(grid, visited, row - 1, column);
	DFS(grid, visited, row, column - 1);
	DFS(grid, visited, row, column + 1);
}
