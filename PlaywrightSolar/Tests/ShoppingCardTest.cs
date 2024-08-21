using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class ShoppingCardTest : UiTestFixture
{
    private InvertersPage _invertersPage;
    private BasketPage _basketPage;
    private SolarShopPage _solarShopPage;
    
    [SetUp]
    public void SetupPages()
    {
        _invertersPage = new InvertersPage(Page);
        _basketPage = new BasketPage(Page);
        _solarShopPage = new SolarShopPage(Page);
    }

    [Test]
    public async Task AddInverterProductToShoppingCard()
    {
        // Arrange
        await _invertersPage.GoToInvertersPage();
        const int productIndex = 0;
        
        // Act
        await _invertersPage.SelectProduct(productIndex);
        await _basketPage.PlaceOrder();
        await _basketPage.DeleteProductFromBasket();
        
        // Assert
        await _solarShopPage.VerifyBasketIsEmpty();
    }
}