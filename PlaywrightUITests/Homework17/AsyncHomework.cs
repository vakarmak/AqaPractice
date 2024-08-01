namespace PlaywrightUiTests.Homework17;

public class AsyncHomework
{
    private static async Task<string> GetStringAsync()
    {
        await Task.Delay(500);
        return "Hello, World!";
    }

    private static async Task<int> GetNumberWithExceptionAsync()
    {
        await Task.Delay(1000);
        throw new InvalidOperationException("An error occurred while fetching the number.");
    }

    [Test]
    public async Task TestGetStringAsync()
    {
        // TODO: Uncomment and implement test so it pass
        var result = await GetStringAsync();
        Assert.That(result, Is.EqualTo("Hello, World!"));
    }

    [Test]
    public void TestGetNumberWithExceptionAsync()
    {
        // TODO: Verify that GetNumberWithExceptionAsync() throws InvalidOperationException
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await GetNumberWithExceptionAsync());
        Assert.That(ex.Message, Is.EqualTo("An error occurred while fetching the number."));
    }
}