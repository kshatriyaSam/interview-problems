<Query Kind="Program" />

/*
	Shorted path in Graph will only work
	1. BFS is perfomed with root as start element
	2. If it is Unweighted graph
	
	Time Complexity = O(V+E) where V is vertices and E are edges if it is implemented using adjacency list
	Time Complexity = O(V^2) where V is vertices if it is implemented as adjacency Matric
	For Dense Graph we can say Complexity is O(E)
*/
void Main()
{
	Graph g = new Graph(7, false);
	var edgeData = new int[,] {	{1,6}, {1,2}, {1,5}, {2,5}, {2,3}, {3,4}, {4,5}};
	
	g.CreateGraph(6, 7, edgeData);
	
	var parents = g.BreadthFirstSearch(2);	
	
	FindShortestPath(1, 4, parents);
}

/*
To Find the Shorted path we work from destination to root, hence 
we go to parents, as that is how the parents were constructed. 
There are 2 ways to implement it
1. Using Stack
2. Using Recursion
*/
void FindShortestPath(int start, int end, int[] parents)
{
	if(start == end || end == -1)
	{	
		Console.Write(", " + start);
	}
	else
	{
		FindShortestPath(start, parents[end], parents);
		Console.Write(", " + end);
	}
}

public class EdgeNode
{
	public int Data {get; set;}
	public int Weight { get; set;}
	public EdgeNode Next {get; set;}
	
}

public class Graph
{
	public EdgeNode[] EdgeNodes {get; set;}
	public int NumVertices {get; set;}
	public int NumEdges {get; set;}
	public int[] EdgesCount {get; set;}
	public bool isDirected {get; set;}
	readonly int MaxVertices;
	
	public Graph(int vertices, bool isDirected)
	{
		this.MaxVertices = vertices;
		this.EdgeNodes = new EdgeNode[vertices];
		EdgesCount = new int[vertices];
		this.isDirected = isDirected;		
		
		this.InitializeGraph();		
	}
	
	void InitializeGraph()
	{
		for(int i = 0; i < this.MaxVertices; i++)
		{
			this.EdgeNodes[i] = null;
			this.EdgesCount[i] = 0;
		}
	}
	
	public void CreateGraph(int numOfVertices, int numOfEdges, int[,] edgeData)
	{
		for(int i = 0; i < numOfEdges; i++)
		{
			InsertEdge(edgeData[i,0], edgeData[i,1], this.isDirected);
		}		
	}
	
	void InsertEdge(int x, int y, bool directed)
	{
		EdgeNode edgeNode = new EdgeNode();
		edgeNode.Data = y;
		edgeNode.Weight = 0;
		edgeNode.Next = null;
		
		if(this.EdgeNodes[x] == null)
		{
			this.NumVertices++;
		}
		
		edgeNode.Next = this.EdgeNodes[x];
		this.EdgeNodes[x] = edgeNode; // insert as First Node;
		this.EdgesCount[x]++;
		
		if(directed == false)
		{
			InsertEdge(y, x, true);
		}
		
		this.NumEdges++;
	}
	
	public void PrintGraph()
	{
		int edges = 0;
		for(int i = 0; i < this.MaxVertices && edges < this.MaxVertices; i++)
		{
			if(this.EdgeNodes[i] != null)
			{
				Console.Write("Vertex {0}", i);
				EdgeNode current = this.EdgeNodes[i];
				while(current != null)
				{
					Console.Write("-> : {0}", current.Data);
					current = current.Next;
				}
				
				edges++;
				Console.WriteLine("");
			}			
		}
	}
	
	/*
	Each Node goes from Undiscovered -> Discovered -> Processed state.
	We Enqueue the start node and process it completely before moving to the next node in the queue.
	*/
	public int[] BreadthFirstSearch(int startNodeValue)
	{
		bool[] discovered = new bool[this.MaxVertices];
		bool[] processed  = new bool[this.MaxVertices];
		int[] parent = new int[this.MaxVertices];		
		for(int i = 0; i < this.MaxVertices;i++)
		{
			parent[i]  = -1;
		}
		
		var q = new Queue<int>();
		q.Enqueue(startNodeValue);
		
		discovered[startNodeValue] = true;
		
		while(q.Count != 0)
		{
			int vertex = (int)q.Dequeue();
			processed[vertex] = true; // mark the node as processed
			Console.WriteLine("Processed Vertex {0}", vertex);		// One place to do operations	
			EdgeNode p = this.EdgeNodes[vertex];
			
			// traverse the entire adjacency list
			while(p != null)
			{
				int successor = p.Data;
				if(processed[successor] == false || this.isDirected)
				{
					// process edge vertex -> successor, maybe Count
					Console.WriteLine("Processed Edge {0}-> {1}", vertex, successor);
				}
				
				if(discovered[successor] == false)
				{
					// Perform any operation on the discovered vertex.
					discovered[successor] = true;
					q.Enqueue(successor);
					parent[successor] = vertex;
				}
				
				// perform any operation on the Vertex
				p = p.Next;
			}		
		}
		
		// Shortest path between two nodes
		for(int i = 0; i<this.MaxVertices;i++)
		{
			if(parent[i] != -1)
			{
				Console.WriteLine("Nearest Vertex of {0} ->{1}", i, parent[i]);
			}			
		}
		
		return parent;
	}
}