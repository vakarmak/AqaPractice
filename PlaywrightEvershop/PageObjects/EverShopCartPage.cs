using Microsoft.Playwright;

namespace PlaywrightEverShop.PageObjects;

public class EverShopCartPage(IPage page)
{
    // Locators
    private ILocator ViewCartButton => page.Locator(".add-cart-popup-button");
    private ILocator CheckoutButton => page.Locator("//span[contains(text(),'CHECKOUT')]");
    
    // Methods
    public async Task GoToCartPage()
    {
        await ViewCartButton.ClickAsync();
    }
    
    public async Task MakeCheckout()
    {
        await CheckoutButton.ClickAsync();
    }

    public async Task<string> GetProductName()
    {
        var productCard = await page.QuerySelectorAsync(".product-info");
        var productName = await productCard!.InnerTextAsync();
        
        return productName.Split("\n")[0].ToLower();
    }
}