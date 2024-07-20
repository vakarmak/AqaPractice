using Microsoft.Playwright;

namespace PlaywrightUiTests.PageObjects;

internal class DemoQaDynamicPropertiesPage(IPage page)
{
    private readonly string _dynamicPropertiesPageUrl = "https://demoqa.com/dynamic-properties";

    public async Task GoToDemoQaDynamicPropertiesPage()
    {
        await page.GotoAsync(_dynamicPropertiesPageUrl);
    }
    
    public async Task GetColorChangeChangeColor(string expectedColor)
    {
        var colorElement = page.Locator("#colorChange");
        var color = await colorElement.EvaluateAsync<string>("element => getComputedStyle(element).color");
        
        Assert.That(color, Is.EqualTo(expectedColor));
    }
    
    public async Task EnableAfter5Sec()
    {
        var button = page.GetByRole(AriaRole.Button, new() { Name = "Will enable 5 seconds" });
        await Assertions.Expect(button).ToBeDisabledAsync();
        //await button.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 2000 });
        await Task.Delay(6000);
        await Assertions.Expect(button).ToBeEnabledAsync();
    }
    
    public async Task VisibleAfter5Sec()
    {
        var button = page.GetByRole(AriaRole.Button, new() { Name = "Visible After 5 Seconds" });
        await button.ClickAsync();
        await Assertions.Expect(button).ToBeFocusedAsync();
    }
}