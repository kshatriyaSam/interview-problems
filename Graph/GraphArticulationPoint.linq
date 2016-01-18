<Query Kind="Program" />


	/*
		Articulation Point are Nodes in a graph, which if broken 
		will split the Graph. These are the critical edges which find
		weak points in a Network Design.
		
		They can be found DFS O(V+E) and Nodes which satisfy the following Conditions
		1. The Node A is a root and it has two or More Children
		2. The Node A is not a root, and none of the Children have a lower discovery time than the Parent
		i.e. there is No back edge from its children
		
		Note: Leaf Nodes are not Critical Edges.
	*/
	
void Main()
{

	Graph g1 = new Graph(5);
    g1.InsertEdge(1, 0);
    g1.InsertEdge(0, 2);
    g1.InsertEdge(2, 1);
    g1.InsertEdge(0, 3);
    g1.InsertEdge(3, 4);
    g1.ArticulationPoint();
	
}

// Define other methods and classes here
public class Graph
{
	List<EdgeNode> Nodes;
	public int Vertices;
	
	public Graph(int vertices)
	{
		this.Vertices = vertices;
		Nodes = new List<EdgeNode>(this.Vertices);
		Initialize();
	}
	
	void Initialize()
	{
		for(int i = 0; i < this.Vertices; i++)
		{
			var p = new EdgeNode(i);
			this.Nodes.Add(p);
		}		
	}
	
	public void InsertEdge(int x, int y)
	{
		var xNode = new EdgeNode(x);
		var yNode = new EdgeNode(y);
		
		if(Nodes[x] != null)
		{
			yNode.Next = Nodes[x];
		}
		
		Nodes[x] = yNode;
		
		if(Nodes[y] != null)
		{
			xNode.Next = Nodes[y];
		}
		
		Nodes[y]  = xNode;
	}
	
	public void ArticulationPoint()
	{
		bool[] visited = new bool[this.Vertices]; // keeps track which nodes are visited
		int[] disc = new int[this.Vertices]; // discovery time of the Node
		int[] low = new int[this.Vertices]; 
		int[] parent = new int[this.Vertices];
		bool[] ap = new bool[this.Vertices]; // articulation point
		
		for(int i = 0; i < this.Vertices; i++)
		{
			APUtil(i, visited, disc, low, parent, ap);
		}
		
		for(int i = 0; i < this.Vertices; i++)
		{
			if(ap[i] == true)
			{
				Console.Write("{0} =>", i);
			}
		}
	
	}
	
	static int time = 0;
	public void APUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent, bool[] ap)
	{
		int children = 0;
		visited[u] = true;
		
		disc[u] = low[u] = ++time;
		
		var p = this.Nodes[u];
		
		while(p != null)
		{
			if(!visited[p.Value])
			{
				++children;
				parent[p.Value] = u;
				
				APUtil(p.Value, visited, disc, low, parent, ap);
				
				low[u] = Math.Min(low[u], low[p.Value]);
				
				// if U is root node, having more than 2 children
				if(parent[u] == -1 && children > 1)
				{
					ap[u] = true;					
				}
				
				// if U is not a root Node and low Value of its Children is still greater than Parent
				if(parent[u] != -1 && low[p.Value] >= disc[u])
				{
					ap[u] = true;
				}
			}
			else if(parent[u] != p.Value)
			{
				low[u] = Math.Min(low[u], disc[p.Value]);
			}
			
			p = p.Next;		
		}
	}
}

public class EdgeNode
{
	public int Value;
	public EdgeNode Next;
	
	public EdgeNode(int data)
	{
		this.Value = data;
	}
}
