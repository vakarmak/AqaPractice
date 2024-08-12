using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class SolarShopPage(IPage page)
{
    private const string SolarShopPageUrl = "https://solartechnology.com.ua/shop";
    private const string SolarPanelsPageUrl = "https://solartechnology.com.ua/shop/solar-panels";
    
    // Locators
    private ILocator SolarPanels => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Сонячні панелі" });
    
    // Methods
    public async Task GoToSolarTechnologyShopPage()
    {
        await page.GotoAsync(SolarShopPageUrl);
        Assert.That(page.Url, Is.EqualTo(SolarShopPageUrl), "Failed to navigate to Solar Technology Shop page");
        
    }
    
    public async Task GoToSolarPanels()
    {
        await SolarPanels.ClickAsync();
        Assert.That(page.Url, Is.EqualTo(SolarPanelsPageUrl), "Failed to navigate to Solar Panels page");
    }
}