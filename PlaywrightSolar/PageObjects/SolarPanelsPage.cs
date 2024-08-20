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
        { "Abi-Solar", page.GetByText("Abi-Solar", new PageGetByTextOptions { Exact = true }) },
        { "C&T Solar", page.GetByText("C&T Solar") },
        { "JA Solar", page.GetByText("JA Solar") },
        { "Jinko Solar", page.GetByText("Jinko Solar") },
        { "SOLA", page.GetByText("SOLA", new PageGetByTextOptions { Exact = true }) },
        { "Ulica Solar", page.GetByText("Ulica Solar") },
        { "Yingli Solar", page.GetByText("Yingli Solar") }
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
        Assert.That(page.Url, Is.EqualTo(SolarPanelsPageUrl), "Failed to navigate to Solar Panels page");
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
    
    public async Task<List<string>> GetInitialProductsName()
    {
        await page.WaitForSelectorAsync(".prod-holder");
        var results = await page.QuerySelectorAllAsync(".prod-holder");
        var resultText = await Task.WhenAll(results.Select(async result => await result.InnerTextAsync()));
        return resultText.ToList();
    }
    
    public async Task<List<string>> GetProductsNameByManufacturer(string manufacturer)
    {
        var manufacturerLocator = _filterLocators[manufacturer];
        await manufacturerLocator.ClickAsync();
        
        await Task.Delay(2000); // Other waiters are not working, everything that is related to the selector does not fit because selector always available, and stays the same
        
        var results = await page.QuerySelectorAllAsync(".prod-holder");
        var resultText = await Task.WhenAll(results.Select(async result => await result.InnerTextAsync()));
        return resultText.ToList();
    }

    public async Task ProductFilterByPanelType(string panelType)
    {
        var panelTypeLocator = _panelTypeFiltersLocator[panelType];
        await panelTypeLocator.ClickAsync();
    }

    public async Task<List<string>> GetProductNameByPanelTypeFilter()
    {
        await Task.Delay(2000); // same issue as with GetProductsNameByManufacturer
        
        var results = await page.QuerySelectorAllAsync(".prod-holder");
        var resultText = await Task.WhenAll(results.Select(async result => await result.InnerTextAsync()));
        
        return resultText.ToList();
    }
}