using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class CatalogFiltersTest : UiTestFixture
{
    private SolarPanelsPage _solarPanelsPage;
    
    [SetUp]
    public void SetupSolarPanelsPage()
    {
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
        // Possible values: "ABi-Solar", "C&T", "JA Solar", "Jinko Solar", "SOLA", "Ulica Solar", "Yingli Solar"
        // var productsNameBeforeFiltering = await _solarPanelsPage.GetProductsName();
        await _solarPanelsPage.FilterProductsByManufacturer("JA Solar");
        var productsNameList = await _solarPanelsPage.GetProductsName();

        // Assert
        Assert.That(productsNameList, Is.Not.Empty, "Products list is empty");
        foreach (var item in productsNameList)
        {
            Assert.That(item, Does.Contain("JA Solar"), "Filtered products do not contain selected manufacturer");
        }

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