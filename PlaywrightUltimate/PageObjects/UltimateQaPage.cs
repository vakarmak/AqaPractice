using Microsoft.Playwright;

namespace PlaywrightUltimate.PageObjects
{
    internal class UltimateQaPage(IPage page)
    {
        private const string UltimateQaTargetPage = "https://courses.ultimateqa.com/enrollments";

        // Locators

        private ILocator EmailInput => page.Locator("input[name='user[email]']");
        private ILocator PasswordInput => page.Locator("input[name='user[password]']");
        private ILocator SignInButton => page.Locator("button[type='submit']");
        
        private ILocator MyDashboard => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "My Dashboard" });
        private ILocator ViewMoreCoursesLink => page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "View more courses" });
        private ILocator ProductsSearch => page.GetByPlaceholder("Search");
        
        private ILocator UserMenu => page.GetByLabel("Toggle menu");
        private ILocator DashboardHeader(string userName) => page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = $"      Welcome back, {userName}!    " });
        
        // Methods
        
        public async Task ViewMoreCourses()
        {
            await ViewMoreCoursesLink.ClickAsync();
        }

        public async Task VerifyPageUrl(string pageUrl)
        {
            await Assertions.Expect(page).ToHaveURLAsync($"https://courses.ultimateqa.com/{pageUrl}");
        }

        public async Task SearchForProductAndVerifyResult(string productName)
        {
            await ProductsSearch.FillAsync(productName);
            await page.Keyboard.PressAsync("Enter");
            await Task.Delay(1500);

            var elements = await page.QuerySelectorAllAsync(".products__list-item");

            Assert.That(elements, Is.Not.Empty, $"No products were found for search term '{productName}'.");

            var productFound = false;

            foreach (var element in elements)
            {
                var text = await element.InnerTextAsync();

                if (!text.Contains(productName)) continue;
                productFound = true;
                break;
            }

            Assert.That(productFound, $"Product '{productName}' was not found in the list.");
        }
        
        public async Task GoToMyDashboard()
        {
            await MyDashboard.ClickAsync();
            Assert.That(page.Url, Is.EqualTo("https://courses.ultimateqa.com/enrollments"));
        }
        
        public async Task VerifyDashBoardWelcomeText()
        {
            var userName = (await UserMenu.InnerTextAsync()).Trim();
            
            var dashboardHeaderElement = await DashboardHeader(userName).InnerTextAsync();
        }
        
        public async Task ClickOnUserMenu()
        {
            await UserMenu.ClickAsync();
            await Assertions.Expect(UserMenu).ToHaveAttributeAsync("aria-expanded", "true");
        }
    }
}
