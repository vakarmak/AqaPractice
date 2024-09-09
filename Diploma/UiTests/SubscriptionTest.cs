using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class SubscriptionTest : UiTestFixture
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
        public async Task GetSubscription()
        {
            // Arrange
            var email = UserData["email"];

            // Act
            await _homePage.OpenCartPage();
            await _cartPage.SubscribeToNewsletter(email);

            // Assert
            await _cartPage.SubscriptionToNewsLettersIsSuccessful();
        }
    }
}
