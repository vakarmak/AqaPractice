using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class ShoppingCardTest : UiTestFixture
{
    private SolarShopPage _solarShopPage;
    
    [SetUp]
    public void SetupSolarTechnologyShopPage()
    {
        _solarShopPage = new SolarShopPage(Page);
    }

    [Test]
    public async Task AddInverterProductToShoppingCard()
    {
        // Arrange
        await _solarShopPage.GoToSolarTechnologyShopPage();
        await _solarShopPage.GoToInvertersPage();
        var invertersPage = new InvertersPage(Page);
        var basketPage = new BasketPage(Page);
        
        
        // Act
        await invertersPage.VerifyInvertersPageTitle();
        var expectedProductName = await invertersPage.AddProductToBasket();
        await basketPage.VerifyAddedProductToBasket(expectedProductName);
        await basketPage.VerifyBasketPageTitle();
        await basketPage.DeleteProductFromBasket();
        
        // Assert
        Assert.That(Page.Url, Is.EqualTo("https://solartechnology.com.ua/shop"));
    }
}