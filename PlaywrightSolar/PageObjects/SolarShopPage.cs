using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class SolarShopPage(IPage page)
{
    private const string SolarShopPageUrl = "https://solartechnology.com.ua/shop";
   
    // Methods
    public async Task VerifyBasketIsEmpty()
    {
        await page.WaitForURLAsync(SolarShopPageUrl);
        
        var basketIcon = await page.QuerySelectorAsync(".cart-icon");
        
        Assert.That(basketIcon, Is.Not.Null, "Basket icon is not found");
        
        var basketHasAttribute = await basketIcon!.GetAttributeAsync("class");
        
        Assert.That(basketHasAttribute, Does.Contain("cart-icon"), "Basket is not empty");
    }
}