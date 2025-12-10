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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchTool20250305
        {
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchTool20250305>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchTool20250305
        {
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchTool20250305>(json);
        Assert.NotNull(deserialized);

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

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, deserialized.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], deserialized.AllowedDomains[i]);
        }
        Assert.NotNull(deserialized.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, deserialized.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], deserialized.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedUserLocation, deserialized.UserLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchTool20250305
        {
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebSearchTool20250305 { };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxUses);
        Assert.False(model.RawData.ContainsKey("max_uses"));
        Assert.Null(model.UserLocation);
        Assert.False(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebSearchTool20250305 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebSearchTool20250305
        {
            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            MaxUses = null,
            UserLocation = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.True(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.True(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.MaxUses);
        Assert.True(model.RawData.ContainsKey("max_uses"));
        Assert.Null(model.UserLocation);
        Assert.True(model.RawData.ContainsKey("user_location"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebSearchTool20250305
        {
            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            MaxUses = null,
            UserLocation = null,
        };

        model.Validate();
    }
}

public class UserLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserLocation
        {
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserLocation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<UserLocation>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
        string expectedCity = "New York";
        string expectedCountry = "US";
        string expectedRegion = "California";
        string expectedTimezone = "America/New_York";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedRegion, deserialized.Region);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserLocation
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UserLocation { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UserLocation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UserLocation
        {
            City = null,
            Country = null,
            Region = null,
            Timezone = null,
        };

        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.Region);
        Assert.True(model.RawData.ContainsKey("region"));
        Assert.Null(model.Timezone);
        Assert.True(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UserLocation
        {
            City = null,
            Country = null,
            Region = null,
            Timezone = null,
        };

        model.Validate();
    }
}
