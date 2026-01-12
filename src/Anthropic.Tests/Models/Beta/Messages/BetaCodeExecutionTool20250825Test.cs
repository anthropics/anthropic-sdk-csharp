using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCodeExecutionTool20250825Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_20250825\""
        );
        List<ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>> expectedAllowedCallers =
        [
            BetaCodeExecutionTool20250825AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedCallers);
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
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(element);
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.Deserialize<JsonElement>("\"code_execution\"");
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"code_execution_20250825\""
        );
        List<ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>> expectedAllowedCallers =
        [
            BetaCodeExecutionTool20250825AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCodeExecutionTool20250825 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

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
        var model = new BetaCodeExecutionTool20250825 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

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
        var model = new BetaCodeExecutionTool20250825
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

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
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
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
        var model = new BetaCodeExecutionTool20250825
        {
            AllowedCallers = [BetaCodeExecutionTool20250825AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaCodeExecutionTool20250825AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaCodeExecutionTool20250825AllowedCaller.Direct)]
    [InlineData(BetaCodeExecutionTool20250825AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(BetaCodeExecutionTool20250825AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaCodeExecutionTool20250825AllowedCaller.Direct)]
    [InlineData(BetaCodeExecutionTool20250825AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(BetaCodeExecutionTool20250825AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaCodeExecutionTool20250825AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
