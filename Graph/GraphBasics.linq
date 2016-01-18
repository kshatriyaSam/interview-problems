<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(10, false);
	/*
	 A typical graph format consists of an initial line featuring the number of vertices and edges in the graph,
	 followed by a listing of the edges at one vertex pair per line.
	 e.g 3 (vertices), 3 (edges)
	 	1->2
	 	2->3
	 	3->2
	*/
	var edgeData = new int[3, 2] {	{1,2}, {2,3}, {3,1}	};
	
	g.CreateGraph(3, 3, edgeData);
	
	g.PrintGraph();
	
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
			InsertEdge(edgeData[i,0], edgeData[i,1], false);
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
}

