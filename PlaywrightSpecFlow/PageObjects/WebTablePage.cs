using Bogus;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.PageObjects;

internal class WebTablePage
{
    private readonly IPage? _page;
    private readonly string _webTablePageUrl = "https://demoqa.com/webtables";

    public WebTablePage(IPage? page)
    {
        _page = page;
    }

    //Locators
    private ILocator Table => _page!.Locator("//div[@class='rt-table']");

    private ILocator AddButton => _page!.Locator("//button[@id='addNewRecordButton']");

    private ILocator RegistrationPopupTitle => _page!.Locator("//div[@id='registration-form-modal']");

    private ILocator FirstNameInput => _page!.Locator("//input[@id='firstName']");
    private ILocator LastNameInput => _page!.Locator("//input[@id='lastName']");
    private ILocator EmailInput => _page!.Locator("//input[@id='userEmail']");
    private ILocator AgeInput => _page!.Locator("//input[@id='age']");
    private ILocator SalaryInput => _page!.Locator("//input[@id='salary']");
    private ILocator DepartmantInput => _page!.Locator("//input[@id='department']");

    private ILocator CloseButton => _page!.Locator("//button[@class='close']");
    private ILocator SubmitButton => _page!.Locator("//button[@id='submit']");

    //Methods

    public async Task GoToWebTablePage()
    {
        await _page!.GotoAsync(_webTablePageUrl);
    }

    public async Task VerifyWebTableIsVisible()
    {
        await Table.IsVisibleAsync();
    }

    //First Scenario Methods

    public async Task VerifyFirstNameColumnValues(string firstName)
    {
        var rows = await _page!.QuerySelectorAllAsync($"//div[contains(text(), '{firstName}')]");
        foreach (var row in rows)
        {
            var columnContent = await row.TextContentAsync();
            if (columnContent!.Contains(firstName))
            {
                return;
            }
        }
        Assert.Fail($"{firstName} is not found in the First Name column");
    }

    public async Task VerifySecondNameColumnValues(string lastName)
    {
        var rows = await _page!.QuerySelectorAllAsync($"//div[contains(text(), '{lastName}')]");
        foreach (var row in rows)
        {
            var columnContent = await row.TextContentAsync();
            if (columnContent!.Contains(lastName))
            {
                return;
            }
        }
        Assert.Fail($"{lastName} is not found in the Last Name column");
    }

    //Second Scenario Methods

    public async Task WhenIAddTheFollowingItems(string firstName, string lastName, string email)
    {
        Faker faker = new Faker();

        await AddButton.ClickAsync();

        await FirstNameInput.FillAsync(firstName);

        await LastNameInput.FillAsync(lastName);

        await EmailInput.FillAsync(email);

        var age = faker.Random.Number(18, 45).ToString();
        await AgeInput.FillAsync(age);

        var salary = faker.Random.Number(1500, 4000).ToString();
        await SalaryInput.FillAsync(salary);

        var department = faker.Commerce.Department();
        await DepartmantInput.FillAsync(department);

        await SubmitButton.ClickAsync();
    }

    public async Task<bool> ThenIShouldSeeTheFollowingItemsInTheTable(string firstName, string lastName, string email)
    {
        var rows = await _page!.QuerySelectorAllAsync("rt-tbody");

        foreach (var row in rows)
        {
            var rowText = await row.InnerTextAsync();
            if (rowText.Contains(firstName) && rowText.Contains(lastName) && rowText.Contains(email))
            {
                return true;
            }
            Assert.Fail($"The row with FirstName: {firstName}, LastName: {lastName}, Email: {email} was not found in the table.");
        }
        return false;
    }
}