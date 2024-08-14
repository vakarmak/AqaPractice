using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class InvertersPage(IPage page)
{
    // Locators
    private ILocator InvertersPageTitle =>
        page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Сонячні інвертори" });

    private ILocator PlaceOrderButton =>
        page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Оформити замовлення" });


    // Methods
    public async Task VerifyInvertersPageTitle()
    {
        await Task.Delay(1500);
        await Assertions.Expect(InvertersPageTitle).ToBeVisibleAsync();
    }

    public async Task<string> AddProductToBasket()
    {
        var listOfProductsOnPage = await page.QuerySelectorAllAsync(".col.s12.m6.l4.xl3.prod-holder");
        var random = new Random();
        var randomIndex = random.Next(listOfProductsOnPage.Count);
        var selectedProductFromPage = listOfProductsOnPage[randomIndex];

        var nameOfSelectedProduct = await selectedProductFromPage.QuerySelectorAsync(".list-product-title");

        var textNameOfSelectedProduct = await nameOfSelectedProduct!.InnerTextAsync();
        var productNameText = ExtractProductNameText(textNameOfSelectedProduct);
        
        await Task.Delay(1000);

        var addToCartButton = await selectedProductFromPage.QuerySelectorAsync(".add-product-to-cart");
        await addToCartButton!.ClickAsync();
        await PlaceOrderButton.ClickAsync();

        return productNameText;
    }

    private static string ExtractProductNameText(string text)
    {
        var regex = new Regex(@"[A-Za-z0-9\s\-]+");

        var match = regex.Match(text);
        return match.Success ? match.Value.Trim() : "Product name not found";
    }
}