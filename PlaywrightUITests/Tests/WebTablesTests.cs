using Bogus;
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
        //await DemoQAWebTablesPage.VerifyTableRowContent();
        await _demoQaWebTablesPage.VerifyTableRowContent("Last Name", "Vega");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await _demoQaWebTablesPage.VerifyPopupVisible();
        await _demoQaWebTablesPage.VerifyFirstNameVisible();
    }

    [Test]
    public async Task VerifyTableVisible2()
    {
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await _demoQaWebTablesPage.VerifyPopupVisible();
        await _demoQaWebTablesPage.VerifyFirstNameVisible();
    }
    
    // TODO: automate test cases
    //Check any mandatory field
    
    [Test]
    public async Task VerifyMandatoryFields()
    {
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.OpenAddRowPopup();
        await _demoQaWebTablesPage.SubmitChanges();
        var userForm = Page.Locator("//form[@id='userForm']");
        await Assertions.Expect(userForm).ToHaveAttributeAsync("class", "was-validated");
    }
    
    //Add new row and verify row added
    
    [Test]
    public async Task VerifyRowAdded()
    {
        Faker faker = new Faker();
        string firstName = faker.Name.FirstName();
        string lastName = faker.Name.LastName();
        string email = faker.Internet.Email();
        string age = faker.Random.Number(18, 65).ToString();
        string salary = faker.Random.Number(1000, 7500).ToString();
        string department = faker.Commerce.Department();
        
        await _demoQaWebTablesPage.GoToDemoQaWebTablesPage();
        await _demoQaWebTablesPage.OpenAddRowPopup();
        await _demoQaWebTablesPage.AddNewRow(firstName, lastName, email, age, salary, department);
        await _demoQaWebTablesPage.SubmitChanges();
        await _demoQaWebTablesPage.VerifyTableRowContent("First Name", firstName);
    }
    
    //Edit row and verify row edited
    //Delete row and verify row deleted
    
    
    [TearDown]
    public async Task TearDown()
    {
        await Page.CloseAsync();
    }
}