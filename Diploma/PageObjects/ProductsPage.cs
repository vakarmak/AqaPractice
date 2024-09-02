using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class ProductsPage(IPage page)
{
    private const string ProductsPageUrl = "https://automationexercise.com/products";
    
    // Locators
    private ILocator ProductsButton => page.Locator("//a[@href='/products']");
    
    private ILocator SearchInput => page.Locator("//input[@id='search_product']");
    private ILocator SearchButton => page.Locator("//button[@id='submit_search']");

    private ILocator AllProductsTitle => page.Locator("//h2[contains(text(), 'All Products')]");
    private ILocator SearchedProductsTitle => page.Locator("//h2[contains(text(), 'Searched Products')]");
    
    // Methods
    public async Task GoToProductsPage()
    {
        await ProductsButton.ClickAsync();
        await Assertions.Expect(page).ToHaveURLAsync(ProductsPageUrl);
    }
    
    public async Task VerifyProductsPageVisible()
    {
        await Assertions.Expect(AllProductsTitle).ToBeVisibleAsync();
    }

    public async Task SearchProduct(string productName)
    {
        await SearchInput.FillAsync(productName);
        await SearchButton.ClickAsync();
    }
    
    public async Task VerifySearchedProductsVisible()
    {
        await Assertions.Expect(SearchedProductsTitle).ToBeVisibleAsync();
    }

    public async Task<List<string>> GetProductName()
    { 
        var products = await page.QuerySelectorAllAsync(".col-sm-4");
        var productNames = await Task.WhenAll(products.Select(async result => await result!.InnerTextAsync()));
        
        return productNames.ToList();
    }
}