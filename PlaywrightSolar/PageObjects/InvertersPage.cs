using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class InvertersPage(IPage page)
{
    // Locators
    private ILocator PageTitle => page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Товари у кошику" });

    private ILocator PlaceOrderButton =>
        page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Оформити замовлення" });
    
    
    // Methods
    public async Task VerifyInvertersPageTitle()
    {
        await Task.Delay(1500);
        await Assertions.Expect(PageTitle).ToBeVisibleAsync();
    }
    
    public async Task<string> AddProductToBasket()
    {
        var products = page.Locator("#w0 > div > .col").First;
        
        var selectedProductName = await products!.TextContentAsync();

        var addToBasketButton = products.Locator(".add-product-to-cart").First;
        await addToBasketButton!.ClickAsync();
        
        await Task.Delay(1000); 
        
        await PlaceOrderButton.ClickAsync();
        return selectedProductName!;
    }
}