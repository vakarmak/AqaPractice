using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class CatalogFiltersTest : UiTestFixture
{
    private SolarShopPage _solarShopPage;
    private SolarPanelsPage _solarPanelsPage;
    
    [SetUp]
    public void SetupSolarTechnologyShopPage()
    {
        _solarShopPage = new SolarShopPage(Page);
        _solarPanelsPage = new SolarPanelsPage(Page);
    }
    
    [Test]
    public async Task VerifyCatalogFilteringByManufacturer()
    {
        // Arrange
        await _solarPanelsPage.GoToSolarPanelsPage();
        await _solarPanelsPage.SolarPanelsPageOpened();
        await _solarPanelsPage.OpenProductFilter();
        
        // Act
        // Possible values: "Abi-Solar", "C&T Solar", "JA Solar", "Jinko Solar", "SOLA", "Ulica Solar", "Yingli Solar"
        var productsNameBeforeFiltering = await _solarPanelsPage.GetProductsName();
        await _solarPanelsPage.FilterProductsByManufacturer("SOLA");
        var productsNameAfterFiltering = await _solarPanelsPage.GetProductsName();
        
        // Assert
        Assert.That(productsNameBeforeFiltering, Is.Not.EqualTo(productsNameAfterFiltering), "Products are the same");
    }
    
    [Test]
    public async Task VerifyCatalogFilteringByPanelType()
    {
        // Arrange
        await _solarPanelsPage.GoToSolarPanelsPage();
        await _solarPanelsPage.SolarPanelsPageOpened();
        await _solarPanelsPage.OpenProductFilter();
        
        // Act
        // Possible values: "Монокристал", "Полікристал"
        await _solarPanelsPage.FilterProductsByPanelType("Монокристал");
        var productsNameByPanelType = await _solarPanelsPage.GetProductsName();
        
        // Assert
        Assert.That(productsNameByPanelType, Is.Not.Empty, "Products are not found");
        foreach (var item in productsNameByPanelType)
        {
            Assert.That(item, Does.Contain("Монокристал"), "Product does not contain selected panel type");
        }
    }
}