<Query Kind="Program" />

// A stack is given which supports the following methods. Push, pop, peek and isEmpty. Sort this stack irrespective of its inner structure.
void Main()
{
    string[] array = {"z", "b", "d", "g" };
	Stack stack = new Stack();
	foreach(string element in array)
	{
		stack.Push(element);
	}
	
	//PrintStack(stack);
	
	sortStack(stack);
	
	PrintStack(stack);
}

static void sortStack(Stack stack)
 {
  if (IsEmpty(stack))
   return;
  string top = stack.Pop().ToString();
  sortStack(stack);
  insertSorted(top, stack);
  return;
 }

 static void insertSorted(string top, Stack stack)
 {
  if (IsEmpty(stack) || stack.Peek().ToString().CompareTo(top) > 0)
  {
   stack.Push(top);
   return;
  }
  
  string smaller = stack.Pop().ToString();
  insertSorted(top, stack);
  stack.Push(smaller);
 }


static bool IsEmpty(Stack stack)
{
	return stack.Count == 0;
}

static void PrintStack(Stack stack)
{
	while(stack.Count != 0)
	{
		Console.Write(stack.Pop() + " => ");
	}
}

// Define other methods and classes here
