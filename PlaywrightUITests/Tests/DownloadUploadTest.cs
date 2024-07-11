using PlaywrightUiTests.PageObjects;

namespace PlaywrightUiTests.Tests
{
    internal class DownloadUploadTest : UiTestFixture
    {
        private DemoQaDownloadPage _demoQaDownloadPage;

        [SetUp]
        public void SetupDemoQaPage()
        {
            _demoQaDownloadPage = new DemoQaDownloadPage(Page);
        }
        
        [Category("UI")]

        [Test, Description("Donwload file verify file updated")]
        public async Task VerifyDownload()
        {
            await _demoQaDownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQaDownloadPage.ClickDownloadButton();
        }

        [Test, Description("Donwload file then upload same file")]
        public async Task VerifyDownloadDebug()
        {
            await _demoQaDownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQaDownloadPage.VerifyFileDownloaded();
            await _demoQaDownloadPage.VerifyDownloadedFileUploadedSucessfully();
        }
    }
}
