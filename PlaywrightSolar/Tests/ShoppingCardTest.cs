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
        var expectedProductName = await invertersPage.AddProductToBasket();
        
        // Act
        await invertersPage.VerifyInvertersPageTitle();
        await invertersPage.AddProductToBasket();
        await basketPage.VerifyBasketPageTitle();
        await basketPage.VerifyAddedProductToBasket(expectedProductName);
        
        // Assert
       
    }
}