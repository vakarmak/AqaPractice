using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class SolarShopPage(IPage page)
{
    private const string SolarShopPageUrl = "https://solartechnology.com.ua/shop";
    
    // Locators
    private ILocator BasketIcon => page.Locator(".cart-icon");
   
    // Methods
    public async Task VerifyBasketIsEmpty()
    {
        await page.WaitForURLAsync(SolarShopPageUrl);
        
        await Assertions.Expect(BasketIcon).ToHaveAttributeAsync("class", "cart-icon ");
    }
}