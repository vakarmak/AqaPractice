using Bogus;
using Microsoft.Playwright;
using PlaywrightUITests;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests;

internal class WebTableTests : UITestFixture
{
    private DemoQaWebTablePage _demoQaWebTablePage;
    
    [SetUp]
    public void SetupDemoQaPage()
    {
        _demoQaWebTablePage = new DemoQaWebTablePage(Page);
    }
    
    [Test]
    public async Task VerifyTableVisible()
    {
        await _demoQaWebTablePage.GoToDemoQaWebTablePage();
        //await DemoQAWebTablesPage.VerifyTableRowContent();
        await _demoQaWebTablePage.VerifyTableRowContent("Last Name", "Vega");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
        await _demoQaWebTablePage.VerifyPopupVisible();
        await _demoQaWebTablePage.VerifyFirstNameVisible();
    }

    //TODO: automate test cases
    //Check any mandatory field
    
    [Test]
    public async Task CheckMandatoryFields()
    {
        await _demoQaWebTablePage.GoToDemoQaWebTablePage();
        await _demoQaWebTablePage.CheckMandatoryFields();
    }
    
    //Add new row and verify row added
    
    [Test]
    public async Task AddNewRowAndVerify()
    {
        var faker = new Faker();
        
        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var email = faker.Internet.Email();
        var age = faker.Random.Number(18, 65);
        var salary = faker.Random.Number(1000, 10000);
        var department = faker.Commerce.Department();
        
        await _demoQaWebTablePage.GoToDemoQaWebTablePage();
        await _demoQaWebTablePage.AddNewRow(firstName, lastName, email, age, salary, department);
        await _demoQaWebTablePage.VerifyAddedRow(firstName, lastName);
    } 
    
    //Edit row and verify row edited

    [Test]
    public async Task EditRowAndVerify()
    {
        Faker faker = new Faker();
        var firstName = faker.Name.FirstName();
        
        await _demoQaWebTablePage.GoToDemoQaWebTablePage();
        await _demoQaWebTablePage.EditRowAndVerify(firstName);
    }
    
    //Delete row and verify row deleted
    
    [Test]
    public async Task DeleteRowAndVerify()
    {
        await _demoQaWebTablePage.GoToDemoQaWebTablePage();
        await _demoQaWebTablePage.DeleteRowAndVerify();
    }
}