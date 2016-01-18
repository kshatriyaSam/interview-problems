<Query Kind="Program" />

/*
A number is called as a Jumping Number if all adjacent digits in it differ by 1. The difference between ‘9’ and ‘0’ is not considered as 1.
All single digit numbers are considered as Jumping Numbers. For example 7, 8987 and 4343456 are Jumping numbers but 796 and 89098 are not.

Given a positive number x, print all Jumping Numbers smaller than or equal to x.
*/
void Main()
{
	PrintJumpingNumbers(600);
}

void PrintJumpingNumbers(int num)
{
	for(int i = 1; i <=9 && i <=num ;i++)
	{
		BFSGraph(num, i);
	}
}

/*
	Solution is based on Graph BFS traversal. How we can go to the nearest 
	Node. From each node, we can append *10 + 1 or *10 - 1
*/
void BFSGraph(int num, int index)
{
	var q = new Queue<int>();
	q.Enqueue(index);
	
	while(q.Count != 0)
	{
		var temp = (int)q.Dequeue();
		
		if(temp < num)
		{	
			Console.Write("{0} =>", temp);
			var lastDigit = temp % 10;
			if(lastDigit == 0)
			{
				q.Enqueue(temp * 10 + lastDigit + 1);
			}
			else if(lastDigit == 9)
			{
				q.Enqueue(temp * 10  + lastDigit -1);
			}
			else
			{
				q.Enqueue(temp * 10 + lastDigit + 1);
				q.Enqueue(temp * 10 + lastDigit - 1);
			}
		}			
		
	}	
}
