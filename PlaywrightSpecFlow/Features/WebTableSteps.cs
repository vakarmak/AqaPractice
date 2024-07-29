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

    [When(@"I add the FisrtName ""(.*)"" and LastName ""(.*)"" and Email ""(.*)"" to the table")]
    public async Task IAddTheFollowingItems(string firstName, string lastName, string email) =>
        await _webTablePage!.WhenIAddTheFollowingItems(firstName, lastName, email);

    [Then(@"I should see the FirstName ""(.*)"" and LastName ""(.*)"" and ""(.*)"" in the table")]
    public async Task ThenIShouldSeeTheFollowingItems(string firstName, string lastName, string email) =>
        await _webTablePage!.ThenIShouldSeeTheFollowingItemsInTheTable(firstName, lastName, email);
}