using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchTool20260318Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_20260318");
        List<ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>> expectedAllowedCallers =
        [
            BetaWebSearchTool20260318AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion> expectedResponseInclusion =
            BetaWebSearchTool20260318ResponseInclusion.Full;
        bool expectedStrict = true;
        BetaUserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.NotNull(model.AllowedDomains);
        Assert.Equal(expectedAllowedDomains.Count, model.AllowedDomains.Count);
        for (int i = 0; i < expectedAllowedDomains.Count; i++)
        {
            Assert.Equal(expectedAllowedDomains[i], model.AllowedDomains[i]);
        }
        Assert.NotNull(model.BlockedDomains);
        Assert.Equal(expectedBlockedDomains.Count, model.BlockedDomains.Count);
        for (int i = 0; i < expectedBlockedDomains.Count; i++)
        {
            Assert.Equal(expectedBlockedDomains[i], model.BlockedDomains[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedResponseInclusion, model.ResponseInclusion);
        Assert.Equal(expectedStrict, model.Strict);
        Assert.Equal(expectedUserLocation, model.UserLocation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20260318>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20260318>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_search");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_20260318");
        List<ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>> expectedAllowedCallers =
        [
            BetaWebSearchTool20260318AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion> expectedResponseInclusion =
            BetaWebSearchTool20260318ResponseInclusion.Full;
        bool expectedStrict = true;
        BetaUserLocation expectedUserLocation = new()
        {
            City = "New York",
            Country = "US",
            Region = "California",
            Timezone = "America/New_York",
        };

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
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
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedResponseInclusion, deserialized.ResponseInclusion);
        Assert.Equal(expectedStrict, deserialized.Strict);
        Assert.Equal(expectedUserLocation, deserialized.UserLocation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.ResponseInclusion);
        Assert.False(model.RawData.ContainsKey("response_inclusion"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            ResponseInclusion = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.ResponseInclusion);
        Assert.False(model.RawData.ContainsKey("response_inclusion"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            ResponseInclusion = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
        };

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
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,

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
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            MaxUses = null,
            UserLocation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebSearchTool20260318
        {
            AllowedCallers = [BetaWebSearchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            ResponseInclusion = BetaWebSearchTool20260318ResponseInclusion.Full,
            Strict = true,
            UserLocation = new()
            {
                City = "New York",
                Country = "US",
                Region = "California",
                Timezone = "America/New_York",
            },
        };

        BetaWebSearchTool20260318 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebSearchTool20260318AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.Direct)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20260521)]
    public void Validation_Works(BetaWebSearchTool20260318AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchTool20260318AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.Direct)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaWebSearchTool20260318AllowedCaller.CodeExecution20260521)]
    public void SerializationRoundtrip_Works(BetaWebSearchTool20260318AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchTool20260318AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaWebSearchTool20260318ResponseInclusionTest : TestBase
{
    [Theory]
    [InlineData(BetaWebSearchTool20260318ResponseInclusion.Full)]
    [InlineData(BetaWebSearchTool20260318ResponseInclusion.Excluded)]
    public void Validation_Works(BetaWebSearchTool20260318ResponseInclusion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebSearchTool20260318ResponseInclusion.Full)]
    [InlineData(BetaWebSearchTool20260318ResponseInclusion.Excluded)]
    public void SerializationRoundtrip_Works(BetaWebSearchTool20260318ResponseInclusion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebSearchTool20260318ResponseInclusion>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
