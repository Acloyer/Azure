using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

class Program
{
    private static readonly string EndpointUri = "https://myau.documents.azure.com:443/";
    private static readonly string PrimaryKey = "d41ErXE2KxLGaVQqiWx0D0Pm9QqSw0ywZSerDerQkxIvbjT7zApl5cuHwnWJPcUtVT8ExA6oJDOdACDb0wxVNw==";
    private static CosmosClient cosmosClient;

    static async Task Main(string[] args)
    {
        cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        var databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync("TestDatabase");
        var containerResponse = await databaseResponse.Database.CreateContainerIfNotExistsAsync("TestContainer", "/id");
        Console.WriteLine("Подключено к Azure Cosmos DB");
    }
}
