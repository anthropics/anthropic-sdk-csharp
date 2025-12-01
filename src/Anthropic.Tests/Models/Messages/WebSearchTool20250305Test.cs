using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchTool20250305Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchTool20250305
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\""),
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { TTL = TTL.TTL5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_20250305\""
        );
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        long expectedMaxUses = 1;
        UserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedUserLocation, model.UserLocation);
    }
}

public class UserLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserLocation
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\""),
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedRegion = "California";
        string expectedTimezone = "America/New_York";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedRegion, model.Region);
        Assert.Equal(expectedTimezone, model.Timezone);
    }
}
