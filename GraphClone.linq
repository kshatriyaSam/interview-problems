<Query Kind="Program" />

void Main()
{
	var console = Console.Read() - '0';
	
	switch(console)
	{
		case 1: // null node;
		{	
			Node a = new Node("a");
			var result = this.Clone(null);
			Debug.Assert(result == null);	
		}
		break;
		
		case 2: // Single Node Graph
		{
			var input = new Dictionary<string, string[]> { {"a", new string[] {"a"}} };
			// construct the graph
			var dictionaryOfInpuNodes = this.ConstructInputGraph(input);
			
			// Clone it
			Node a = dictionaryOfInpuNodes["a"];			
			var copyNode = this.Clone(a);
						
			// Construct the output Graph
			var dictionaryOfOutputNodes = this.BreadthFirstSearch(copyNode);
			
			// Validate the Cloning
			this.DeepValidateCloning(dictionaryOfInpuNodes, dictionaryOfOutputNodes);	
		}
		break;
		
		case 3: // Isolated Node Graph
		{
			var input = new Dictionary<string, string[]> {
				{"a", new string[] {"b", "b"}},
				{"b", new string[] {"a", "a", "c"}},
				{"c", new string[] {"b"}}
			};
			
			// construct the graph
			var dictionaryOfInpuNodes = this.ConstructInputGraph(input);
			
			// Clone it
			Node a = dictionaryOfInpuNodes["a"];			
			var copyNode = this.Clone(a);
			
			// Construct the output Graph
			var dictionaryOfOutputNodes = this.BreadthFirstSearch(copyNode);
			
			// Validate the Cloning
			this.DeepValidateCloning(dictionaryOfInpuNodes, dictionaryOfOutputNodes);			
		}
		break;
		
		case 4: // Multiple Cycles Graph
		{
			var input = new Dictionary<string, string[]> {
				{"a", new string[] {"b", "b", "a"}},
				{"b", new string[] {"a", "a", "c"}},
				{"c", new string[] {"b"}}
			};
			
			// construct the graph
			var dictionaryOfInpuNodes = this.ConstructInputGraph(input);
			
			// Clone it
			Node a = dictionaryOfInpuNodes["a"];			
			var copyNode = this.Clone(a);
			
			// Construct the output Graph
			var dictionaryOfOutputNodes = this.BreadthFirstSearch(copyNode);
			
			// Validate the Cloning
			this.DeepValidateCloning(dictionaryOfInpuNodes, dictionaryOfOutputNodes);			
		
		}
		break;
		case 5: // Sparse Graph
		{
			var input = new Dictionary<string, string[]> {
				{"a", new string[] {"b", "d"}},
				{"b", new string[] {"a", "c"}},
				{"c", new string[] {"b", "d"}},
				{"d", new string[] {"c", "a"}}
			};
			
			// construct the graph
			var dictionaryOfInpuNodes = this.ConstructInputGraph(input);
			
			// Clone it
			Node a = dictionaryOfInpuNodes["a"];			
			var copyNode = this.Clone(a);
			
			// Construct the output Graph
			var dictionaryOfOutputNodes = this.BreadthFirstSearch(copyNode);
			
			// Validate the Cloning
			this.DeepValidateCloning(dictionaryOfInpuNodes, dictionaryOfOutputNodes);			
		
		}
		break;
		case 6: // Dense Graph
		{
			var input = new Dictionary<string, string[]> {
				{"a", new string[] {"b", "c", "d", "e"}},
				{"b", new string[] {"a", "c", "d", "e"}},
				{"c", new string[] {"a", "b", "d", "e"}},
				{"d", new string[] {"a", "b", "c", "e"}},
				{"e", new string[] {"a", "b", "c", "d"}}
			};
			
			// construct the graph
			var dictionaryOfInpuNodes = this.ConstructInputGraph(input);
			
			// Clone it
			Node a = dictionaryOfInpuNodes["a"];			
			var copyNode = this.Clone(a);
			
			// Construct the output Graph
			var dictionaryOfOutputNodes = this.BreadthFirstSearch(copyNode);
			
			// Validate the Cloning
			this.DeepValidateCloning(dictionaryOfInpuNodes, dictionaryOfOutputNodes);
		}
		break;
		
		default:
		break;
	}
	
}

public class Node
{
	public string Name;
	public List<Node> Neighbours;
	
	public Node(string name)
	{
		this.Name = name;
		this.Neighbours = new List<Node>();
	}
	

}

public Node Clone(Node inputNode)
{
	if(inputNode == null) return null;
		
	var processed = new List<Node>();
	
	/* missing this structure to track clones
		Key = Node from original Graph
		Value = New Clone Node
	*/
	var dictionaryOfClones = new Dictionary<Node, Node>();
	
	var q = new Queue<Node>();
	
	// enqueue and adding to the dictionaryOfClones together
	q.Enqueue(inputNode);	
	var cloneNode = new Node(inputNode.Name);
	dictionaryOfClones.Add(inputNode, cloneNode);
	
	while(q.Count != 0)
	{
		var currentNode = (Node)q.Dequeue();
		
		// we have completely processed this node, move on
		if(processed.Contains(currentNode)) continue;
						
		var cloneNodeOfCurrent = dictionaryOfClones[currentNode];
		
		// traverse all neighbours of the currentNode;
		foreach(Node neighbour in currentNode.Neighbours)
		{
			if(!dictionaryOfClones.ContainsKey(neighbour))
			{
				// we have not seen this node Enqueue it and add its clone to dictionaryOfClone
				q.Enqueue(neighbour);
				Node neighbourClone = new Node(neighbour.Name);
				dictionaryOfClones.Add(neighbour, neighbourClone);
			}
			
			// add to the adjacency list of the Clone like the parent node
			cloneNodeOfCurrent.Neighbours.Add(dictionaryOfClones[neighbour]);			
		}
		
		// once we have traversed all the neighbours, we are done with this node.
		processed.Add(currentNode);
	}
	
	return cloneNode;	
}

public Dictionary<string, Node> BreadthFirstSearch(Node input)
{
	var q = new Queue<Node>();
	
	var result = new Dictionary<string, Node>();
	var processed = new List<Node>();
	
	q.Enqueue(input);
	result.Add(input.Name, input);	
	
	while(q.Count != 0)
	{
		Node current = (Node)q.Dequeue();
		
		if(processed.Contains(current)) continue;
		
		foreach(Node neighbour in current.Neighbours)
		{
			if(!result.ContainsKey(neighbour.Name))
			{
				result.Add(neighbour.Name, neighbour);
				q.Enqueue(neighbour);
			}
		}
		
		processed.Add(current);
	}
	
	return result;	
}

public void DeepValidateCloning(Dictionary<string, Node> inputNodes, Dictionary<string, Node> outputNodes)
{
	Debug.Assert(inputNodes != null);
	Debug.Assert(outputNodes != null);	
	Debug.Assert(inputNodes.Count != outputNodes.Count);
			
	foreach(var inputNode in inputNodes)
	{
		var outputNode = outputNodes[inputNode.Key];
		
		Debug.Assert(outputNode.Neighbours.Count == inputNode.Value.Neighbours.Count);
						
		for(int i = 0; i < outputNode.Neighbours.Count; i++)
		{
			Debug.Assert(inputNode.Value.Neighbours[i].Name == outputNode.Neighbours[i].Name); // name should be same
			Debug.Assert(inputNode.Value.Neighbours[i] != outputNode.Neighbours[i]); // nodes should be different
		}
	}
}

public Dictionary<string, Node> ConstructInputGraph(Dictionary<string, string[]> inputData)
{	
	var dictionaryOfNode = new Dictionary<string, Node>();
	
	if(inputData == null) return null;
			
	// construct the input Graph
	foreach(string key in inputData.Keys)
	{
		if(!dictionaryOfNode.ContainsKey(key))
		{
			Node n = new Node(key);
			dictionaryOfNode[key] = n;						
		}
		
		Node temp = dictionaryOfNode[key];
		
		foreach(string value in inputData[key])
		{
			if(!dictionaryOfNode.ContainsKey(value))
			{
				Node n = new Node(value);
				dictionaryOfNode[value] = n;
			}
			
			temp.Neighbours.Add(dictionaryOfNode[value]);
		}
	}
	
	return dictionaryOfNode;
}