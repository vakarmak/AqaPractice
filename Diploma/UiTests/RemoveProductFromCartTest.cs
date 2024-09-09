using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class RemoveProductFromCartTest : UiTestFixture
    {
        private CartPage _cartPage;
        private HomePage _homePage;

        [SetUp]
        public void SetUpPages()
        {
            _cartPage = new CartPage(Page);
            _homePage = new HomePage(Page);
        }

        [Test]
        public async Task RemoveProductFromCart()
        {
            // Arrange
            const int productIndex = 1;

            // Act
            await _cartPage.AddProductToCart(productIndex);
            await _cartPage.ContinueShopping();
            await _homePage.OpenCartPage();
            await _cartPage.DeleteProductFromCart();

            // Assert
            await _cartPage.VerifyCartIsEmpty();
        }
    }
}
