using Microsoft.Playwright;
using PlaywrightSpecFlow.Bindings;
using PlaywrightSpecFlow.PageObjects;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Features;

[Binding]
internal sealed class WebTableSteps : UiTestFixture
{
    private static WebTablePage? _webTablePage;
    
    [BeforeFeature("@WebPageLogin")]
    public static void SetupWebTablePage()
    {
        _webTablePage = new WebTablePage(Page);
    }
    
    [Given(@"I am on DemoQA WebTable Page")]
    public async Task WhenIOpenWebTablePage() => await _webTablePage!.GoToDemoQaWebTablesPage();
    
    [When(@"I see Web Table")]
    public async Task WhenISeeWebTable() => await _webTablePage!.VerifyTableVisible();
    
    [Then(@"I see FirstName ""(.*)"" column in a table")]
    public async Task ThenISeeFirstNameColumn(string firstName) => await _webTablePage!.VerifyFirstNameColumn(firstName);

    [Then(@"I see LastName ""(.*)"" column in a table")]
    public async Task ThenISeeLastNameColumn(string lastName) => await _webTablePage!.VerifyLastNameColumn(lastName);
    
}