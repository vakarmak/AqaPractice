using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class SolarShopPage(IPage page)
{
    private const string SolarShopPageUrl = "https://solartechnology.com.ua/shop";
    private const string SolarPanelsPageUrl = "https://solartechnology.com.ua/shop/solar-panels";
    private const string InvertersPageUrl = "https://solartechnology.com.ua/shop/inverters";

    private const string BasketPageUrl = "https://solartechnology.com.ua/cart";
    
    // Methods
    public async Task GoToSolarTechnologyShopPage()
    {
        await page.GotoAsync(SolarShopPageUrl);
        Assert.That(page.Url, Is.EqualTo(SolarShopPageUrl), "Failed to navigate to Solar Technology Shop page");
        
    }
    
    public async Task GoToSolarPanels()
    {
        await page.GotoAsync(SolarPanelsPageUrl);
        Assert.That(page.Url, Is.EqualTo(SolarPanelsPageUrl), "Failed to navigate to Solar Panels page");
    }
    
    public async Task GoToInvertersPage()
    {
        await page.GotoAsync(InvertersPageUrl);
        Assert.That(page.Url, Is.EqualTo(InvertersPageUrl), "Failed to navigate to Inverters page");
    }
    
    public async Task GoToBasketPage()
    {
        await page.GotoAsync(BasketPageUrl);
        Assert.That(page.Url, Is.EqualTo(BasketPageUrl), "Failed to navigate to Basket page");
    }
}