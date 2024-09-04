using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class SubscriptionTest : UiTestFixture
    {
        private CartPage _cartPage;

        [SetUp]
        public void SetUpPage()
        {
            _cartPage = new CartPage(Page);
        }

        [Test]
        public async Task GetSubscription()
        {
            // Arrange
            var email = UserData["email"];

            // Act
            await _cartPage.GoToCartPage();
            await _cartPage.NavigateToFooter();
            await _cartPage.SubscribeToNewsletter(email);

            // Assert
            await _cartPage.SubscriptionToNewsLettersIsSuccessful();
        }
    }
}
