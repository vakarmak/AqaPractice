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

        private const string StorageStatePath = "state.json";

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _userManagement = new UserManagement(new HttpClient());

            // Создание пользователя через API
            await _userManagement.CreateUserViaApi(BaseUrl, UserData);

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = ["--start-maximized"]
            });

            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
                StorageStatePath = File.Exists(StorageStatePath) ? StorageStatePath : null
            };

            _context = await _browser.NewContextAsync(contextOptions);
            Page = await _context.NewPageAsync();

            // Сохранение состояния сессии
            await _context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = StorageStatePath
            });
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            // Удаление пользователя через API
            await _userManagement.DeleteUserViaApi(BaseUrl, UserData["email"], UserData["password"]);
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [TearDown]
        public async Task Teardown()
        {
            await _context?.CloseAsync()!;
            _context = null;
            Page = null;
        }
    }
}
