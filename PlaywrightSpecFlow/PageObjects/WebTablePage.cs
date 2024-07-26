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
    private ILocator TableContent => _page!.Locator("//div[@class='rt-tbody']");
    private ILocator FirstNameColomnHeader => _page!.Locator("//div[contains(text(), 'First Name')]");
    private ILocator LastNameColomnHeader => _page!.Locator("//div[contains(text(), 'Last Name')]");
    private ILocator AgeColomnHeader => _page!.Locator("//div[contains(text(), 'Age')]");
    private ILocator EmailColomnHeader => _page!.Locator("//div[contains(text(), 'Email')]");
    private ILocator SalaryColomnHeader => _page!.Locator("//div[contains(text(), 'Salary')]");
    private ILocator DepartmantColomnHeader => _page!.Locator("//div[contains(text(), 'Department')]");


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

    private ILocator TableRowsPerPage => _page!.Locator("//span[@class='select-wrap -pageSizeOptions']");

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

    public async Task WhenIAddTheFollowingItems(Table table)
    {
        Faker faker = new Faker();

        // Iterate through each row in the table
        foreach (var row in table.Rows)
        {
            // Click on Add button
            await AddButton.ClickAsync();

            // Set FirstName
            await FirstNameInput.FillAsync(row["FirstName"]);

            // Set LastName
            await LastNameInput.FillAsync(row["LastName"]);

            // Set Email
            await EmailInput.FillAsync(row["Email"]);

            // Set Age
            var age = faker.Random.Number(18, 99).ToString();
            await AgeInput.FillAsync(age);

            // Set Salary
            var salary = faker.Random.Number(1500, 4000).ToString();
            await SalaryInput.FillAsync(salary);

            // Set Department
            var department = faker.Commerce.Department();
            await DepartmantInput.FillAsync(department);

            // Click on Submit button
            await SubmitButton.ClickAsync();
        }
    }

    public async Task ThenIShouldSeeTheFollowingItemsInTheTable(Table table)
    {
        var expectedData = table.Rows.Select(row => new
        {
            FirstName = row["FirstName"].Trim('\"'),
            LastName = row["LastName"].Trim('\"'),
            Email = row["Email"].Trim('\"')
        }).ToList();

        // Retrieve all rows from the web table
        var rows = await _page!.QuerySelectorAllAsync("rt-tbody");

        foreach (var expectedItem in expectedData)
        {
            var itemFound = false;
            foreach (var row in rows)
            {
                var cells = await row.QuerySelectorAllAsync("td");
                var firstName = await cells[0].InnerTextAsync();
                var lastName = await cells[1].InnerTextAsync();
                var email = await cells[2].InnerTextAsync();

                if (firstName.Trim().Equals(expectedItem.FirstName) &&
                    lastName.Trim().Equals(expectedItem.LastName) &&
                    email.Trim().Equals(expectedItem.Email))
                {
                    itemFound = true;
                    break;
                }
            }
        }
    }
}