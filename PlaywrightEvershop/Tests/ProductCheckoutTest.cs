using Microsoft.Playwright;
using PlaywrightEverShop.Models;
using PlaywrightEverShop.PageObjects;

namespace PlaywrightEverShop.Tests;

internal class ProductCheckoutTest : UiTestFixture
{
    private EverShopMenPage _everShopMenPage;
    private EverShopCartPage _everShopCartPage;

    [SetUp]
    public new void Setup()
    {
        _everShopMenPage = new EverShopMenPage(Page);
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

        await _everShopMenPage.GoToMenPage();
        const int productIndex = 0;
        
        // Act
        await _everShopMenPage.SelectProduct(productIndex);
        var productNameFromPage = await _everShopMenPage.GetProductName();
        await Page.WaitForTimeoutAsync(1500); // Cannot pick size without waiting
        await _everShopMenPage.SelectSizeOption();
        await Page.WaitForTimeoutAsync(1500); // Cannot pick color without waiting
        await _everShopMenPage.SelectColorOption();
        await Page.WaitForTimeoutAsync(1500); // Cannot add to cart without waiting
        await _everShopMenPage.AddProductToCart();
        await _everShopCartPage.GoToCartPage();
        var productNameFromCart = await _everShopCartPage.GetProductName();
        await _everShopCartPage.MakeCheckout();
        
        // Assert
        Assert.That(productNameFromPage, Is.EqualTo(productNameFromCart));
    }
}