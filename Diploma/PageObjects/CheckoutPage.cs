using Microsoft.Playwright;

namespace Diploma.PageObjects
{
    internal class CheckoutPage(IPage? page)
    {
        // Locators
        private ILocator Checkout => page!.GetByText("Proceed To Checkout");

        private ILocator AddressDetails => page!.GetByText("Address Details");
        private ILocator ReviewYourOrder => page!.GetByText("Review Your Order");

        private ILocator CommentInput => page!.Locator("//textarea[@name='message']");
        

        // Methods
        public async Task MakeCheckout()
        {
            await Checkout.ClickAsync();
        }

        public async Task VerifyAddressDetails()
        {
            await AddressDetails.IsVisibleAsync();
        }

        public async Task VerifyReviewYourOrder()
        {
            await ReviewYourOrder.IsVisibleAsync();
        }

        public async Task MakeComment(string message)
        {
            await CommentInput.FillAsync(message);
        }
    }
}
