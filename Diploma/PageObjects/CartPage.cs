using Microsoft.Playwright;

namespace Diploma.PageObjects
{
    internal class CartPage(IPage? page)
    {
        // Locators
        private ILocator CartButton => page!.GetByRole(AriaRole.Link, new() { Name = " Cart" });
        private ILocator SubscriptionLabel => page!.Locator("//h2[contains(text(), 'Subscription')]");
        private ILocator SubscriptionEmailInput => page!.Locator("//input[@id='susbscribe_email']");
        private ILocator SubscriptionButton => page!.Locator("//button[@id='subscribe']");
        private ILocator SubscriptionNotification => page!.Locator(".alert-success");

        // Methods
        public async Task GoToCartPage()
        {
            await CartButton.ClickAsync();
        }

        public async Task SelectProduct(int productIndex)
        {
            var products = await page!.QuerySelectorAllAsync(".col-sm-4");
            var selectProduct = products[productIndex];
            await selectProduct.ClickAsync();
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
}
