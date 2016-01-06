<Query Kind="Program" />

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