using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class CompareProductNamesTest : UiTestFixture
{
    private SolarShopPage _solarShopPage;
    
    [SetUp]
    public void SetupSolarTechnologyShopPage()
    {
        _solarShopPage = new SolarShopPage(Page);
    }
    
    [Test]
    public async Task CompareProductNames()
    {
        // Arrange
        await _solarShopPage.GoToSolarTechnologyShopPage();
        await _solarShopPage.GoToInvertersPage();
        var inverterPage = new InvertersPage(Page);
        
        // Act
        var expectedProductName = await inverterPage.GoToInverterDetailsPage();
        var actualProductName = await inverterPage.GetProductDetailsName(expectedProductName);

        // Assert
        Assert.That(expectedProductName, Is.EqualTo(actualProductName), "Product names are not the same");
    }
}