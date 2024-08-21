using Microsoft.Playwright;

namespace PlaywrightSolar.PageObjects;

public class SolarPanelsPage(IPage page)
{
    private const string SolarPanelsPageUrl = "https://solartechnology.com.ua/shop/solar-panels";
    
    // Locators
    private ILocator PageTitle => page.Locator("//h1");

    private ILocator ProductFilterButton => page.GetByText("Фільтр товарів");

    private readonly Dictionary<string, ILocator> _filterLocators = new()
    {
        { "ABi-Solar", page.GetByText("Abi-Solar", new PageGetByTextOptions { Exact = true }) },
        { "C&T", page.GetByText("C&T Solar", new PageGetByTextOptions { Exact = true }) },
        { "JA Solar", page.GetByText("JA Solar", new PageGetByTextOptions { Exact = true }) },
        { "Jinko Solar", page.GetByText("Jinko Solar", new PageGetByTextOptions { Exact = true }) },
        { "SOLA", page.GetByText("SOLA", new PageGetByTextOptions { Exact = true }) },
        { "Ulica Solar", page.GetByText("Ulica Solar", new PageGetByTextOptions { Exact = true }) },
        { "Yingli Solar", page.GetByText("Yingli Solar", new PageGetByTextOptions { Exact = true }) }
    };
    
    private readonly Dictionary<string, ILocator> _panelTypeFiltersLocator = new()
    {
        { "Монокристал", page.GetByText("Монокристал", new PageGetByTextOptions { Exact = true }) },
        { "Полікристал", page.GetByText("Полікристал", new PageGetByTextOptions { Exact = true }) }
    };

    // Methods
    public async Task GoToSolarPanelsPage()
    {
        await page.GotoAsync(SolarPanelsPageUrl);
    }

    public async Task SolarPanelsPageOpened()
    {
        await Assertions.Expect(PageTitle).ToBeVisibleAsync();
    }

    public async Task OpenProductFilter()
    {
        await ProductFilterButton.ClickAsync();
        await Task.Delay(1000);
    }
    
    public async Task<List<string>> GetProductsName()
    {
        await page.WaitForSelectorAsync(".prod-holder");
        
        var productsCardContent = await page.QuerySelectorAllAsync(".card-content");
        var cardContentText = await Task.WhenAll(productsCardContent.Select(async result => await result.InnerTextAsync()));
        
        return cardContentText.ToList();
    }
    
    public async Task FilterProductsByManufacturer(string manufacturer)
    {
        var manufacturerLocator = _filterLocators[manufacturer];
        await manufacturerLocator.CheckAsync();
        
        await Task.Delay(2000); // Other waiters are not working, everything that is related to the selector does not fit because selector always available, and stays the same
    }

    public async Task FilterProductsByPanelType(string panelType)
    {
        var panelTypeLocator = _panelTypeFiltersLocator[panelType];
        await panelTypeLocator.CheckAsync();
        
        await Task.Delay(2000);
    }
}