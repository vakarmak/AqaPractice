using Microsoft.Playwright;

namespace Diploma.PageObjects;

internal class HomePage(IPage? page)
{
    private const string HomePageUrl = "https://automationexercise.com/";

    // Locators
    private ILocator LoginButton => page!.Locator("//a[@href='/login']");
    private ILocator EmailInput => page!.Locator("//input[@data-qa='login-email']");
    private ILocator PasswordInput => page!.Locator("//input[@data-qa='login-password']");
    private ILocator LoginSubmitButton => page!.Locator("//button[@data-qa='login-button']");

    private ILocator UserLogin(string userLogin) => page!.GetByText($"Logged in as {userLogin}");
    private ILocator DeleteAccountButton => page!.Locator("//a[@href='/delete_account']");
    private ILocator DeleteAccountConfirmation => page!.Locator("//h2[@data-qa='account-deleted']");

    // Methods
    public async Task GoToHomePage()
    {
        await page!.GotoAsync(HomePageUrl);
    }
    
    public async Task VerifyHomePageIsOpened()
    {
        await Assertions.Expect(page).ToHaveURLAsync(HomePageUrl);
    }

    public async Task GoToLoginPage()
    {
        await LoginButton.ClickAsync();
    }

    public async Task Login(string email, string password)
    {
        await EmailInput.FillAsync(email);
        await PasswordInput.FillAsync(password);
        await LoginSubmitButton.ClickAsync();
    }

    public async Task VerifyUserLogin(string userLogin)
    {
        await UserLogin(userLogin).IsVisibleAsync();
    }

    public async Task DeleteAccount()
    {
        await DeleteAccountButton.ClickAsync();
    }

    public async Task IsAccountDeleted()
    {
        await DeleteAccountConfirmation.IsVisibleAsync();
    }
}