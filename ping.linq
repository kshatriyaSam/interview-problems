<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.WebRequest.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Cache</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	TimeSpan delayTimer = TimeSpan.FromMilliseconds(50);
	while(true)
	{	/*
	    try
		{
			PingAsync("https://portalbvtcjt.preview.int-azure-api.net/echo/resource").Wait();
			Console.WriteLine("[{0}]: Portal Ping succeeded", DateTime.UtcNow);			
		}
		catch(Exception e)
		{
			delayTimer = TimeSpan.FromSeconds(5);
		  Console.WriteLine("[{0}]: Portal Ping failed {1}", DateTime.UtcNow, e.Message);
		}
		*/
		
		
		try
		{
			PingAsync("https://portalbvtcjt.preview.int-azure-api.net/echo/resource").Wait();
			Console.WriteLine("[{0}]: Proxy Ping succeeded", DateTime.UtcNow);
		}
		catch(Exception e)
		{
		  Console.WriteLine("[{0}]: Proxy Ping failed {1}", DateTime.UtcNow, e.Message);
		}
	
		Thread.Sleep(delayTimer);
	}
}


 static async Task<HttpResponseMessage> PingAsync(string requestUri)
        {
		
            using (var client = new HttpClient(
                new WebRequestHandler
                {
                    CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.BypassCache),
                    ServerCertificateValidationCallback = (s, cer, ch, pol) => true,
                    AllowAutoRedirect = false					
                }))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
                {
					request.Headers.Add("Ocp-Apim-Subscription-Key","55eecbeb1adc4b679f31397ed376d186");
					client.Timeout = TimeSpan.FromSeconds(1);
                    var response = await client.SendAsync(request);
                    if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Redirect)
                    {
                        throw new Exception(string.Format("{0} : {1}",response.StatusCode, response.ReasonPhrase));
                    }

                    return response;
                }
            }
        }
// Define other methods and classes here