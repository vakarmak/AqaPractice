﻿using Microsoft.Playwright;

namespace PlaywrightEverShop;

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
            Headless = false, // Set false to run the browser in non-headless mode
            Args = ["--start-maximized"] // Set the browser to start maximized
        });

        var context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = ViewportSize.NoViewport
        });
        Page = await context.NewPageAsync();
        Page.SetDefaultTimeout(10000);
    }

    [TearDown]
    public async Task Teardown()
    {
        await Page.CloseAsync();
        await _browser.CloseAsync();
    }
}