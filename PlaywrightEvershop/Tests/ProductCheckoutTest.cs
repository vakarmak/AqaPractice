using Microsoft.Playwright;
using PlaywrightEverShop.Models;
using PlaywrightEverShop.PageObjects;

namespace PlaywrightEverShop.Tests;

internal class ProductCheckoutTest : UiTestFixture
{
    private EverShopCatalogPage _everShopCatalogPage;
    private EverShopCartPage _everShopCartPage;

    [SetUp]
    public new void Setup()
    {
        _everShopCatalogPage = new EverShopCatalogPage(Page);
        _everShopCartPage = new EverShopCartPage(Page);
    }

    [Test]
    public async Task ProductCheckout()
    {
        // Arrange
        await Page.APIRequest.PostAsync("https://demo.evershop.io/customer/login", new APIRequestContextOptions
        {
            DataObject = new UserModel
            {
                Email = "lichar@ukr.net",
                Password = "Qwerty12345*"
            }
        });

        await _everShopCatalogPage.GoToMenPage();
        const int productIndex = 0;
        
        // Act
        await _everShopCatalogPage.SelectProduct(productIndex);
        var productNameFromPage = await _everShopCatalogPage.GetProductName();
        await _everShopCatalogPage.SelectSizeOption("S");
        await _everShopCatalogPage.SelectColorOption("Black");
        await _everShopCatalogPage.AddProductToCart();
        await _everShopCartPage.GoToCartPage();
        var productNameFromCart = await _everShopCartPage.GetProductName();
        await _everShopCartPage.MakeCheckout();
        
        // Assert
        Assert.That(productNameFromPage, Is.EqualTo(productNameFromCart));
    }
}