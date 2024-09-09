using Diploma.ApiMethods;
using Microsoft.Playwright;

namespace Diploma
{
    [TestFixture]
    internal class UiTestFixture 
    {
        protected IPage? Page { get; private set; }
        private IBrowser _browser;
        private IBrowserContext? _context;
        private IPlaywright _playwright;
        private UserManagement _userManagement;
        private const string BaseUrl = "https://automationexercise.com/";

        protected readonly Dictionary<string, string> UserData = new()
        {
            { "email", "testMaks@gmail.com" },
            { "password", "Qwerty12345*" },
            { "name", "testName" },
            { "firstname", "testFirstName" },
            { "lastname", "testLastName" },
            { "address1", "testAddress1" },
            { "country", "testCountry" },
            { "state", "testState" },
            { "city", "testCity" },
            { "zipcode", "1598645" },
            { "mobile_number", "0987458595" }
        };

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _userManagement = new UserManagement(new HttpClient());

            await _userManagement.CreateUserViaApi(BaseUrl, UserData);
        }

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = ["--start-maximized"]
            });

            var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
            var fileDirectory = Path.Combine(projectDirectory, "Diploma", ".auth");
            var authStatePath = Path.Combine(fileDirectory, "state.json");

            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            if (!File.Exists(authStatePath))
            {
                await File.Create(authStatePath).DisposeAsync();
            }

            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = authStatePath,
                ViewportSize = ViewportSize.NoViewport
            });

            Page = await _context.NewPageAsync();

            await Page.GotoAsync($"{BaseUrl}login");

            if (Page.Url.Contains("login"))
            {
                await Page.FillAsync("//input[@data-qa='login-email']", UserData["email"]);
                await Page.FillAsync("//input[@data-qa='login-password']", UserData["password"]);
                await Page.ClickAsync("//button[@data-qa='login-button']");

                await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                await _context.StorageStateAsync(new BrowserContextStorageStateOptions
                {
                    Path = authStatePath
                });
            }

        }
        
        [TearDown]
        public async Task Teardown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
        
        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _userManagement.DeleteUserViaApi(BaseUrl, UserData["email"], UserData["password"]);
        }
    }
}
