using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class HomePage(IPage? page)
{
    private const string HomePageUrl = "https://automationexercise.com/";

    // Locators
    private ILocator ContactUsButton => page!.Locator("//a[@href='/contact_us']");

    private ILocator CartButton => page!.GetByRole(AriaRole.Link, new() { Name = " Cart" });

    private ILocator ProductsButton => page!.Locator("//a[@href='/products']");

    // Methods
    public async Task OpenPage()
    {
        await page!.GotoAsync(HomePageUrl);
    }

    public async Task OpenCuntactUsPage()
    {
        await ContactUsButton.ClickAsync();
    }

    public async Task OpenCartPage()
    {
        await CartButton.ClickAsync();
    }

    public async Task OpenProductsPage()
    {
        await ProductsButton.ClickAsync();
    }
    
    public async Task VerifyHomePageIsOpened()
    {
        await Assertions.Expect(page).ToHaveURLAsync(HomePageUrl);
    }
}