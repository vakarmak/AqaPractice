using Microsoft.Playwright;

namespace PlaywrightEverShop.PageObjects;

public class EverShopMenPage(IPage page)
{
    private const string EverShopMainPageUrl = "https://demo.evershop.io/";

    // Locators
    private ILocator Men => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Men", Exact = true });
    private ILocator Size => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "S" });
    private ILocator Color => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Green" });
    private ILocator AddToCartButton => page.Locator("//span[contains(text(), 'ADD TO CART')]");
    
    // Methods
    public async Task GoToMenPage()
    {
        await page.GotoAsync(EverShopMainPageUrl);
        await Men.ClickAsync();
    }

    public async Task SelectProduct(int productIndex)
    {
        await page.WaitForSelectorAsync(".listing-tem");
        
        var products = await page.QuerySelectorAllAsync(".listing-tem");
        await products[productIndex].ClickAsync();
    }

    public async Task<string> GetProductName()
    {
        var productName = await page.QuerySelectorAsync(".product-single-name");
        var productNameText = await productName!.InnerTextAsync();
        
        return productNameText.ToLower();
    }

    public async Task SelectSizeOption()
    {
        await Size.ClickAsync();
    }
    
    public async Task SelectColorOption()
    {
        await Color.ClickAsync();
    }
    
    public async Task AddProductToCart()
    {
        await page.WaitForSelectorAsync(".button");
        
        await AddToCartButton.ClickAsync();
    }
}