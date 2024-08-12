using Microsoft.Playwright;
using PlaywrightSolar.PageObjects;

namespace PlaywrightSolar.PageObjects;

public class SolarPanelsPage(IPage page)
{
    // Locators
    private ILocator PageTitle => page.Locator("//h1");
    
    private ILocator ProductFilterButton => page.GetByText("Фільтр товарів");

    private ILocator AbiSolarFilter => page.GetByText("Abi-Solar", new PageGetByTextOptions { Exact = true });
    private ILocator CAndTSolarFilter => page.GetByText("C&T Solar");
    private ILocator JaSolarFilter => page.GetByText("JA Solar");
    private ILocator JinkoSolarFilter => page.GetByText("Jinko Solar");
    private ILocator SolaFilter => page.GetByText("SOLA", new PageGetByTextOptions { Exact = true });
    private ILocator UliсaFilter => page.GetByText("Ulica Solar");
    private ILocator YingliFilter => page.GetByText("Yingli Solar");

    private ILocator MonoCrystalPanelTypeFilter =>
        page.GetByText("Монокристал", new PageGetByTextOptions { Exact = true });

    private ILocator PolyCrystalPanelTypeFilter =>
        page.GetByText("Полікристал", new PageGetByTextOptions { Exact = true });

    // Methods
    
    public async Task VerifySolarPanelsPage()
    {
        await Assertions.Expect(PageTitle).ToBeVisibleAsync();
    }
    
    public async Task OpenProductFilter()
    {
        await ProductFilterButton.ClickAsync();
    }

    public async Task FilterByManufacturer(string manufacturer)
    {
        var filterLocators = new Dictionary<string, ILocator>
        {
            { "Abi-Solar", AbiSolarFilter },
            { "C&T Solar", CAndTSolarFilter },
            { "JA Solar", JaSolarFilter },
            { "Jinko Solar", JinkoSolarFilter },
            { "SOLA", SolaFilter },
            { "Ulica Solar", UliсaFilter },
            { "Yingli Solar", YingliFilter }
        };

        if (filterLocators.TryGetValue(manufacturer, out var filterLocator))
        {
            var elementsBeforeFilter = await page.QuerySelectorAllAsync(".col.s12.m6.l4.xl3.prod-holder");
            var textsBeforeFilter =
                await Task.WhenAll(elementsBeforeFilter.Select(async element => await element.InnerTextAsync()));

            await filterLocator.ClickAsync();
            await Assertions.Expect(filterLocator).ToBeCheckedAsync();

            await page.WaitForTimeoutAsync(2000);

            var elementsAfterFilter = await page.QuerySelectorAllAsync(".col.s12.m6.l4.xl3.prod-holder");
            var textsAfterFilter =
                await Task.WhenAll(elementsAfterFilter.Select(async element => await element.InnerTextAsync()));

            Assert.That(textsBeforeFilter, Is.Not.EquivalentTo(textsAfterFilter), "Product filter did not work, elements are the same");
        }
    }

    public async Task<bool> VerifyManufacturerFilterResult(string manufacturer)
    {
        await Task.Delay(2000);
        var results = await page.QuerySelectorAllAsync(".col.s12.m6.l4.xl3.prod-holder");

        Assert.That(results.Any(), $"No elements found for manufacturer: {manufacturer}");

        foreach (var result in results)
        {
            var title = await result.InnerTextAsync();
            if (!title.Contains(manufacturer, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }

        return true;
    }

    public async Task FilterByPanelType(string panelType)
    {
        var filterLocators = new Dictionary<string, ILocator>
        {
            { "Монокристал", MonoCrystalPanelTypeFilter },
            { "Полікристал", PolyCrystalPanelTypeFilter }
        };

        if (filterLocators.TryGetValue(panelType, out var filterLocator))
        {
            await filterLocator.ClickAsync();
        }
    }

    public async Task<bool> VerifyPanelTypeFilterResult(string panelType)
    {
        await Task.Delay(2000);

        var parentElements = await page.QuerySelectorAllAsync(".col.s12.m6.l4.xl3.prod-holder");

        Assert.That(parentElements.Any(), $"No elements found for panel type: {panelType}");

        foreach (var parent in parentElements)
        {
            var childElements = await parent.QuerySelectorAllAsync(".card-content.left-align");

            foreach (var child in childElements)
            {
                var childText = await child.InnerTextAsync();

                if (!childText.Contains(panelType, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
        }

        return true;
    }
}