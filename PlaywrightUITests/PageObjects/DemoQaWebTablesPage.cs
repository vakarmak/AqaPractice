using Bogus;
using Microsoft.Playwright;

namespace PlaywrightUITests.PageObjects;

internal class DemoQaWebTablesPage(IPage page)
{
    private readonly string _webTablesPageUrl = "https://demoqa.com/webtables";

    private ILocator AddRowButton => page.Locator("//button[@id='addNewRecordButton']");
    private ILocator SubmitButton => page.Locator("//button[@id='submit']");

    public async Task GoToDemoQaWebTablesPage()
    {
        await page.GotoAsync(_webTablesPageUrl);
    }

    public async Task VerifyTableVisible()
    {
        var table = page.Locator(".ReactTable");
        await Assertions.Expect(table).ToBeVisibleAsync();
    }

    public async Task VerifyTableRowVisible()
    {
        var table = page.Locator(".ReactTable");
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        if (rows.Any())
        {
            await Assertions.Expect(rows.First()).ToBeVisibleAsync();
        }
        else
        {
            Assert.Fail("No rows found in the table.");
        }
    }

    public async Task VerifyTableRowContent(string headerName = "First Name", string value = "Cierra")
    {
        var table = page.Locator(".ReactTable");

        // Locate headers
        var headers = await table.Locator(".rt-th").AllInnerTextsAsync();
        var headersList = headers.ToList();

        // Find the index of the specified header
        int headerIndex = headersList.IndexOf(headerName);

        if (headerIndex == -1)
        {
            Assert.Fail($"Header '{headerName}' not found.");
        }

        // Locate all rows
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        // Locate the cells in the specified column for each row
        var cells = new List<ILocator>();
        foreach (var row in rows)
        {
            var rowCells = await row.Locator(".rt-td").AllAsync();
            if (rowCells.Count > headerIndex)
            {
                cells.Add(rowCells[headerIndex]);
            }
            else
            {
                Assert.Fail("Row does not contain enough cells.");
            }
        }

        // Check if the content of the first cell in the specified column matches the given value
        if (cells.Any())
        {
            var cellContent = await cells.Last().InnerTextAsync();
            Assert.That(cellContent == value, $"The content of the first cell in the '{headerName}' column does not match '{value}'.");
        }
        else
        {
            Assert.Fail($"No cells found in the '{headerName}' column.");
        }
    }

    public async Task VerifyPopupVisible()
    {
        var popup = page.Locator(".modal-content");
        await Assertions.Expect(popup).ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameVisible()
    {
        var popup = page.Locator(".modal-content");
        var firstName = popup.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }
    
    public async Task OpenAddRowPopup()
    {
        await AddRowButton.ClickAsync();
    }

    public async Task SubmitChanges()
    {
        await SubmitButton.ClickAsync();
    }

    public async Task AddNewRow(string firstName, string lastName, string email, string age, string salary,
        string department)
    {
        var popup = page.Locator("//form[@id='userForm']");
        var firstNameInput = popup.GetByPlaceholder("First Name");
        var lastNameInput = popup.GetByPlaceholder("Last Name");
        var emailInput = popup.GetByPlaceholder("name@example.com");
        var ageInput = popup.Locator("//input[@id='age']");
        var salaryInput = popup.Locator("//input[@id='salary']");
        var departmentInput = popup.GetByPlaceholder("Department");
    }

    public async Task VerifyAddedRow()
    {
        
    }
}