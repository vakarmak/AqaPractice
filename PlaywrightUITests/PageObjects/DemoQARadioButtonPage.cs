using Microsoft.Playwright;

namespace PlaywrightUITests.PageObjects
{
    internal class DemoQaRadioButtonPage(IPage page)
    {
        private readonly string _elementsPageUrl = "https://demoqa.com/elements";
        private readonly string _radioButtonPageUrl = "https://demoqa.com/radio-button";

        public async Task GoToRadiButtonsPage()
        {
            await page.GotoAsync(_elementsPageUrl);
            await page.GetByText("Radio Button").ClickAsync();
            await page.WaitForURLAsync(_radioButtonPageUrl);
        }

        public async Task ClickYesRadioButton()
        {
            await page.GetByText("Yes").CheckAsync();
        }

        public async Task ClickImpressiveRadioButton()
        {
            await page.GetByText("Impressive").CheckAsync();
        }

        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task CheckYesRadioChecked()
        {
            await page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task CheckImpressiveRadioButton()
        {
            await page.Locator("#impressiveRadio").IsCheckedAsync();
        }
        
        public async Task VerifyTextImpressiveVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected Impressive")).ToBeVisibleAsync();
        }
        
        public async Task CheckNoRadioButton()
        {
            await page.Locator("#noRadio").IsDisabledAsync();
        }

        public async Task VerifyTextNoVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected")).ToBeHiddenAsync();
        }

        public async Task CheckH1RadioButton()
        {
            await page.GetByRole(AriaRole.Heading, new() { Name = "Radio Button" }).IsVisibleAsync();
        }
        
        public async Task VerifyTextImpressiveNotVisible()
        {
            await page.GetByText("You have selected Impressive").IsHiddenAsync();
        }
    }
}
