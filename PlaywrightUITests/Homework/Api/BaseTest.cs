using System.Net;
using System.Text;
using Newtonsoft.Json;
using PlaywrightUiTests.Homework.Api.Models;

namespace PlaywrightUiTests.Homework.Api;

public abstract class BaseTest
{
    private readonly HttpClient _client;

    protected BaseTest(string? baseUrl)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl!)
        };
    }

    protected BaseTest(HttpClient client)
    {
        _client = client;
    }

    [OneTimeSetUp]
    public virtual void OneTimeSetUp()
    {
        Console.WriteLine("OneTimeSetUp: Setting up resources.");
    }

    protected async Task<(string? UserId, HttpStatusCode StatusCode)> AddUser(UserModel user)
    {
        var json = JsonConvert.SerializeObject(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("Account/v1/User", content);

        if (response.StatusCode != HttpStatusCode.Created)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return (null, response.StatusCode);
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var createdUser = JsonConvert.DeserializeObject<User>(responseContent);

        Console.WriteLine("User created successfully.");
        return (createdUser?.UserId, response.StatusCode);
    }

    protected async Task<string?> GenerateToken(UserModel model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response;
        try
        {
            response = await _client.PostAsync("Account/v1/GenerateToken", content);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
            throw;
        }

        if (response.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var responseToken = JsonConvert.DeserializeObject<UserToken>(responseContent);

        return responseToken!.Token;
    }

    protected static string GetCurrentTimestamp()
    {
        var currentTimestamp = DateTime.UtcNow;

        var timestamp = currentTimestamp.ToString("u");

        timestamp = Regex.Replace(timestamp, @"\D", "");

        return timestamp;
    }

    [OneTimeTearDown]
    public virtual void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown: Cleaning up resources.");
        _client.Dispose();
    }
}