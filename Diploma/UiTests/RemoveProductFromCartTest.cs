using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class RemoveProductFromCartTest : UiTestFixture
    {
        private CartPage _cartPage;

        [SetUp]
        public void SetUpPage()
        {
            _cartPage = new CartPage(Page);
        }

        [Test]
        public async Task RemoveProductFromCart()
        {
            // Arrange
            const int productIndex = 0;

            // Act
            await _cartPage.AddProductToCart(productIndex);
            await _cartPage.ContinueShopping();
            await _cartPage.GoToCartPage();
            await _cartPage.DeleteProductFromCart();

            // Assert
            await _cartPage.VerifyCartIsEmpty();
        }
    }
}
