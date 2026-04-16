using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorTool20260301Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
        };

        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_7;
        JsonElement expectedName = JsonSerializer.SerializeToElement("advisor");
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_20260301");
        List<ApiEnum<string, AllowedCaller>> expectedAllowedCallers = [AllowedCaller.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCacheControlEphemeral expectedCaching = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        bool expectedStrict = true;

        Assert.Equal(expectedModel, model.Model);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaching, model.Caching);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedStrict, model.Strict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorTool20260301>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorTool20260301>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Messages::Model> expectedModel = Messages::Model.ClaudeOpus4_7;
        JsonElement expectedName = JsonSerializer.SerializeToElement("advisor");
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_20260301");
        List<ApiEnum<string, AllowedCaller>> expectedAllowedCallers = [AllowedCaller.Direct];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCacheControlEphemeral expectedCaching = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedMaxUses = 1;
        bool expectedStrict = true;

        Assert.Equal(expectedModel, deserialized.Model);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaching, deserialized.Caching);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedStrict, deserialized.Strict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
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
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,

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
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            MaxUses = 1,

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
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Caching);
        Assert.False(model.RawData.ContainsKey("caching"));
        Assert.Null(model.MaxUses);
        Assert.False(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
            Caching = null,
            MaxUses = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Caching);
        Assert.True(model.RawData.ContainsKey("caching"));
        Assert.Null(model.MaxUses);
        Assert.True(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
            Caching = null,
            MaxUses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorTool20260301
        {
            Model = Messages::Model.ClaudeOpus4_7,
            AllowedCallers = [AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caching = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            MaxUses = 1,
            Strict = true,
        };

        BetaAdvisorTool20260301 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(AllowedCaller.Direct)]
    [InlineData(AllowedCaller.CodeExecution20250825)]
    [InlineData(AllowedCaller.CodeExecution20260120)]
    public void Validation_Works(AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllowedCaller.Direct)]
    [InlineData(AllowedCaller.CodeExecution20250825)]
    [InlineData(AllowedCaller.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowedCaller>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowedCaller>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
