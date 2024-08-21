using Microsoft.Playwright;

namespace PlaywrightUiTests.HomeworkLesson26;

internal class SmartWait : UiTestFixture
{
    [Test]
    public async Task Nike()
    {
        //Arrange
        await Page.GotoAsync("https://www.nike.com/");
        await Page.GetByTestId("dialog-accept-button").ClickAsync();
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Women" }).ClickAsync();
        await Page.GetByLabel("secondary").GetByLabel("Shoes", new LocatorGetByLabelOptions { Exact = true })
            .ClickAsync();

        //Act
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Color", Exact = true }).ClickAsync();
        var titlesBefore = await Page.Locator(".product-card__title").AllInnerTextsAsync();
        await Page.GetByLabel("Filter for Blue").ClickAsync();

        await Page.WaitForTimeoutAsync(5000); // Replace this line with smart waiting

        var titlesAfter = await Page.Locator(".product-card__title").AllInnerTextsAsync();

        //Assert
        Assert.That(titlesAfter.First(), Is.Not.EqualTo(titlesBefore.First()));

    }

    [Test]
    public async Task Sneakers()
    {
        //Arrange
        await Page.GotoAsync("https://deltasport.ua/ua/store/women/");

        //Act
        var titlesBefore = await Page.Locator(".item_name").AllInnerTextsAsync();
        await Page.Locator("li").Filter(new LocatorFilterOptions { HasText = "Кросівки" }).Locator("label").ClickAsync();

        await Page.WaitForTimeoutAsync(5000); // Replace this line with smart waiting

        var titlesAfter = await Page.Locator(".item_name").AllInnerTextsAsync();

        //Assert
        Assert.That(titlesBefore.First().ToLower(), Does.Not.Contain("кросівки"));
        Assert.That(titlesAfter.First().ToLower(), Does.Contain("кросівки"));
    }
}