using PlaywrightSpecFlow.ApiTesting.Account;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.Features.Account
{
    [Binding]
    public class AccountSteps
    {
        private readonly FeatureContext _featureContext;

        public AccountSteps(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature(@"ICreateAccountByAPI")]
        public static async Task WhenICreateAccountByApi(FeatureContext featureContext)
        {
            AccountPreSetup accountPreSetup = new();
            await accountPreSetup.AccountApiPreSetup();
            featureContext["AccountApiPreSetup"] = accountPreSetup;
        }

        [When(@"I get success status code from API")]
        public void WhenIGetSuccessStatusCodeFromApi()
        {
            var preSetup = _featureContext.Get<AccountPreSetup>("AccountApiPreSetup");
            Assert.That(preSetup.UserId, Is.Not.Null, "Account not created");
        }
        
        [AfterFeature(@"ICreateAccountByAPI")]
        public static async Task WhenICleanupAccountByApi(FeatureContext featureContext)
        {
            var preSetup = featureContext.Get<AccountPreSetup>("AccountApiPreSetup");
            await preSetup.AccountApiCleanup();
        }
    }
}
