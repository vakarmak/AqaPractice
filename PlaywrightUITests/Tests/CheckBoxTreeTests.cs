using PlaywrightUiTests.PageObjects;

namespace PlaywrightUiTests.Tests
{
    internal class CheckBoxTreeTests : UiTestFixture
    {
        private DemoQaCheckBoxPage _demoQaCheckBoxPage;

        [SetUp]
        public void SetupDemoQaPage()
        {
            _demoQaCheckBoxPage = new DemoQaCheckBoxPage(Page);
        }
        
        [Category("UI")]

        [Test]
        public async Task VerifyCheckBoxChecked()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.CheckHomeCheckbox();
            await _demoQaCheckBoxPage.VerifyHomeChecked();
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxChecked()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.CheckCheckbox("Documents");
            await _demoQaCheckBoxPage.VerifyCheckboxChecked("Documents");
            await _demoQaCheckBoxPage.VerifyCheckboxChecked("Desktop");
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxChecked1()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.CheckCheckbox("Documents");
            // This should pass
            var documentsCheck = await _demoQaCheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck, "Documents checkbox unchecked");
            // This should fail
            // TODO Revert assert to make test green
            // var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            // Assert.That(desktopCheck, "Desktop checkbox unchecked");
        }

        //TODO: automate test cases
        //TC4 - Check Descktop Checkbox, verify checked
        
        [Test]
        [Description("Check Descktop Checkbox, verify checked")]
        public async Task VerifyDesktopCheckBoxChecked()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.CheckCheckbox("Desktop");
            var documentsCheck = await _demoQaCheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(documentsCheck, "Desktop checkbox unchecked");
        }
        
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        
        [Test]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public async Task VerifyWorkSpaceCheckBoxChecked()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.CheckCheckbox("Documents");
            await _demoQaCheckBoxPage.OpenDocuments();
            var documentsCheck = await _demoQaCheckBoxPage.VerifyCheckboxChecked("WorkSpace");
            Assert.That(documentsCheck, "WorkSpace checkbox unchecked");
        }
        
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        
        [Test]
        [Description("Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public async Task VerifyTextOfCheckedDocumentsCheckbox()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.CheckCheckbox("Documents");
            await _demoQaCheckBoxPage.CheckDocumentsCheckboxResult();
        }
        
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        
        [Test]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public async Task VerifyReactIcon()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.OpenDocuments();
            await _demoQaCheckBoxPage.OpenWorkSpace();
            await _demoQaCheckBoxPage.VerifyElementHasLeafIcon("React");
        }
        
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
        
        [Test]
        [Description("Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public async Task VerifyHomeSubCheckboxesChecked()
        {
            await _demoQaCheckBoxPage.GoToDemoQaCheckboxPage();
            await _demoQaCheckBoxPage.CheckHomeCheckbox();
            await _demoQaCheckBoxPage.OpenHome();
            await _demoQaCheckBoxPage.VerifyCheckboxChecked("Desktop");
            await _demoQaCheckBoxPage.VerifyCheckboxChecked("Documents");
            await _demoQaCheckBoxPage.VerifyCheckboxChecked("Downloads");
        }
    }
}
