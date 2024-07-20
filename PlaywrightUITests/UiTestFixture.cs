using Microsoft.Playwright;

namespace PlaywrightUiTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class UiTestFixture
    {
        protected IPage Page { get; private set; }
        private IBrowser _browser;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            _browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false to run the browser in non-headless mode
            });
            
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920, // Set the width to a common fullscreen width
                    Height = 1080, // Set the height to a common fullscreen height
                }
            });
            Page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}