using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class ProductDetailsTest : UiTestFixture
{
    private InvertersPage _invertersPage;
    
    [SetUp]
    public void SetupSolarTechnologyShopPage()
    {
        _invertersPage = new InvertersPage(Page);
    }
    
    [Test]
    public async Task CompareProductNames()
    {
        // Arrange
        await _invertersPage.GoToInvertersPage();
        
        // Act
        var productNameFromCard = await _invertersPage.GetProductName();
        await _invertersPage.GoToProductDetails();
        var productNameFromProductDetails = await _invertersPage.GetProductNameFromProductDetails();

        // Assert
        Assert.That(productNameFromProductDetails, Is.EqualTo(productNameFromCard), "Product names are not the same");
    }
}