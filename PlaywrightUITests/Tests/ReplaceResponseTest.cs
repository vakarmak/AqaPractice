using System.Text.Json.Nodes;
using Microsoft.Playwright;

namespace PlaywrightUiTests.Tests;

internal class ReplaceResponseTest : UiTestFixture
{
    [Test]
    public async Task ReplaceResponse()
    {
        await Page.RouteAsync("*/**/api/v1/fruits", async route => {
            var response = await route.FetchAsync();
            var body = await response.BodyAsync();
            var jn = JsonNode.Parse(body);
            JsonArray ja = jn.AsArray();
            ja[1]["name"] = "MY NEW NAME";

            await route.FulfillAsync(new() { Response = response, Json = ja });

        });

        await Page.GotoAsync("https://demo.playwright.dev/api-mocking");

        await Assertions.Expect(Page.GetByText("MY NEW NAME")).ToBeVisibleAsync();
    }

}