using Microsoft.Playwright;
using PlaywrightUltimate.PageObjects;

namespace PlaywrightUltimate.Tests
{
    internal class UltimateQaTests
    {
        private UltimateQaPage _ultimateQaPage;
        
        private IPage Page { get; set; }
        private IBrowser _browser;
        private IBrowserContext _context;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Args = ["--start-maximized"]
            });

            var projectDirectory =
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
            var fileDirectory = Path.Combine(projectDirectory, "PlaywrightUltimate", ".auth");
            var authStatePath = Path.Combine(projectDirectory, "PlaywrightUltimate", ".auth", "state.json");

            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
                Console.WriteLine($"Created Scripts directory at path: {fileDirectory}");
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

            await Page.GotoAsync("https://courses.ultimateqa.com/enrollments");

            if (Page.Url.Contains("sign_in"))
            {
                await Page.FillAsync("input[name='user[email]']", "lichar@ukr.net");
                await Page.FillAsync("input[name='user[password]']", "Qwerty12345*");
                await Page.ClickAsync("button[type='submit']");

                await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                await _context.StorageStateAsync(new BrowserContextStorageStateOptions
                {
                    Path = authStatePath
                });
            }

            _ultimateQaPage = new UltimateQaPage(Page);
        }

        [Test]
        public async Task VerifyProductByFilter()
        {
            await _ultimateQaPage.ViewMoreCourses();
            await _ultimateQaPage.VerifyPageUrl("collections");
            await _ultimateQaPage.SearchForProductAndVerifyResult("Selenium");
            await _ultimateQaPage.GoToMyDashboard();
            await _ultimateQaPage.VerifyDashBoardWelcomeText();
            await _ultimateQaPage.ClickOnUserMenu();
        }
    }
}