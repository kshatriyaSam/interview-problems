<Query Kind="Program" />

void Main()
{
	Graph g = new Graph(7, false);
	var edgeData = new int[,] {	{1,6}, {1,2}, {1,5}, {2,5}, {2,3}, {3,4}, {4,5}};
	
	g.CreateGraph(6, 7, edgeData);
	
	g.DepthFirstSearch(2);
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
	
	int time;
	
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
	
	public void DepthFirstSearch(int startValue)
	{
		int[] parent = new int[this.MaxVertices];
		int[] entryTime = new int[this.MaxVertices];
		int[] exitTime = new int[this.MaxVertices];
		
		bool[] visited = new bool[this.MaxVertices];
		bool[] processed = new bool[this.MaxVertices];
		for(int i= 0; i< this.MaxVertices;i++)
		{
			parent[i] = -1;
			entryTime[i] = 0;
			exitTime[i] = 0;
			exitTime[i] = 0;
			visited[i] = false;
			processed[i] = false;		
		}
		
		DepthFirstSearchUtil(startValue, visited, processed, parent, entryTime, exitTime);
	}
	
	void DepthFirstSearchUtil(int startValue, bool[] discovered, bool[] processed, int[] parent, int[] entryTime, int[] exitTime)
	{
		discovered[startValue] = true;
		time = time + 1;
		entryTime[startValue] = time;
		
		var p = this.EdgeNodes[startValue];
		
		while(p != null)
		{
			int successor = p.Data;			
			if (discovered[successor] == false)
			{
				parent[successor] = startValue;
				DepthFirstSearchUtil(successor, discovered, processed, parent, entryTime, exitTime);
			}
			else if((!processed[successor] && parent[successor] != startValue) || this.isDirected)
			{
				Console.WriteLine("Edge {0} -> {1}", startValue, successor);
			}
			
			p = p.Next;
		}
		
		Console.WriteLine("Processed Vertex : {0}", startValue);
		time = time + 1;
		exitTime[startValue] = time;
		
		processed[startValue] = true;
	}
}
