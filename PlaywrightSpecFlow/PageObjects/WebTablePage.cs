using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightSpecFlow.PageObjects;

internal class WebTablePage
{
    private readonly IPage? _page;
    private readonly string _webTablePageUrl = "https://demoqa.com/webtables";

    public WebTablePage(IPage? page)
    {
        _page = page;
    }

    private ILocator AddButton => _page!.Locator("//button[@id='addNewRecordButton']");
    private ILocator SubmitButton => _page!.Locator("//button[@id='submit']");
    
    private ILocator EditButtonFirstRow => _page!.Locator("//span[@id='edit-record-1']");
    private ILocator DeleteButtonFirstRow => _page!.Locator("//span[@id='delete-record-1']");
    
    private ILocator RegistrationPopupTitle => _page!.Locator("//div[@id='registration-form-modal']");
    private ILocator RegistrationPopupModal => _page!.Locator("//form[@id='userForm']");
    private ILocator FirstNameInput => _page!.GetByPlaceholder("First Name");
    private ILocator LastNameInput => _page!.GetByPlaceholder("Last Name");
    private ILocator EmailInput => _page!.GetByPlaceholder("name@example.com");
    private ILocator AgeInput => _page!.GetByPlaceholder("Age");
    private ILocator SalaryInput => _page!.GetByPlaceholder("Salary");
    private ILocator DepartmentInput => _page!.GetByPlaceholder("Department");
    
    private ILocator Table => _page!.Locator("//div[@class='rt-table']");
    private ILocator TableRows => _page!.Locator("//div[@class='rt-tr-group']");
    private ILocator TableFirstRow => _page!.Locator("//div[@class='rt-tbody']/div[1]");
    private ILocator TableFourthRow => _page!.Locator("//div[@class='rt-tbody']/div[4]");
    private ILocator FirstNameColumn => _page!.Locator("//div[@class='rt-tr']/div[1]");
    private ILocator LastNameColumn => _page!.Locator("//div[@class='rt-tr']/div[2]");
    
    public async Task GoToDemoQaWebTablesPage()
    {
        await _page!.GotoAsync(_webTablePageUrl);
    }
    
    public async Task VerifyTableVisible()
    {
        await Assertions.Expect(Table).ToBeVisibleAsync();
    }
    
    public async Task VerifyTableRowVisible()
    {
        var rows = await TableRows.AllAsync();
        if (rows.Any())
        {
            await Assertions.Expect(rows[0]).ToBeVisibleAsync();
        }
        else
        {
            Assert.Fail("No rows found in the table.");
        }
    }
    
    public async Task RegistrationPopupVisible()
    {
        await Assertions.Expect(RegistrationPopupTitle).ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameFieldInModalIslVisible()
    {
        await AddButton.ClickAsync();
        await Assertions.Expect(FirstNameInput).ToBeVisibleAsync();
    }

    public async Task CheckMandatoryFields()
    {
        await AddButton.ClickAsync();
        await SubmitButton.ClickAsync();
        await Assertions.Expect(RegistrationPopupModal).ToHaveAttributeAsync("class", "was-validated");
    }
    
    public async Task AddNewRow(string firstName, string lastName, string email, int age, int salary, string department)
    {
        await AddButton.ClickAsync();
        await FirstNameInput.FillAsync(firstName);
        await LastNameInput.FillAsync(lastName);
        await EmailInput.FillAsync(email);
        await AgeInput.FillAsync(age.ToString());
        await SalaryInput.FillAsync(salary.ToString());
        await DepartmentInput.FillAsync(department);
        await SubmitButton.ClickAsync();
    }

    public async Task VerifyAddedRow(string firstName, string lastName)
    {
        await Assertions.Expect(TableFourthRow).ToContainTextAsync(firstName);
        await Assertions.Expect(TableFourthRow).ToContainTextAsync(lastName);
    }

    public async Task EditRowAndVerifyRowEdited(string firstName)
    {
        await EditButtonFirstRow.ClickAsync();
        await RegistrationPopupVisible();
        await FirstNameInput.ClearAsync();
        await FirstNameInput.FillAsync(firstName);
        await SubmitButton.ClickAsync();
        await Assertions.Expect(TableFirstRow).ToContainTextAsync(firstName);
    }
    
    public async Task DeleteRowAndVerifyRowDeleted()
    {
        await DeleteButtonFirstRow.ClickAsync();
        await Assertions.Expect(TableFirstRow).Not.ToContainTextAsync("Cierra");
    }

    public async Task VerifyFirstNameColumn(string firstName)
    {
        await Assertions.Expect(FirstNameColumn).ToBeVisibleAsync();
    }
    
    public async Task VerifyLastNameColumn(string lastName)
    {
        await Assertions.Expect(LastNameColumn).ToBeVisibleAsync();
    }
    
    public async Task ClickOnAddButton()
    {
        await AddButton.ClickAsync();
    }
}