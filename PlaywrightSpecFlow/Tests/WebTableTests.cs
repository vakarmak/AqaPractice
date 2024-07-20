using Bogus;
using NUnit.Framework;
using PlaywrightSpecFlow.Bindings;
using PlaywrightSpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
// [Binding]
internal class WebTableTests : UiTestFixture
{
    private WebTablePage? _webTablePage;

    [SetUp]
    public void SetupWebTablePage()
    {
        _webTablePage = new WebTablePage(Page);
    }

    [Category("UI")]

    [Test]
    public async Task VerifyTableVisible()
    {
        await _webTablePage!.GoToDemoQaWebTablesPage();
        await _webTablePage!.VerifyTableVisible();
    }

    [Test]
    public async Task CheckMandatoryFields()
    {
        await _webTablePage!.GoToDemoQaWebTablesPage();
        await _webTablePage!.CheckMandatoryFields();
    }

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

        await _webTablePage!.GoToDemoQaWebTablesPage();
        await _webTablePage!.AddNewRow(firstName, lastName, email, age, salary, department);
        await _webTablePage!.VerifyAddedRow(firstName, lastName);
    }
    
    [Test]
    public async Task EditRowAndVerify()
    {
        var faker = new Faker();
        var firstName = faker.Name.FirstName();

        await _webTablePage!.GoToDemoQaWebTablesPage();
        await _webTablePage!.EditRowAndVerifyRowEdited(firstName);
    }
    
    [Test]
    public async Task DeleteRowAndVerify()
    {
        await _webTablePage!.GoToDemoQaWebTablesPage();
        await _webTablePage!.DeleteRowAndVerifyRowDeleted();
    }
}