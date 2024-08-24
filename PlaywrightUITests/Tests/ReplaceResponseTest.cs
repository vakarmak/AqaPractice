using System.Text.Json.Nodes;
using Microsoft.Playwright;

namespace PlaywrightUiTests.Tests;

internal class ReplaceResponseTest : UiTestFixture
{
    [Test]
    public async Task ReplaceResponse()
    {
        await Page.RouteAsync("*/**/api/v1/fruits", async route =>
        {
            var response = await route.FetchAsync();
            var body = await response.BodyAsync();
            var jn = JsonNode.Parse(body);
            var ja = jn!.AsArray();
            
            var foundLastFruit = false;
            
            for (var i = 0; i < ja.Count; i++)
            {
                var item = ja[i];

                if (item!["name"]!.ToString() != "Orange") continue;
                item["name"] = "LAST FRUIT";
                foundLastFruit = true;
                ja = new JsonArray(ja.Take(i + 1).Select(x => JsonNode.Parse(x!.ToString())).ToArray());
                break;
            }
            
            if (foundLastFruit)
            {
                await route.FulfillAsync(new RouteFulfillOptions
                {
                    ContentType = "application/json",
                    Status = 200,
                    Body = ja.ToString()
                });
            }
            
            await route.ContinueAsync();
        });
        
        await Page.GotoAsync("https://demo.playwright.dev/api-mocking");

        await Assertions.Expect(Page.GetByText("LAST FRUIT")).ToBeVisibleAsync();
    }
}