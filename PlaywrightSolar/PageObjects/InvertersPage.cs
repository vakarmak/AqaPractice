using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class InvertersPage(IPage page)
{
    private const string InvertersPageUrl = "https://solartechnology.com.ua/shop/inverters";

    // Methods
    public async Task GoToInvertersPage()
    {
        await page.GotoAsync(InvertersPageUrl);
        Assert.That(page.Url, Is.EqualTo(InvertersPageUrl), "Failed to navigate to Inverters page");
    }

    public async Task GetProductFromList()
    {
        var listOfProductsOnPage = await page.QuerySelectorAllAsync(".prod-holder");
        var selectedProduct = listOfProductsOnPage[0];
        var addToCartButton = await selectedProduct.QuerySelectorAsync(".add-product-to-cart");
        await addToCartButton!.ClickAsync();
    }

    public async Task<string> GetProductName(int productIndex)
    {
        var listOfProductsOnPage = await page.QuerySelectorAllAsync(".prod-holder");
        var selectedProduct = listOfProductsOnPage[productIndex];
        var selectedProductContent = await selectedProduct.QuerySelectorAsync(".card-content");
        var rawProductName = await selectedProductContent!.InnerTextAsync();

        return ExtractProductNameFromCard(rawProductName);
    }
    
    private static string ExtractProductNameFromCard(string rawProductDetails)
    {
        var regex = new Regex(@"^[^\s].*", RegexOptions.Multiline);
        var match = regex.Match(rawProductDetails);

        return match.Success ? match.Value.Trim() :
            string.Empty;
    }
    
    public async Task GoToProductDetails(int productIndex)
    {
        var listOfProductsOnPage = await page.QuerySelectorAllAsync(".prod-holder");
        var selectedProduct = listOfProductsOnPage[productIndex];
        await selectedProduct.ClickAsync();
    }

    public async Task<string> GetProductNameFromProductDetails()
    {
        await page.WaitForSelectorAsync(".right-block");
        
        var productDetails = await page.QuerySelectorAsync(".right-block");
        var productDetailsName = await productDetails!.QuerySelectorAsync("h1");
        var rawProductDetailsName = await productDetailsName!.InnerTextAsync();

        return ExtractProductNameFromProductDetails(rawProductDetailsName);
    }
    
    private static string ExtractProductNameFromProductDetails(string rawProductDetails)
    {
        var regex = new Regex(@"\b(?:\S+\s+){2}(.*)", RegexOptions.IgnoreCase);
        var match = regex.Match(rawProductDetails);

        return match.Success ? match.Groups[1].Value.Trim() : string.Empty;
    }
}