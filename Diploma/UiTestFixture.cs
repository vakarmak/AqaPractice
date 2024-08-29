using Diploma.ApiMethods;
using Microsoft.Playwright;

namespace Diploma
{
    [TestFixture]
    internal class UiTestFixture
    {
        protected IPage Page { get; private set; }
        private IBrowser _browser;
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

        private const string StorageStatePath = "state.json";

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _userManagement = new UserManagement(new HttpClient());

            await _userManagement.CreateUserViaApi(BaseUrl, UserData);

            var playwrightDriver = await Playwright.CreateAsync();
            _browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set false to run the browser in non-headless mode
                Args = ["--start-maximized"] // Set the browser to start maximized
            });

            var projectDirectory =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
            var fileDirectory = Path.Combine(projectDirectory, "Diploma", ".auth");
            var authStatePath = Path.Combine(projectDirectory, "Diploma", ".auth", "state.json");

            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
                Console.WriteLine($"Created Scripts directory at path: {fileDirectory}");
            }

            if (!File.Exists(authStatePath))
            {
                await File.Create(authStatePath).DisposeAsync();
            }

            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                StorageStatePath = authStatePath
            });

            Page = await context.NewPageAsync();

            await context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = authStatePath
            });
        }

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            _browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set false to run the browser in non-headless mode
                Args = ["--start-maximized"] // Set the browser to start maximized
            });

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                StorageStatePath = File.Exists(StorageStatePath) ? StorageStatePath : null
            };

            var context = await _browser.NewContextAsync(contextOptions);
            Page = await context.NewPageAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _userManagement.DeleteUserViaApi(BaseUrl, UserData["email"], UserData["password"]);
        }

        [TearDown]
        public async Task Teardown()
        {
            await _browser.CloseAsync();
        }
    }
}