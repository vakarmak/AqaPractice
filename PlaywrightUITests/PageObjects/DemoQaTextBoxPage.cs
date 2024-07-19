using Microsoft.Playwright;

namespace PlaywrightUiTests.PageObjects
{
    internal class DemoQaTextBoxPage(IPage page)
    {
        private readonly string _elementsPageUrl = "https://demoqa.com/elements";
        private readonly string _textBoxPageUrl = "https://demoqa.com/text-box";
        private readonly string _fullNamePlaceholder = "Full Name";
        private readonly string _submitButtonRole = "button";
        private readonly string _submitButtonName = "Submit";

        public async Task GoToElementsPage()
        {
            await page.GotoAsync(_elementsPageUrl);
        }

        public async Task ClickTextBoxMenu()
        {
            await page.GetByText("Text Box").ClickAsync();
        }

        public async Task WaitForTextBoxPage()
        {
            await page.WaitForURLAsync(_textBoxPageUrl);
        }

        public async Task<bool> IsFullNameTextVisible()
        {
            return await page.GetByText("Full Name").IsVisibleAsync();
        }

        public async Task<bool> IsFullNameInputVisible()
        {
            return await page.GetByPlaceholder(_fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await page.GetByPlaceholder(_fullNamePlaceholder).FillAsync(fullName);
        }

        public async Task ClickSubmitButton()
        {
            await page.GetByRole(AriaRole.Button, new() { Name = _submitButtonName }).ClickAsync();
        }

        public async Task<bool> IsNameVisible(string name)
        {
            return await page.GetByText($"Name:{name}").IsVisibleAsync();
        }

        public async Task<bool> IsNameHidden(string name)
        {
            return await page.GetByText($"Name:{name}").IsHiddenAsync();
        }
    }
}
