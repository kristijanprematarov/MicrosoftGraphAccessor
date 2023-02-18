using Azure.Identity;
using Microsoft.Graph;
using System.Text.Json;

var scopes = new[] { "https://graph.microsoft.com/.default" };

var tenantId = "";
var clientId = "";
var clientSecret = "";

ClientSecretCredential? clientSecretCredential = new(tenantId, clientId, clientSecret);

GraphServiceClient graphSeviceClient = new(clientSecretCredential, scopes);

var users = await graphSeviceClient.Users
                                                             .Request()
                                                             .GetAsync();

foreach (var user in users)
{
    Console.WriteLine(JsonSerializer.Serialize(user, new JsonSerializerOptions
    {
        WriteIndented = true,
    }));
}



