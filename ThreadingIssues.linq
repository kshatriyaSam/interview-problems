<Query Kind="Program" />

void Main()
{
 	
	/*
	// Case 1: Lambda share local value
	for (int i = 0; i <= 10; i++)
    {
		int vari = i;
        Thread thread = new Thread(()=> Console.Write(vari));
        thread.Start();
    }
  
  	*/
	
	/*
	// Case 2: 
	// Try/catch/finally blocks in scope when a thread is created, are of no relevance to the thread when it starts executing
	try
	{
        Thread thread = new Thread( ()=> Divide(10,0));
        thread.Start();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An exception occured");
    }
	*/
	Console.Read();
}


static int Divide(int num , int d)
{
	return num/d;
}