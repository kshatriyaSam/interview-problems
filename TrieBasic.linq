<Query Kind="Program" />

void Main()
{
	var inputArray = new []{"the", "a", "there", "answer", "any", "by", "bye", "their"};
	Trie trie = new Trie();
	
	trie.Initialize();
	
	for(int i = 0; i < inputArray.Length; i++)
	{
		trie.Insert(inputArray[i]);
	}
	
	var result = trie.Search("bye");
	
	result = trie.Search("tata");
	
	trie.Delete("by");
	result = trie.Search("bye");
	if (!result)
	{
		Console.WriteLine("deletion fails");
	}
}

public const int ALPHABET_SIZE = 26;

// Define other methods and classes here
public class TrieNode
{
	public int Value;
	public TrieNode[] Children;
	
	public TrieNode()
	{
		this.Children = new TrieNode[ALPHABET_SIZE];
		this.Value = -1;
	}
}

public class Trie
{
	public TrieNode root;
	
	public int Count;
	
	public void Initialize()
	{
		root = new TrieNode();
		
		for(int i = 0; i < ALPHABET_SIZE ; i++)
		{
			root.Children[i] = null;			
		}	
	}
	
	public void Insert(string inputString)
	{
		TrieNode current = root;
		
		for(int i = 0; i < inputString.Length; i++)
		{
			int index = inputString[i] - 'a';
			if(current.Children[index] == null)
			{
				current.Children[index] = new TrieNode();
			}
			
			current = current.Children[index];
		}
		
		current.Value = ++Count;
	}
	
	public bool Search(string searchString)
	{
		TrieNode current = root;
		
		for(int i = 0;  i < searchString.Length;i++)
		{
			int index = searchString[i] - 'a';
			if(current.Children[index] == null)
			{
				return false;
			}
			
			current = current.Children[index];
		}
		
		return current != null && current.Value != -1;
	}
	
	public void Delete(string deleteString)
	{
		this.DeleteHelper(root, deleteString, 0, deleteString.Length);
	}
	
	/*
	1. Key may not be there in trie. Delete operation should not modify trie.
	2. Key present as unique key (no part of key contains another key (prefix), nor the key itself is prefix of another key in trie). Delete all the nodes.
	3. Key is prefix key of another long key in trie. Unmark the leaf node.
	4. Key present in trie, having atleast one other key as prefix key. Delete nodes from end of key until first leaf node of longest prefix key.
	*/
	bool DeleteHelper(TrieNode root, string deleteString, int position, int length)
	{
		// did not find the string in the trie, delete it.
		if(root == null) return false;
		
		if(position == length)
		{
			// found the string in the trie.
			
			// unmark it as containing the string.
			root.Value = -1 ; 
			if( isFreeNode(root))
			{
				return true;
			}
		}
		else
		{
			int index = deleteString[position] - 'a';
			
			if(this.DeleteHelper(root.Children[index], deleteString, position + 1, length))
			{
				root.Children[index] = null;
				
				return !this.isLeafNode(root) && this.isFreeNode(root);
			}
		}
		
		return false;		
	}
	
	bool isFreeNode(TrieNode node)
	{
		for(int i = 0; i < ALPHABET_SIZE; i++)
		{
			if(node.Children[i] != null)
			{
				return false;
			}
		}
		
		return true;
	}
	
	bool isLeafNode(TrieNode node)
	{
		return node.Value != -1;
	}
}