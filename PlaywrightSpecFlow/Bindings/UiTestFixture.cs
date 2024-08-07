using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Bindings;

[Parallelizable(ParallelScope.Self)]
// [TestFixture]
[Binding]
internal class UiTestFixture
{
    protected static IPage? Page { get; private set; }
    private static IBrowser? _browser;
    private static IBrowserContext? _context;

    // [SetUp]
    [BeforeFeature(Order = 1)]
    public static async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false, // Set false to run the browser in non-headless mode
            Args = new[] { "--start-maximized" }, // Set the browser to start maximized
        });

        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport
        });

        await _context.Tracing.StartAsync(new TracingStartOptions
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        Page = await _context.NewPageAsync();
    }

    [AfterFeature]
    // [TearDown]
    public static async Task Teardown()
    {
        var failed = TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.ChildFailure ||
                     TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Error;

        if (failed)
        {
            var tracePath = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            );

            await _context!.Tracing.StopAsync(new TracingStopOptions
            {
                Path = tracePath
            });
        }
        else
        {
            await _context!.Tracing.StopAsync(new TracingStopOptions());
        }

        await Page!.CloseAsync();

        await _browser!.CloseAsync();
    }
}