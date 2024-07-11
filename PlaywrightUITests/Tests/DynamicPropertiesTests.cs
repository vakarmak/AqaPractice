using PlaywrightUiTests;
using PlaywrightUITests;
using PlaywrightUITests.PageObjects;

namespace PlaywrigthUITests.Tests;

internal class DynamicPropertiesTests : UiTestFixture
{
    private DemoQaDynamicPropertiesPage _demoQaDynamicPropertiesPage;

    [SetUp]
    public void SetupDemoQaPage()
    {
        _demoQaDynamicPropertiesPage = new DemoQaDynamicPropertiesPage(Page);
    }

    [Test, Description("Verify ColorChange button have color black at page init and after 5 sec color red")]
    public async Task VerifyDynamicColorChange()
    {
        await _demoQaDynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
        await _demoQaDynamicPropertiesPage.GetColorChangeChangeColor("rgb(255, 255, 255)");
        await Task.Delay(5000);
        await _demoQaDynamicPropertiesPage.GetColorChangeChangeColor("rgb(220, 53, 69)");
    }

    [Test]
    public async Task TestEnableAfter()
    {
        await _demoQaDynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
        await _demoQaDynamicPropertiesPage.EnableAfter5Sec();
    }

    [Test]
    public async Task TestVisibleAfter()
    {
        await _demoQaDynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
        await _demoQaDynamicPropertiesPage.VisibleAfter5Sec();
    }

    [Test]
    public async Task TestVisibleAfterClickWait()
    {
        await _demoQaDynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
        await _demoQaDynamicPropertiesPage.VisibleAfter5Sec();
    }
}