<Query Kind="Program" />

/*
Bellman Ford Algorithm for finding Shortest Path in the Graph with Negative Weights.

Time Complexity = O(VE);

Bellman-Ford works better (better than Dijksra’s) for distributed systems. 
Unlike Dijksra’s where we need to find minimum value of all vertices, in Bellman-Ford, edges are considered one by one.
*/
void Main()
{
	Graph g = new Graph(6, true);
	/*
	 A typical graph format consists of an initial line featuring the number of vertices and edges in the graph,
	 followed by a listing of the edges at one vertex pair per line.
	 e.g 5 (vertices), 3 (edges)
	 	1->2 (W 
	 	2->3
	 	3->2
	*/
	var edgeData = new int[8, 3] {	{0,1,1}, {0, 2, 4 }, {1,2,3}, {1,3,2}, {1,4,2}, {3,2,5}, {3,1,1}, {4,3,3}};
	
	g.CreateGraph(5, 8, edgeData);
	
	g.PrintGraph();
	
	g.Dijkstra(3);	
}

// Define other methods and classes here
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
	
	/*
		
	*/
	public void Dijkstra(int key)
	{	
		int[] distance = new int[this.MaxVertices];
		int[] shortParent = new int[this.MaxVertices];
		bool[] intree = new bool[this.MaxVertices];
		
		// initialize the array;
		for(int i = 0; i < this.MaxVertices;i++)
		{
			intree[i] = false;
			distance[i] = Int32.MaxValue;
			shortParent[i] = -1;
		}
		
		distance[key] = 0;
		
		int v = key;
		
		while(intree[v] == false)
		{
			intree[v] = true;
			
			var p = this.EdgeNodes[v];
			
			while(p != null)
			{
				int dest = p.Data;
				int weight = p.Weight;
				if( distance[dest] > distance[v] + weight)
				{
					distance[dest] = distance[v] + weight;
					shortParent[dest]  = v;
				}
				
				p = p.Next;
			}
			
			// now find the smallest distance amoung uncovered nodes;
			v = 0;
			int dist = int.MaxValue;
			
			for(int i = 0 ; i < this.MaxVertices; i++)
			{
				if(intree[i] == false && dist > distance[i])
				{
					dist = distance[i];
					v = i;
				}
			}
		}
		
		for(int i = 0 ; i < this.MaxVertices; i++)
		{
			Console.WriteLine("Shortest Distance :{0} with Parent: {1}", distance[i], shortParent[i]);
		}
		
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
			InsertEdge(edgeData[i,0], edgeData[i,1], edgeData[i,2], this.isDirected);
		}		
	}
	
	void InsertEdge(int x, int y, int weight, bool directed)
	{
		EdgeNode edgeNode = new EdgeNode();
		edgeNode.Data = y;
		edgeNode.Weight = weight;
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
			InsertEdge(y, x, weight, true);
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
					Console.Write("-> : {0} (W:{1})", current.Data, current.Weight);
					current = current.Next;
				}
				
				edges++;
				Console.WriteLine("");
			}			
		}
	}
}