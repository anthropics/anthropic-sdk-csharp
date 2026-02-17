using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolRegex20251119Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        JsonElement expectedName = JsonSerializer.SerializeToElement("tool_search_tool_regex");
        ApiEnum<string, ToolSearchToolRegex20251119Type> expectedType =
            ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119;
        List<ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>> expectedAllowedCallers =
        [
            ToolSearchToolRegex20251119AllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        bool expectedStrict = true;

        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.Equal(expectedType, model.Type);
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolRegex20251119>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolRegex20251119>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("tool_search_tool_regex");
        ApiEnum<string, ToolSearchToolRegex20251119Type> expectedType =
            ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119;
        List<ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>> expectedAllowedCallers =
        [
            ToolSearchToolRegex20251119AllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
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
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            DeferLoading = true,
            Strict = true,

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolSearchToolRegex20251119
        {
            Type = ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119,
            AllowedCallers = [ToolSearchToolRegex20251119AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Strict = true,
        };

        ToolSearchToolRegex20251119 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolSearchToolRegex20251119TypeTest : TestBase
{
    [Theory]
    [InlineData(ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119)]
    [InlineData(ToolSearchToolRegex20251119Type.ToolSearchToolRegex)]
    public void Validation_Works(ToolSearchToolRegex20251119Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolRegex20251119Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolSearchToolRegex20251119Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolSearchToolRegex20251119Type.ToolSearchToolRegex20251119)]
    [InlineData(ToolSearchToolRegex20251119Type.ToolSearchToolRegex)]
    public void SerializationRoundtrip_Works(ToolSearchToolRegex20251119Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolRegex20251119Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolSearchToolRegex20251119Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolSearchToolRegex20251119AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(ToolSearchToolRegex20251119AllowedCaller.Direct)]
    [InlineData(ToolSearchToolRegex20251119AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(ToolSearchToolRegex20251119AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolSearchToolRegex20251119AllowedCaller.Direct)]
    [InlineData(ToolSearchToolRegex20251119AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(ToolSearchToolRegex20251119AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolSearchToolRegex20251119AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
