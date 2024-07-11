using PlaywrightUITests.PageObjects;

namespace PlaywrightUiTests.Tests
{
    [TestFixture]
    internal class TextBoxTestsUsingPo : UiTestFixture
    {
        private DemoQaTextBoxPage _demoQaTextBoxPage;

        [SetUp]
        public void SetupDemoQaPage()
        {
            _demoQaTextBoxPage = new DemoQaTextBoxPage(Page);
        }
        
        [Category("UI")]

        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            await _demoQaTextBoxPage.GoToElementsPage();
            await _demoQaTextBoxPage.ClickTextBoxMenu();
            await _demoQaTextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQaTextBoxPage.IsFullNameTextVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
            await _demoQaTextBoxPage.GoToElementsPage();
            await _demoQaTextBoxPage.ClickTextBoxMenu();
            await _demoQaTextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQaTextBoxPage.IsFullNameInputVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
            await _demoQaTextBoxPage.GoToElementsPage();
            await _demoQaTextBoxPage.ClickTextBoxMenu();
            await _demoQaTextBoxPage.WaitForTextBoxPage();
            await _demoQaTextBoxPage.FillFullName("John Doe");
            await _demoQaTextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQaTextBoxPage.IsNameVisible("John Doe");
            Assert.That(isVisible, Is.True, "The element with text 'Name:John Doe' should be visible.");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await _demoQaTextBoxPage.GoToElementsPage();
            await _demoQaTextBoxPage.ClickTextBoxMenu();
            await _demoQaTextBoxPage.WaitForTextBoxPage();
            await _demoQaTextBoxPage.FillFullName("");
            await _demoQaTextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQaTextBoxPage.IsNameHidden("John Doe");
            Assert.That(isVisible, Is.True, "The element with text 'Name:John Doe' should not be visible.");
        }
    }
}
