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
        var cartItemName = await page.InnerTextAsync(".cart-product");
        Assert.That(cartItemName, Is.EqualTo(expectedProductName), "Wrong product was added");
    }
}