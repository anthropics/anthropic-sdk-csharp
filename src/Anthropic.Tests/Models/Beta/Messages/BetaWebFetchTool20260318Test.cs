using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchTool20260318Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_20260318");
        List<ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>> expectedAllowedCallers =
        [
            BetaWebFetchTool20260318AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
        bool expectedDeferLoading = true;
        long expectedMaxContentTokens = 1;
        long expectedMaxUses = 1;
        ApiEnum<string, ResponseInclusion> expectedResponseInclusion = ResponseInclusion.Full;
        bool expectedStrict = true;
        bool expectedUseCache = true;

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
        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedMaxContentTokens, model.MaxContentTokens);
        Assert.Equal(expectedMaxUses, model.MaxUses);
        Assert.Equal(expectedResponseInclusion, model.ResponseInclusion);
        Assert.Equal(expectedStrict, model.Strict);
        Assert.Equal(expectedUseCache, model.UseCache);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20260318>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20260318>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("web_fetch");
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_20260318");
        List<ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>> expectedAllowedCallers =
        [
            BetaWebFetchTool20260318AllowedCaller.Direct,
        ];
        List<string> expectedAllowedDomains = ["string"];
        List<string> expectedBlockedDomains = ["string"];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaCitationsConfigParam expectedCitations = new() { Enabled = true };
        bool expectedDeferLoading = true;
        long expectedMaxContentTokens = 1;
        long expectedMaxUses = 1;
        ApiEnum<string, ResponseInclusion> expectedResponseInclusion = ResponseInclusion.Full;
        bool expectedStrict = true;
        bool expectedUseCache = true;

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
        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedMaxContentTokens, deserialized.MaxContentTokens);
        Assert.Equal(expectedMaxUses, deserialized.MaxUses);
        Assert.Equal(expectedResponseInclusion, deserialized.ResponseInclusion);
        Assert.Equal(expectedStrict, deserialized.Strict);
        Assert.Equal(expectedUseCache, deserialized.UseCache);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.ResponseInclusion);
        Assert.False(model.RawData.ContainsKey("response_inclusion"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
        Assert.Null(model.UseCache);
        Assert.False(model.RawData.ContainsKey("use_cache"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            ResponseInclusion = null,
            Strict = null,
            UseCache = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.ResponseInclusion);
        Assert.False(model.RawData.ContainsKey("response_inclusion"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
        Assert.Null(model.UseCache);
        Assert.False(model.RawData.ContainsKey("use_cache"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            MaxContentTokens = 1,
            MaxUses = 1,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            ResponseInclusion = null,
            Strict = null,
            UseCache = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        Assert.Null(model.AllowedDomains);
        Assert.False(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.False(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.False(model.RawData.ContainsKey("citations"));
        Assert.Null(model.MaxContentTokens);
        Assert.False(model.RawData.ContainsKey("max_content_tokens"));
        Assert.Null(model.MaxUses);
        Assert.False(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            Citations = null,
            MaxContentTokens = null,
            MaxUses = null,
        };

        Assert.Null(model.AllowedDomains);
        Assert.True(model.RawData.ContainsKey("allowed_domains"));
        Assert.Null(model.BlockedDomains);
        Assert.True(model.RawData.ContainsKey("blocked_domains"));
        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Citations);
        Assert.True(model.RawData.ContainsKey("citations"));
        Assert.Null(model.MaxContentTokens);
        Assert.True(model.RawData.ContainsKey("max_content_tokens"));
        Assert.Null(model.MaxUses);
        Assert.True(model.RawData.ContainsKey("max_uses"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            DeferLoading = true,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,

            AllowedDomains = null,
            BlockedDomains = null,
            CacheControl = null,
            Citations = null,
            MaxContentTokens = null,
            MaxUses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchTool20260318
        {
            AllowedCallers = [BetaWebFetchTool20260318AllowedCaller.Direct],
            AllowedDomains = ["string"],
            BlockedDomains = ["string"],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            DeferLoading = true,
            MaxContentTokens = 1,
            MaxUses = 1,
            ResponseInclusion = ResponseInclusion.Full,
            Strict = true,
            UseCache = true,
        };

        BetaWebFetchTool20260318 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebFetchTool20260318AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.Direct)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20260521)]
    public void Validation_Works(BetaWebFetchTool20260318AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchTool20260318AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.Direct)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20250825)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20260120)]
    [InlineData(BetaWebFetchTool20260318AllowedCaller.CodeExecution20260521)]
    public void SerializationRoundtrip_Works(BetaWebFetchTool20260318AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWebFetchTool20260318AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWebFetchTool20260318AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResponseInclusionTest : TestBase
{
    [Theory]
    [InlineData(ResponseInclusion.Full)]
    [InlineData(ResponseInclusion.Excluded)]
    public void Validation_Works(ResponseInclusion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseInclusion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseInclusion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResponseInclusion.Full)]
    [InlineData(ResponseInclusion.Excluded)]
    public void SerializationRoundtrip_Works(ResponseInclusion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseInclusion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseInclusion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseInclusion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseInclusion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
