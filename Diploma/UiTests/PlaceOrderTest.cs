using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class PlaceOrderTest : BaseUiTestFixture
    {
        private HomePage _homePage;
        private CartPage _cartPage;
        private CheckoutPage _checkout;
        private PaymentPage _payment;

        [SetUp]
        public void SetUpPages()
        {
            _homePage = new HomePage(Page);
            _cartPage = new CartPage(Page);
            _checkout = new CheckoutPage(Page);
            _payment = new PaymentPage(Page);
        }

        [Test]
        public async Task PlaceOrderAndDeleteAccount()
        {
            // Arrange
            await _homePage.GoToHomePage();
            await _homePage.GoToLoginPage();
            await _homePage.Login(UserData["email"], UserData["password"]);

            var userName = UserData["name"];

            const int productIndex = 1;

            const string message = "Please deliver as soon as possible";

            const string cardName = "John Doe";
            const string cardNumber = "4242424242424242";
            const string csv = "123";
            const string expirationMonth = "12";
            const string expirationYear = "2025";

            // Act
            await _homePage.VerifyUserLogin(userName);
            await _cartPage.AddProductToCart(productIndex);
            await _cartPage.ContinueShopping();
            await _cartPage.GoToCartPage();
            await _checkout.MakeCheckout();
            await _checkout.MakeComment(message);
            await _payment.PlaceOrder();
            await _payment.EnterCardInfo(cardName, cardNumber, csv, expirationMonth, expirationYear);
            await _payment.ConfirmOrder();
            await _payment.OrderIsPlaced();
            await _homePage.DeleteAccount();

            // Assert
            await _homePage.IsAccountDeleted();
        }
    }
}
