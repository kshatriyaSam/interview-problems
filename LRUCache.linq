<Query Kind="Program" />

/*
Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.

get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
set(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

*/
void Main()
{
	var d = new LRUCache(1);
	d.Set(2,1);
	var result = d.Get(2);
	d.Set(3,2);
	result = d.Get(2);
	
}

// Define other methods and classes here
public class LRUCache {

    LinkedList<DLinked> dataList;
    int currentCapacity;
    readonly int MaxCapacity;
    
	/* need to create this structure, because 
	when we need to remove the element from cache, we also 
	need the key.
	*/
    class DLinked
    {
        public int key;
        public int value;
    }
    
    Dictionary<int, LinkedListNode<DLinked>> dataCache;
    
    public LRUCache(int capacity) 
    {
        this.dataList = new LinkedList<DLinked>();
        this.dataCache = new Dictionary<int, LinkedListNode<DLinked>>();
        
        this.currentCapacity = 0;
        this.MaxCapacity = capacity;
    }

    public int Get(int key)
    {
        if(dataCache.ContainsKey(key))
        {
            // get the Node and move it to front
            var node = this.dataCache[key];
            this.dataList.Remove(node);
            this.dataList.AddFirst(node);
            
            return node.Value.value;
        }
        
        return -1;
    }

    /*
	 check if there is update to existing key 
	 else	 
     if the currentCapacity is MaxCapacity, remove last node from list
     remove it from Cache, insert the new Node at the beginning
    */
    public void Set(int key, int value)
    {
        // if key is already existing override it
        if(this.dataCache.ContainsKey(key))
        {
            var node = this.dataCache[key];
            this.dataList.Remove(node);
            node.Value.value = value;
            this.dataList.AddFirst(node);
            this.dataCache[key] = node;
        }
        else
        {
            // insert a new Key, but check if max capacity has reached
            if(this.currentCapacity == this.MaxCapacity)
            {
                // we need to remove a element from the end;
                var lastNode = this.dataList.Last;
                this.dataList.RemoveLast();
                dataCache.Remove(lastNode.Value.key);
                this.currentCapacity = this.currentCapacity -1;
            }
            
            var newDlinkNode = new DLinked()
            {
                key = key,
                value = value
            };
            
            var newNode = new LinkedListNode<DLinked>(newDlinkNode);
            this.dataList.AddFirst(newNode);
            this.dataCache.Add(key, newNode);
            
            this.currentCapacity++;
        }
    }
}