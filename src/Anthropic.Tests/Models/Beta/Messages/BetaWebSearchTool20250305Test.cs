using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchTool20250305Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchTool20250305
        {
            Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\""),
            Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\""),
            AllowedCallers = [AllowedCaller15.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
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
        List<ApiEnum<string, AllowedCaller15>> expectedAllowedCallers = [AllowedCaller15.Direct];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        bool expectedStrict = true;
        UserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
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
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedStrict, model.Strict);
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
