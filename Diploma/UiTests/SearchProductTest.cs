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
        await _productsPage.GoToProductsPage();
        await _productsPage.VerifyProductsPageVisible();
        await _productsPage.SearchProduct(productName);
        await _productsPage.VerifySearchedProductsVisible();
        var searchedProductNames = await _productsPage.GetProductNameText();
        
        // Assert
        Assert.That(searchedProductNames.Any(name => name.Contains(productName)), "Product name does not contain searched product name");
    }
}