using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class HomePage(IPage? page)
{
    private const string HomePageUrl = "https://automationexercise.com/";
    
    // Locators
    
    
    // Methods
    public async Task GoToHomePage()
    {
        await page!.GotoAsync(HomePageUrl);
        await Assertions.Expect(page).ToHaveURLAsync(HomePageUrl);
    }
}