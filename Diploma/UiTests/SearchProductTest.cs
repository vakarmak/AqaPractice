using Diploma.PageObjects;
using Microsoft.Playwright;

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
        var homePage = new HomePage(Page);
        var productsPage = new ProductsPage(Page);
        const string productName = "Top";
        
        // Act
        await homePage.GoToHomePage();
        await productsPage.GoToProductsPage();
        await productsPage.VerifyProductsPageVisible();
        await productsPage.SearchProduct(productName);
        await productsPage.VerifySearchedProductsVisible();
        var searchedProductNames = await productsPage.GetProductName();
        
        // Assert
        Assert.That(searchedProductNames, Is.All.Contains(productName));
    }
}