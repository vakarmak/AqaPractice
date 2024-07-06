using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests;

internal class WebTablesTests : UITestFixture
{
    private DemoQaWebTablesPage _demoQaWebTablesPage;

    [SetUp]
    public void SetupDemoQaPage()
    {
        _demoQaWebTablesPage = new DemoQaWebTablesPage(Page);
    }

    [Test]
    public async Task VerifyTableVisible()
    {
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.VerifyTableVisible();
    }

    [Test]
    public async Task VerifyTableVisible2()
    {
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.VerifyTableRowContent("Last Name", "Vega");
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Add" }).ClickAsync();
        await _demoQaWebTablesPage.VerifyPopupVisible();
        await _demoQaWebTablesPage.VerifyTableVisible();
    }
    
    [Test]
    public async Task VerifyTableVisible3()
    {
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { Name = "Add" }).ClickAsync();
        await _demoQaWebTablesPage.VerifyPopupVisible();
        await _demoQaWebTablesPage.VerifyTableVisible();
    }
    
    // TODO: automate test cases
    //Check any mandatory field
    //Add new row and verify row added
    //Edit row and verify row edited
    //Delete row and verify row deleted
}