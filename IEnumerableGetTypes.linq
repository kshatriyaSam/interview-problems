<Query Kind="Program" />

void Main()
{
	HelloHost hello = new HelloHost();
	HowdieHost howdie = new HowdieHost();
	YahooHost yahoo = new YahooHost();
	
	var hostEnumerable = new List<IHost>()
	{
	hello,
	howdie,
	yahoo	
	};
	
	var yahoohost = hostEnumerable.Find( h => h.GetType() == typeof(YahooHost));
	yahoohost.Start();	
	
}

public interface IHost
{
 void Start();
 void Stop();
}

public class HelloHost: IHost
{
	public void Start()
	{
	 Console.WriteLine("Hello Host start");
	}
	
	public void Stop()
	{
	 Console.WriteLine("Hello Host stop");
	}
}

public class HowdieHost: IHost
{
	public void Start()
	{
	 Console.WriteLine("Howdie Host start");
	}
	
	public void Stop()
	{
	 Console.WriteLine("Howdie Host stop");
	}
}

public class YahooHost: IHost
{
	public void Start()
	{
	 Console.WriteLine("Yahoo Host start");
	}
	
	public void Stop()
	{
	 Console.WriteLine("Yahoo Host stop");
	}
}

// Define other methods and classes here
