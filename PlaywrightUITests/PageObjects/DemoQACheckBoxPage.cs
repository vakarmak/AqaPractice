using Microsoft.Playwright;

namespace PlaywrightUITests.PageObjects
{
    internal class DemoQaCheckBoxPage(IPage page)
    {
        private readonly string _radioButtonPageUrl = "https://demoqa.com/checkbox";

        public async Task GoToDemoQaCheckboxPage()
        {
            await page.GotoAsync(_radioButtonPageUrl);
        }

        public async Task CheckHomeCheckbox()
        {
            await page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

        public async Task CheckCheckbox(string branch)
        {
            await page.Locator("label").Filter(new() { HasText = branch }).GetByRole(AriaRole.Img).First.ClickAsync();
        }

        public async Task OpenHome()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task OpenDocuments()
        {
            await page.Locator("li").Filter(new() { HasTextRegex = new Regex("^Documents$") }).GetByLabel("Toggle")
                .ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(page.Locator("#tree-node path").Nth(3)).ToBeCheckedAsync();
        }

        public async Task<bool> VerifyCheckboxChecked(string branch)
        {
            // Locate `span` element containing the branch title
            var spanElement = page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))");
            // Locate the checkbox in `span` element
            var checkboxLocator = spanElement.Locator(".rct-icon-check");
            // Check if the checkbox is visible
            var checkboxVisible = await checkboxLocator.IsVisibleAsync();
            return checkboxVisible;
        }

        public async Task CheckDocumentsCheckboxResult()
        {
            var expectedText = "You have selected : documents workspace react angular veu office public private classified general";
            var expectedTextNoSpaces = expectedText.Replace(" ", "");
            
            var result = await page.Locator("#result").TextContentAsync();
            var resultNoSpaces = result.Replace(" ", "");
            Assert.That(resultNoSpaces, Is.EqualTo(expectedTextNoSpaces));
        }
        
        public async Task OpenWorkSpace()
        {
            await page.Locator("li").Filter(new() { HasTextRegex = new Regex("^WorkSpace$") }).GetByLabel("Toggle")
                .ClickAsync();
        }
        
        public async Task VerifyElementHasLeafIcon(string element)
        {
            var leafIcon = page.Locator("label").Filter(new() { HasText = element }).GetByRole(AriaRole.Img).Nth(1);
            await Assertions.Expect(leafIcon).ToBeVisibleAsync();
        }
    }
}
