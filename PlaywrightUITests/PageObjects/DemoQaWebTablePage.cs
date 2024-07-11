using Microsoft.Playwright;

namespace PlaywrightUiTests.PageObjects;

internal class DemoQaWebTablePage(IPage page)
{
    private readonly string _webTablePageUrl = "https://demoqa.com/webtables";

    private ILocator AddButton => page.GetByRole(AriaRole.Button, new() { Name = "Add" });
    private ILocator SubmitButton => page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
    private ILocator EditButton => page.Locator("#edit-record-1 path");
    private ILocator DeleteButton => page.Locator("#delete-record-1").GetByRole(AriaRole.Img);

    public async Task GoToDemoQaWebTablePage()
    {
        await page.GotoAsync(_webTablePageUrl);
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

    public async Task VerifyTableRowContent(string headerName, string value)
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
            var cellContent = await cells.First().InnerTextAsync();
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

    public async Task CheckMandatoryFields()
    {
        await AddButton.ClickAsync();
        var registrationForm = page.Locator(".modal-content");
        await SubmitButton.ClickAsync();
        var validationMark =  registrationForm.Locator("//*[@id=\"userForm\"]");
        await Assertions.Expect(validationMark).ToHaveAttributeAsync("class", "was-validated");
    }

    public async Task AddNewRow(string firstName, string lastName, string email, int age, int salary, string department)
    {
        await AddButton.ClickAsync();
        await page.Locator(".modal-content").IsVisibleAsync();
        await page.GetByPlaceholder("First Name").FillAsync(firstName);
        await page.GetByPlaceholder("Last Name").FillAsync(lastName);
        await page.GetByPlaceholder("name@example.com").FillAsync(email);
        await page.GetByPlaceholder("Age").FillAsync(age.ToString());
        await page.GetByPlaceholder("Salary").FillAsync(salary.ToString());
        await page.GetByPlaceholder("Department").FillAsync(department);
        await SubmitButton.ClickAsync();
    }

    public async Task VerifyAddedRow(string firstName, string lastName)
    {
        await page.Locator(".modal-content").IsVisibleAsync();
        await Assertions.Expect(page.Locator("//div[@class='rt-tr-group'][4]")).ToContainTextAsync(firstName);
        await Assertions.Expect(page.Locator("//div[@class='rt-tr-group'][4]")).ToContainTextAsync(lastName);
    }
    
    public async Task EditRowAndVerify(string firstname)
    {
        await EditButton.ClickAsync();
        await page.GetByPlaceholder("First Name").FillAsync(firstname);
        await SubmitButton.ClickAsync();
        await Assertions.Expect(page.Locator("//div[@class='rt-tbody']/div[1]")).ToContainTextAsync(firstname);
    }
    
    public async Task DeleteRowAndVerify()
    {
        await DeleteButton.ClickAsync();
        await page.Locator("//div[@class='rt-tbody']/div[1]").IsHiddenAsync();
    }
}