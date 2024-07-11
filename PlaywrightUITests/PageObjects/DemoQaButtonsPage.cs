using Microsoft.Playwright;

namespace PlaywrightUiTests.PageObjects;

internal class DemoQaButtonsPage(IPage page)
{
    private readonly string _elementsPageUrl = "https://demoqa.com/elements";
    private readonly string _buttonsPageUrl = "https://demoqa.com/buttons";

    public async Task GoToButtonsPage()
    {
        await page.GotoAsync(_elementsPageUrl);
        await page.Locator("li:has-text('Buttons')").ClickAsync();
        await page.WaitForURLAsync(_buttonsPageUrl);
    }

    public async Task RightClickMeButtonIsFocused()
    {
        await Assertions.Expect(page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me", Exact = true })).ToBeFocusedAsync();
    }
}