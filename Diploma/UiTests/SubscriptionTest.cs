using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class SubscriptionTest : UiTestFixture
    {
        private ProductCardPage _productCardPage;

        [SetUp]
        public void SetUpPage()
        {
            _productCardPage = new ProductCardPage(Page);
        }

        [Test]
        public async Task GetSubscription()
        {
            // Arrange
            var email = UserData["email"];
            const int productIndex = 0;

            // Act
            await _productCardPage.SelectProduct(productIndex);
            await _productCardPage.NavigateToFooter();
            await _productCardPage.SubscribeToNewsletter(email);

            // Assert
            await _productCardPage.SubscriptionToNewsLettersIsSuccessful();
        }
    }
}
