using Microsoft.Playwright;

namespace Diploma.UiTests;

[TestFixture]
internal class SearchProductTest : UiTestFixture
{
    [Test]
    public async Task SimpleTest()
    {
        await Page.GotoAsync("https://automationexercise.com/login");

        await Page.FillAsync("input[name='email']", UserData["email"]);
        await Page.FillAsync("input[name='password']", UserData["password"]);
        await Page.ClickAsync("button[type='submit']");

        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        await Page.GotoAsync("https://automationexercise.com/products");
    }
}