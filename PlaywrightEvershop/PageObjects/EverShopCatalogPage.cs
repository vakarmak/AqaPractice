using Microsoft.Playwright;

namespace PlaywrightEverShop.PageObjects;

public class EverShopCatalogPage(IPage page)
{
    private const string EverShopMainPageUrl = "https://demo.evershop.io/";

    // Locators
    private ILocator Men => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Men", Exact = true });
    private ILocator Size(string size) => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = $"{size}" });
    private ILocator Color(string color) => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = $"{color}" });
    
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

        await page.WaitForLoadStateAsync(LoadState.Load);
    }

    public async Task<string> GetProductName()
    {
        var productName = await page.QuerySelectorAsync(".product-single-name");
        var productNameText = await productName!.InnerTextAsync();
        
        return productNameText.ToLower();
    }

    public async Task SelectSizeOption(string size)
    {
        var sizeElement =  page.Locator($"//a[contains(text(), '{size}')]");
        await sizeElement.ClickAsync();
        
        await page.WaitForFunctionAsync("document.querySelector('li.selected') !== null");
    }
    
    public async Task SelectColorOption(string color)
    {
        var colorElement =  page.Locator($"//a[contains(text(), '{color}')]");
        await colorElement.ClickAsync();
        
        await page.WaitForFunctionAsync("document.querySelector('li.selected') !== null");
    }
    
    public async Task AddProductToCart()
    {
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        
        await page.Locator(".button").ClickAsync();
    }
}