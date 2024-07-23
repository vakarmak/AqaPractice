using Microsoft.Playwright;
using PlaywrightSpecFlow.Bindings;
using PlaywrightSpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Features;

[Binding]
internal sealed class WebTableSteps : UiTestFixture
{
    private static WebTablePage? _webTablePage;

    [BeforeFeature(@"WebPageLogin")]
    public static Task FirstBeforeScenario()
    {
        _webTablePage = new WebTablePage(Page);
        return Task.CompletedTask;
    }

    [Given(@"I am on DemoQA WebTable Page")]
    public static async Task WhenIOpenWebTablePage() =>
        await _webTablePage!.GoToDemoQaWebTablesPage();

    [When(@"I see the WebTable")]
    public async Task WhenISeeTheWebTable() =>
        await _webTablePage!.VerifyTableVisible();

    [When(@"I click Add Button")]
    public async Task WhenIClickAddButton() =>
        await _webTablePage!.ClickAddButton();

    [When(@"I set FirstName to ""(.*)""")]
    public async Task WhenISetFirstName(string firstName) =>
        await _webTablePage!.FillFirstName(firstName);

    [When(@"I set LastName to ""(.*)""")]
    public async Task WhenISetLastName(string lastName) =>
        await _webTablePage!.FillLastName(lastName);

    [Then(@"I see FirstName ""(.*)"" in a table")]
    public async Task ThenISeeFirstName(string firstName) =>
        await Assertions.Expect(Page!.GetByRole(AriaRole.Gridcell, new() { Name = firstName, Exact = true }))
            .ToBeVisibleAsync();

    [When(@"I set Email ""(.*)"" in a table")]
    public async Task ThenISetEmail(string email)
    {
        await Page!.GetByPlaceholder("name@example.com").FillAsync(email);
        await Page.GetByPlaceholder("name@example.com").PressAsync("Enter");
    }

    [Then(@"I see LastName ""(.*)"" in a table")]
    public async Task ThenISeeLastName(string lastName) =>
        await Assertions.Expect(Page!.GetByRole(AriaRole.Gridcell, new() { Name = lastName, Exact = true }))
            .ToBeVisibleAsync();
}