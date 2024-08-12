using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.Tests;

internal class CatalogFiltersTest : UiTestFixture
{
    private SolarShopPage _solarShopPage;
    
    [SetUp]
    public void SetupSolarTechnologyShopPage()
    {
        _solarShopPage = new SolarShopPage(Page);
    }
    
    [Test]
    public async Task VerifyCatalogFilteringByManufacturer()
    {
        // Arrange
        await _solarShopPage.GoToSolarTechnologyShopPage();
        await _solarShopPage.GoToSolarPanels();
        var solarPanelsPage = new SolarPanelsPage(Page);
        await solarPanelsPage.VerifySolarPanelsPage();
        await solarPanelsPage.OpenProductFilter();
        
        // Act
        // Possible values: "Abi-Solar", "C&T Solar", "JA Solar", "Jinko Solar", "SOLA", "Ulica Solar", "Yingli Solar"
        await solarPanelsPage.FilterByManufacturer("Abi-Solar");
        var isAbiSolarFilterResultCorrect = await solarPanelsPage.VerifyManufacturerFilterResult("Abi-Solar");
        
        // Assert
        Assert.That(isAbiSolarFilterResultCorrect, Is.True, "Filtered result is not correct");
    }
    
    [Test]
    public async Task VerifyCatalogFilteringByPanelType()
    {
        // Arrange
        await _solarShopPage.GoToSolarTechnologyShopPage();
        await _solarShopPage.GoToSolarPanels();
        var solarPanelsPage = new SolarPanelsPage(Page);
        await solarPanelsPage.VerifySolarPanelsPage();
        await solarPanelsPage.OpenProductFilter();
        
        // Act
        // Possible values: "Монокристал", "Полікристал"
        await solarPanelsPage.FilterByPanelType("Полікристал");
        var isPanelTypeFilterResultCorrect = await solarPanelsPage.VerifyPanelTypeFilterResult("Полікристал");
        
        // Assert
        Assert.That(isPanelTypeFilterResultCorrect, Is.True, "Filtered result is not correct");
    }
}