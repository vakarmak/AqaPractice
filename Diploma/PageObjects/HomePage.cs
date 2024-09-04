using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class HomePage(IPage? page)
{
    private const string HomePageUrl = "https://automationexercise.com/";
    
    // Methods
    public async Task GoToHomePage()
    {
        await page!.GotoAsync(HomePageUrl);
    }
    
    public async Task VerifyHomePageIsOpened()
    {
        await Assertions.Expect(page).ToHaveURLAsync(HomePageUrl);
    }
}