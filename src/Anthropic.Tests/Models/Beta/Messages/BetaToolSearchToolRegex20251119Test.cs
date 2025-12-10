using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolRegex20251119Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_regex\""
        );
        ApiEnum<string, BetaToolSearchToolRegex20251119Type> expectedType =
            BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119;
        List<
            ApiEnum<string, BetaToolSearchToolRegex20251119AllowedCaller>
        > expectedAllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedStrict, model.Strict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolRegex20251119>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolRegex20251119>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_regex\""
        );
        ApiEnum<string, BetaToolSearchToolRegex20251119Type> expectedType =
            BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119;
        List<
            ApiEnum<string, BetaToolSearchToolRegex20251119AllowedCaller>
        > expectedAllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedStrict, deserialized.Strict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { TTL = TTL.TTL5m },
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { TTL = TTL.TTL5m },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { TTL = TTL.TTL5m },

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaToolSearchToolRegex20251119
        {
            Type = BetaToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [BetaToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        model.Validate();
    }
}
