using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class ProductDetailsTest : UiTestFixture
{
    private InvertersPage _invertersPage;
    
    [SetUp]
    public void SetupInvertersPage()
    {
        _invertersPage = new InvertersPage(Page);
    }
    
    [Test]
    public async Task CompareProductNames()
    {
        // Arrange
        await _invertersPage.GoToInvertersPage();
        const int productIndex = 5;
        
        // Act
        var productNameFromCard = await _invertersPage.GetProductName(productIndex);
        await _invertersPage.GoToProductDetails(productIndex);
        var productNameFromProductDetails = await _invertersPage.GetProductNameFromProductDetails();

        // Assert
        Assert.That(productNameFromProductDetails, Is.EqualTo(productNameFromCard), "Product names are not the same");
    }
}