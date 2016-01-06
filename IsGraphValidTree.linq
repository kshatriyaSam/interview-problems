<Query Kind="Program" />

void Main()
{
	var input = new [,] {{0, 1}, {0, 2}, {0, 3}, {1, 4}};
	
	var result = IsGraphValidTree(5, input);
	Debug.Assert(result == true);
}

public bool IsGraphValidTree(int vertexCount, int[,] edges)
{
	// create the adjacency list
	var adjList = new List<List<int>>();
	
	for(int i = 0 ;i < vertexCount;i++)
	{
		adjList.Add(new List<int>());	
	}
	
	for(int i = 0; i < edges.GetLength(0); i++)
	{
		adjList.ElementAt(edges[i, 0]).Add(edges[i, 1]);
		adjList.ElementAt(edges[i, 1]).Add(edges[i, 0]);
	}
	
	var processed = new bool[vertexCount];
	
	var q = new Queue<int>();
	q.Enqueue(0);
	
	while(q.Count != 0)
	{
		var current = (int)q.Dequeue();
		
		// each node should be processed only once.
		if(processed[current] == true) return false;
		
		foreach(int neighbour in adjList[current])
		{
			if(processed[neighbour] == false)
			{
				q.Enqueue(neighbour);
			}
		}
		
		processed[current] = true;
	}
	
	// find isolated node
	for(int i = 0 ;i < vertexCount; i++)
	{
		if(processed[i] == false)
		{
			return false;
		}
	}
	
	return true;
}