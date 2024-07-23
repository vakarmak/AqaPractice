using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Bindings;

[Parallelizable(ParallelScope.Self)]
// [TestFixture]
[Binding]
internal class UiTestFixture
{
    protected static IPage? Page { get; private set; }
    private static IBrowser? _browser;

    // [SetUp]
    [BeforeFeature(Order = 1)]
    public static async Task Setup()
    {
        var playwrightDriver = await Playwright.CreateAsync();
        _browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, // Set false to run the browser in non-headless mode
            Args = new[] { "--start-maximized" }, // Set the browser to start maximized
        });

        var context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport
        });

        Page = await context.NewPageAsync();
    }
    
    [AfterFeature]
    // [TearDown]
    public static async Task Teardown()
    {
        await Page!.CloseAsync();
        await _browser!.CloseAsync();
    }
}