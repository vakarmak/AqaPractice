using PlaywrightUiTests;
using PlaywrightUITests;
using PlaywrightUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class DownloadUploadTest : UiTestFixture
    {
        private DemoQaDownloadPage _demoQADownloadPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQADownloadPage = new DemoQaDownloadPage(Page);
        }
        
        [Category("UI")]

        [Test, Description("Donwload file verify file updated")]
        public async Task VerifyDownload()
        {
            await _demoQADownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQADownloadPage.ClickDownloadButton();
        }

        [Test, Description("Donwload file then upload same file")]
        public async Task VerifyDownloadDebug()
        {
            await _demoQADownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQADownloadPage.VerifyFileDownloaded();
            await _demoQADownloadPage.VerifyDownloadedFileUploadedSucessfully();
        }
    }
}
