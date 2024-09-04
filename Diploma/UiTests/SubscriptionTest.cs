using Diploma.PageObjects;

namespace Diploma.UiTests
{
    internal class SubscriptionTest : UiTestFixture
    {
        private HomePage _homePage;

        [SetUp]
        public void SetUpPage()
        {
            _homePage = new HomePage(Page);
        }

        [Test]
        public async Task GetSubscription()
        {
            // Arrange
            var email = UserData["email"];

            // Act
            await _homePage.NavigateToFooter();
            await _homePage.SubscribeToNewsletter(email);

            // Assert
            await _homePage.SubscriptionToNewsLettersIsSuccessful();
        }
    }
}
