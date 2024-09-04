using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class HomePage(IPage? page)
{
    private const string HomePageUrl = "https://automationexercise.com/";

    // Locators
    private ILocator SubscriptionLabel => page!.Locator("//h2[contains(text(), 'Subscription')]");
    private ILocator SubscriptionEmailInput => page!.Locator("//input[@id='susbscribe_email']");
    private ILocator SubscriptionButton => page!.Locator("//button[@id='subscribe']");
    private ILocator SubscriptionNotification => page!.Locator(".alert-success");

    // Methods
    public async Task GoToHomePage()
    {
        await page!.GotoAsync(HomePageUrl);
    }
    
    public async Task VerifyHomePageIsOpened()
    {
        await Assertions.Expect(page).ToHaveURLAsync(HomePageUrl);
    }

    public async Task NavigateToFooter()
    {
        await SubscriptionLabel.ScrollIntoViewIfNeededAsync();
        await Assertions.Expect(SubscriptionLabel).ToBeVisibleAsync();
    }

    public async Task SubscribeToNewsletter(string email)
    {
        await SubscriptionEmailInput.FillAsync(email);
        await SubscriptionButton.ClickAsync();
    }

    public async Task SubscriptionToNewsLettersIsSuccessful()
    {
        await Assertions.Expect(SubscriptionNotification).ToBeVisibleAsync();
    }
}