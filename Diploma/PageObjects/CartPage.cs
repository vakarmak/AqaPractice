using Microsoft.Playwright;

namespace Diploma.PageObjects
{
    internal class CartPage(IPage? page)
    {
        private const string CartPageUrl = "https://automationexercise.com/view_cart";

        // Locators
        private ILocator CartButton => page!.GetByRole(AriaRole.Link, new() { Name = " Cart" });
        
        private ILocator SubscriptionLabel => page!.Locator("//h2[contains(text(), 'Subscription')]");
        private ILocator SubscriptionEmailInput => page!.Locator("//input[@id='susbscribe_email']");
        private ILocator SubscriptionButton => page!.Locator("//button[@id='subscribe']");
        private ILocator SubscriptionNotification => page!.Locator(".alert-success");
        
        private ILocator ContinueShoppingPopupButton => page!.Locator("//button[contains(text(), 'Continue Shopping')]");

        private ILocator DeleteProductButton => page!.Locator("//a[@class='cart_quantity_delete']");
        private ILocator CartIsEmpty => page!.GetByText("Cart is empty!");


        // Methods
        public async Task GoToCartPage()
        {
            await CartButton.ClickAsync();
            await Assertions.Expect(page).ToHaveURLAsync(CartPageUrl);
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

        public async Task AddProductToCart(int productIndex)
        {
            var products = await page!.QuerySelectorAllAsync(".col-sm-4");
            var product = products[productIndex];
            await product!.HoverAsync();

            var addToCartButton = await product!.QuerySelectorAsync(".add-to-cart");
            await addToCartButton!.ClickAsync();
        }

        public async Task ContinueShopping()
        {
            await page!.WaitForSelectorAsync("//button[contains(text(), 'Continue Shopping')]");

            await ContinueShoppingPopupButton.ClickAsync();
        }

        public async Task DeleteProductFromCart()
        {
            await DeleteProductButton.ClickAsync();
        }

        public async Task VerifyCartIsEmpty()
        {
            await Assertions.Expect(CartIsEmpty).ToBeVisibleAsync();
        }
    }
}