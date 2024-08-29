using System.Net;

namespace Diploma.ApiMethods;

public class UserManagement(HttpClient httpClient)
{
    public async Task CreateUserViaApi(string baseUrl, Dictionary<string, string> userData)
    {
        var content = new MultipartFormDataContent();

        foreach (var (key, value) in userData)
        {
            content.Add(new StringContent(value), key);
        }

        var response = await httpClient.PostAsync($"{baseUrl}/api/createAccount", content);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Unexpected status code: {response.StatusCode}");
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        if (!responseContent.Contains("User created!"))
        {
            throw new Exception($"Unexpected response message: {responseContent}");
        }
    }

    public async Task DeleteUserViaApi(string baseUrl, string email, string password)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("email", email),
            new KeyValuePair<string, string>("password", password)
        });

        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/api/deleteAccount")
        {
            Content = content
        };

        var response = await httpClient.SendAsync(requestMessage);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Unexpected status code: {response.StatusCode}");
        }
        
        var responseContent = await response.Content.ReadAsStringAsync();
        
        if (!responseContent.Contains("Account deleted!"))
        {
            throw new Exception($"Unexpected response message: {responseContent}");
        }
    }
}