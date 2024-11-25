using Diploma.PageObjects;

namespace Diploma.UiTests;

[TestFixture]
internal class SearchProductTest : UiTestFixture
{
    private HomePage _homePage;
    private ProductsPage _productsPage;

    [SetUp]
    public void SetUpPages()
    {
        _homePage = new HomePage(Page);
        _productsPage = new ProductsPage(Page);
    }
    
    [Test]
    public async Task SearchProduct()
    {
        // Arrange
        const string productName = "Top";
        
        // Act
        await _homePage.OpenProductsPage();
        await _productsPage.SearchProduct(productName);
        var searchedProductNames = await _productsPage.GetProductNameText();
        
        // Assert
        Assert.That(searchedProductNames.Any(name => name.Contains(productName)), "Product name does not contain searched product name");
    }
}