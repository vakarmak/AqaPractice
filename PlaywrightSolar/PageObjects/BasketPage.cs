using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class BasketPage(IPage page)
{
    // Locators
    private ILocator PageTitle =>
        page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Товари у кошику" });

    // Methods
    public async Task VerifyBasketPageTitle()
    {
        await Task.Delay(2000);
        await Assertions.Expect(PageTitle).ToBeVisibleAsync();
    }

    public async Task VerifyAddedProductToBasket(string expectedProductName)
    {
        await Task.Delay(2000);

        var productNameLocator = await page.QuerySelectorAsync("//div[@class='prod-title']");
        var productNameTextLocator =
            await productNameLocator!.QuerySelectorAsync("//a[@class='grey-text text-darken-3']");
        var actualProductName = await productNameTextLocator!.InnerTextAsync();
        var actualProductNameText = ExtractProductNameText(actualProductName, expectedProductName);

        Assert.That(actualProductNameText, Is.EqualTo(expectedProductName), "Product name is not the same");
    }

    private static string ExtractProductNameText(string text, string target)
    {
        var regex = new Regex($@"^.*?({Regex.Escape(target)}).*?$", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        var match = regex.Match(text);

        return match.Success ? match.Groups[1].Value.Trim() : "Product name not found";
    }
    
    public async Task DeleteProductFromBasket()
    {
        var deleteButton = await page.QuerySelectorAsync("//span[@class='remove-from-cart grey-text text-darken-1']");
        await deleteButton!.ClickAsync();
        
        await Task.Delay(2000);
    }
}