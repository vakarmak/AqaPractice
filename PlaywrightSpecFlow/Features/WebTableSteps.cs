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
        await _webTablePage!.GoToWebTablePage();

    [When(@"I see the WebTable")]
    public async Task WhenISeeTheWebTable() =>
        await _webTablePage!.VerifyWebTableIsVisible();

    // First Scenario

    [Then(@"I see FirstName ""(.*)"" in a table")]
    public async Task ThenISeeFirstName(string firstName) =>
    await _webTablePage!.VerifyFirstNameColumnValues(firstName);

    [Then(@"I see LastName ""(.*)"" in a table")]
    public async Task ThenISeeLastName(string lastName) =>
    await _webTablePage!.VerifySecondNameColumnValues(lastName);

    // Second Scenario

    [When(@"I add the following items:")]
    public async Task IAddTheFollowingItems(Table table) =>
        await _webTablePage!.WhenIAddTheFollowingItems(table);

    [Then(@"I should see following items in the table:")]
    public async Task ThenIShouldSeeTheFollowingItems(Table table) =>
        await _webTablePage!.ThenIShouldSeeTheFollowingItemsInTheTable(table);
}