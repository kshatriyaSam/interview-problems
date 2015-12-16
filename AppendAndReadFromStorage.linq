<Query Kind="Program">
  <Reference>D:\TfsGit\AAPT\APIManagement\packages\WindowsAzure.Storage.4.3.0\lib\net40\Microsoft.WindowsAzure.Storage.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Microsoft.WindowsAzure.Storage.Blob</Namespace>
</Query>

void Main()
{
	int maxCount = 100;

	List<string> totalDataDump = new List<string>();
	HashSet<string> setOfData = new HashSet<string>();
	while (maxCount-- > 0)
	{
		setOfData.Clear();
	   for (int i = 0 ; i < 500; i++)
	   {
		setOfData.Add(GenerateRandomString(Random.Next(3, 20)));
	   }
		
		totalDataDump.AddRange(setOfData);
		AppendSuccessfullyUpgradeContainersToBlobAsync(setOfData);
		var result = GetSuccessfullyUpgradedContainer();
		if (result.Count != totalDataDump.Count)
		{
			Console.WriteLine("Some issue");
		}
		
		foreach(var dump in totalDataDump)
		{
			if(!result.Contains(dump))
			{
				Console.WriteLine("{0} missing", dump);				
			}
		}		
	}
   
}

static readonly Random Random = new Random();
string storageConnectionString = "connectionstring"
string containerName = "apirpsasolank";
string resultBlobName = "testwritingToBlob";

 async void AppendSuccessfullyUpgradeContainersToBlobAsync(HashSet<string> successfullyUpgradeContainers)
        {
            var resultBlobName = "testwritingToBlob";

            StringBuilder appendDataBuilder = new StringBuilder();
            appendDataBuilder.Append(string.Join(",", successfullyUpgradeContainers));
            appendDataBuilder.Append(",");

            CloudStorageAccount cloudStorageAccount;
            if (!CloudStorageAccount.TryParse(storageConnectionString, out cloudStorageAccount))
            {
                Console.WriteLine("Could not parse CloudStorageAccount having value: {0}", storageConnectionString);
            }

            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // get reference to storage container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            // get the reference to mergedDataBlob
            CloudBlockBlob mergedDataBlob = container.GetBlockBlobReference(resultBlobName);
            
            this.AppendStreamToBlobAsync(mergedDataBlob, appendDataBuilder.ToString());
        }

        List<string> GetSuccessfullyUpgradedContainer()
        {
            var resultBlobName = "testwritingToBlob";
            
            CloudStorageAccount cloudStorageAccount;
            if (!CloudStorageAccount.TryParse(storageConnectionString, out cloudStorageAccount))
            {
                Console.WriteLine("Could not parse CloudStorageAccount having value: {0}", storageConnectionString);
            }

            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // get reference to storage container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            // get the reference to mergedDataBlob
            CloudBlockBlob mergedDataBlob = container.GetBlockBlobReference(resultBlobName);

            using (var memoryStream = new MemoryStream())
            {
                mergedDataBlob.DownloadToStreamAsync(memoryStream).Wait();
				memoryStream.Position = 0;
				using (var reader = new StreamReader(memoryStream))
                {
                    string blobData = reader.ReadToEnd();
                    string[] upgradeContainersList = blobData.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    return upgradeContainersList.ToList();
                }
            }
        }
		
		 public void AppendStreamToBlobAsync(CloudBlockBlob resultBlob, string appendData)
        {
            // clear of BlockIds from previous iteration
            var blockIds = new List<string>();
            try
            {
                
                
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(appendData)))
                {
                    // if the result blob exists determine the existing blockIDs
                    if (resultBlob.Exists())
                    {
                        IEnumerable<ListBlockItem> currentBlocks = resultBlob.DownloadBlockListAsync().Result;
						blockIds.AddRange(currentBlocks.Select(b => b.Name));
                    }

                    stream.Position = 0;
                    string blockIdBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(GenerateRandomString(resultBlob.Name.Length)));
                    resultBlob.PutBlockAsync(blockIdBase64, stream, null).Wait();
                    blockIds.Add(blockIdBase64);

                    // Commit the Blocks
                    resultBlob.PutBlockListAsync(blockIds).Wait();
                }
            }
            catch (StorageException exception)
            {
                Console.WriteLine("Exception trying to Append Data to Blob '{0}'. Exception: {1}", resultBlob.Name, exception);
            }
        }
		
		public static string GenerateRandomString(int size, string prefix = "", string suffix = "")
        {
		
            if (prefix == null)
            {
                prefix = "";
            }

            if (suffix == null)
            {
                suffix = "";
            }

            int randomStringLength = (size - prefix.Length) - suffix.Length;
                return prefix + new string(Enumerable.Repeat("abcdefghABCDEFGD123456", randomStringLength).Select(s => s[Random.Next(s.Length)]).ToArray()) + suffix;

        }

// Define other methods and classes here