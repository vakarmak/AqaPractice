using Microsoft.Playwright;

namespace Diploma.PageObjects
{
    internal class PaymentPage(IPage? page)
    {
        // Locators
        private ILocator PlaceOrderButton => page!.Locator("//a[@href='/payment']");

        private ILocator ConfirmOrderButton => page!.Locator("//button[@id='submit']");

        private ILocator OrderPlaced => page!.Locator("//h2[@data-qa='order-placed']");

        // Methods
        public async Task PlaceOrder()
        {
            await PlaceOrderButton.ClickAsync();
        }

        public async Task EnterCardInfo(string cardName, string cardNumber, string cvc, string expirationMonth, string expirationYear)
        {
            await page!.FillAsync("//input[@name='name_on_card']", cardName);
            await page!.FillAsync("//input[@name='card_number']", cardNumber);
            await page!.FillAsync("//input[@name='cvc']", cvc);
            await page!.FillAsync("//input[@name='expiry_month']", expirationMonth);
            await page!.FillAsync("//input[@name='expiry_year']", expirationYear);
        }

        public async Task ConfirmOrder()
        {
            await ConfirmOrderButton.ClickAsync();
        }

        public async Task OrderIsPlaced()
        {
            await OrderPlaced.IsVisibleAsync();
        }
    }
}
