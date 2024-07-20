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
    
    [When(@"I see FirstName """"(.*)"""""" column in a table")]
    public async Task WhenISeeFirstNameColumn() => await _webTablePage!.VerifyFirstNameColumn();
    
    [When(@"I see FirstName """"(.*)"""""" column in a table")]
    public async Task WhenISeeLastNameColumn() => await _webTablePage!.VerifyLastNameColumn();
    
}