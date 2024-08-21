using System.Diagnostics;
using System.Net;
using PlaywrightUiTests.Homework.Api.Models;

namespace PlaywrightUiTests.Homework.Api.Tests;

public class DeleteUser() : BaseTest("https://demoqa.com/")
{
    private static readonly UserModel UserUnderTest = new()
    {
        userName = "Usr" + GetCurrentTimestamp(),
        password = "Pa$$word1"
    };

    [Test]
    public async Task DeleteUserViaScript()
    {
        var (userId, statusCode) = await AddUser(UserUnderTest);
        Assert.Multiple(() =>
        {
            Assert.That(userId, Is.Not.Null, "User was not created.");
            Assert.That(statusCode, Is.EqualTo(HttpStatusCode.Created), "User was not created.");
        }); // added as a debug line
        Console.WriteLine($"User ID: {userId}, Status Code: {statusCode}");

        var token = await GenerateToken(UserUnderTest);
        Console.WriteLine($"Token: {token}"); // added as a debug line
        Assert.That(token, Is.Not.Null, "Token was not generated.");

        var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
        var scriptsDirectory = Path.Combine(projectDirectory, "PlaywrightUITests", "Homework", "Api", "Scripts");
        var scriptPath = Path.Combine(projectDirectory, "PlaywrightUITests", "Homework", "Api", "Scripts", "DeleteUser.ps1");
        
        if (!Directory.Exists(scriptsDirectory))
        {
            Directory.CreateDirectory(scriptsDirectory);
            Console.WriteLine($"Created Scripts directory at path: {scriptsDirectory}");
        }

        if (!File.Exists(scriptPath))
        {
            const string scriptContent = """
                                         param (
                                             [string]$BaseUrl,
                                             [string]$UserId,
                                             [string]$Token
                                         )
                                         
                                         $Headers = @{
                                             "Authorization" = "Bearer $Token"
                                             "Content-Type" = "application/json"
                                         }
                                         
                                         $deleteUserUrl = "$BaseUrl/Account/v1/User/$UserId"
                                         
                                         try {
                                             $response = Invoke-WebRequest -Method 'DELETE' -Uri $deleteUserUrl -Headers $Headers
                                             
                                             if ($response.StatusCode -eq 204) {
                                                 Write-Output "User deleted successfully"
                                             } else {
                                                 Write-Output "Failed to delete user"
                                             }
                                         } catch {
                                             Write-Output "An error occurred: $_"
                                         }
                                         """;
            await File.WriteAllTextAsync(scriptPath, scriptContent);
        }

        var arguments = $"-BaseUrl \"https://demoqa.com\" -UserId \"{userId}\" -Token \"{token}\"";

        var processStart = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = $"-File \"{scriptPath}\" {arguments}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = processStart;
        process.Start();

        // error reading
        var output = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();

        // results
        Console.WriteLine("Output:");
        Console.WriteLine(output);

        Assert.That(output.Trim(), Is.EqualTo("User deleted successfully"), "User was not deleted.");
    }
}