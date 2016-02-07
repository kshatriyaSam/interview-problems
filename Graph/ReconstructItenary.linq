<Query Kind="Program" />

/*
Given a list of airline tickets represented by pairs of departure and arrival airports [from, to], reconstruct the itinerary in order. All of the tickets belong to a man who departs from JFK. Thus, the itinerary must begin with JFK.

Note:
If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string. For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
All airports are represented by three capital letters (IATA code).
You may assume all tickets may form at least one valid itinerary.
Example 1:
tickets = [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
Return ["JFK", "MUC", "LHR", "SFO", "SJC"].
Example 2:
tickets = [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
Return ["JFK","ATL","JFK","SFO","ATL","SFO"].
Another possible reconstruction is ["JFK","SFO","ATL","JFK","ATL","SFO"]. But it is larger in lexical order.

*/


/*
Solutions involves creating a Graph where the Vertices are sorted in Lexicographical order
Use the MinHeap to create the nearby Nodes


Now just traverse the Graph in Depth First Search. 

Good Test [["J", "K"], ["N", "J"], ["J", "N"]]
*/
public IList<string> FindItinerary(string[,] tickets)
    {
        if(tickets == null || tickets.GetLength(0) == 0) return null;
        
        
        if(tickets.GetLength(1) != 2) throw new Exception("Invalid number of Columns");
        
        // build the treepMap
        var treeMap = new Dictionary<string, MinHeap>();
        for(int i = 0; i < tickets.GetLength(0); i++)
        {
            if(!treeMap.ContainsKey(tickets[i, 0]))
            {
                treeMap[tickets[i, 0]] = new MinHeap();
                
            }
            
            treeMap[tickets[i, 0]].Insert(tickets[i, 1]);
        }
        
        int noOfTraversals = tickets.GetLength(0);
        
        var route = new List<string>();
  
  
  		// take note here how we keep going inside till we dont
		// find the next destination
         var stack = new Stack<string>();
         stack.Push("JFK");
         while (stack.Count != 0)
         {
             while (treeMap.ContainsKey(stack.Peek()) && !treeMap[stack.Peek()].IsEmpty())
             {
                 stack.Push(treeMap[stack.Peek()].ExtractMin());
             }
             
             route.Insert(0, stack.Pop());
        }
        
        return route;
    }
    
    public class MinHeap
    {
        IList<string> list;
        
        public MinHeap()
        {
            list = new List<string>();
        }
        
        public void Insert(string key)
        {
            list.Add(key);
            
            int i = list.Count -1;
            while(i != 0 && string.Compare(list[Parent(i)], list[i]) > 0)
            {
                Swap(Parent(i), i);
                i = Parent(i);
            }
        }
        
        int Left(int key)
        {
            return 2 * key + 1;
        }
        
        int Right(int key)
        {
            return 2 * key + 2;
        }
        
        int Parent(int key)
        {
            return (key - 1) /2;
        }
        
        public bool IsEmpty()
        {
            return list == null || list.Count == 0;
        }
        
        public string ExtractMin()
        {
            if(list.Count == 0)
            {
                return null;
            }
            
            string data = list[0];
            
            if(list.Count == 1)
            {
                list.RemoveAt(0);
                return data;
            }
            
            list[0] = list[list.Count -1];
            list.RemoveAt(list.Count-1);
            
            this.MinHeapify(0);
            
            return data;
        }
        
        private void MinHeapify(int index)
        {
            int left = Left(index);
            int right = Right(index);
            
            int smaller = index;
            
            if(left < list.Count && string.Compare(list[index], list[left]) > 0)
            {
                smaller = left;
            }
            
            if(right < list.Count && string.Compare(list[smaller], list[right]) > 0)
            {
                smaller = right;
            }
            
            if(smaller != index)
            {
                Swap(index, smaller);
                MinHeapify(smaller);
            }
        }
        
        private void Swap(int i, int j)
        {
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
