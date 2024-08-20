using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class BasketPage(IPage page)
{
    private const string CartPageUrl = "https://solartechnology.com.ua/cart";
    
    // Locators
    private ILocator PlaceOrderButton =>
        page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Оформити замовлення" });
    
    // Methods
    public async Task AddProductToBasket()
    {
        await PlaceOrderButton.ClickAsync();
        Assert.That(page.Url, Is.EqualTo(CartPageUrl), "Failed to navigate to Cart page");
    }
    public async Task DeleteProductFromBasket()
    {
        await page.WaitForSelectorAsync(".remove-from-cart");
        
        var deleteButton = await page.QuerySelectorAsync(".remove-from-cart");
        await deleteButton!.ClickAsync();
    }
}