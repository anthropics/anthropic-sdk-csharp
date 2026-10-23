using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaServerToolUseBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string expectedID = "srvtoolu_c";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, BetaServerToolUseBlockParamName> expectedName =
            BetaServerToolUseBlockParamName.Advisor;
        JsonElement expectedType = JsonSerializer.SerializeToElement("server_tool_use");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaServerToolUseBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "srvtoolu_c";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, BetaServerToolUseBlockParamName> expectedName =
            BetaServerToolUseBlockParamName.Advisor;
        JsonElement expectedType = JsonSerializer.SerializeToElement("server_tool_use");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaServerToolUseBlockParamCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInput.Count, deserialized.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(deserialized.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Input[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        } with
        {
            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            Caller = new BetaDirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            Caller = new BetaDirectCaller(),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            Caller = new BetaDirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServerToolUseBlockParam
        {
            ID = "srvtoolu_c",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = BetaServerToolUseBlockParamName.Advisor,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new BetaDirectCaller(),
        };

        BetaServerToolUseBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaServerToolUseBlockParamNameTest : TestBase
{
    [Theory]
    [InlineData(BetaServerToolUseBlockParamName.Advisor)]
    [InlineData(BetaServerToolUseBlockParamName.WebSearch)]
    [InlineData(BetaServerToolUseBlockParamName.WebFetch)]
    [InlineData(BetaServerToolUseBlockParamName.CodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.BashCodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.TextEditorCodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.ToolSearchToolRegex)]
    [InlineData(BetaServerToolUseBlockParamName.ToolSearchToolBm25)]
    public void Validation_Works(BetaServerToolUseBlockParamName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServerToolUseBlockParamName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaServerToolUseBlockParamName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaServerToolUseBlockParamName.Advisor)]
    [InlineData(BetaServerToolUseBlockParamName.WebSearch)]
    [InlineData(BetaServerToolUseBlockParamName.WebFetch)]
    [InlineData(BetaServerToolUseBlockParamName.CodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.BashCodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.TextEditorCodeExecution)]
    [InlineData(BetaServerToolUseBlockParamName.ToolSearchToolRegex)]
    [InlineData(BetaServerToolUseBlockParamName.ToolSearchToolBm25)]
    public void SerializationRoundtrip_Works(BetaServerToolUseBlockParamName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServerToolUseBlockParamName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaServerToolUseBlockParamName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaServerToolUseBlockParamCallerTest : TestBase
{
    [Fact]
    public void BetaDirectValidationWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaDirectCaller();
        value.Validate();
    }

    [Fact]
    public void BetaServerToolValidationWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void BetaDirectSerializationRoundtripWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaDirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolSerializationRoundtripWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolCaller20260120SerializationRoundtripWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaDirectTypeWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaDirectCaller();
        Assert.Equal(BetaServerToolUseBlockParamCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void BetaServerToolTypeWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller("srvtoolu_c");
        Assert.Equal(
            BetaServerToolUseBlockParamCallerType.CodeExecution20250825,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaServerToolCaller20260120TypeWorks()
    {
        BetaServerToolUseBlockParamCaller value = new BetaServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(
            BetaServerToolUseBlockParamCallerType.CodeExecution20260120,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaServerToolUseBlockParamCaller value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "direct",
                  "tool_id": "srvtoolu_c"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaServerToolUseBlockParamCallerType> expectedType =
            BetaServerToolUseBlockParamCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        BetaServerToolUseBlockParamCaller emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        BetaServerToolUseBlockParamCaller mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "tool_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ToolID);
    }
}

public class BetaServerToolUseBlockParamCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaServerToolUseBlockParamCallerType.Direct)]
    [InlineData(BetaServerToolUseBlockParamCallerType.CodeExecution20250825)]
    [InlineData(BetaServerToolUseBlockParamCallerType.CodeExecution20260120)]
    public void Validation_Works(BetaServerToolUseBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServerToolUseBlockParamCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaServerToolUseBlockParamCallerType.Direct)]
    [InlineData(BetaServerToolUseBlockParamCallerType.CodeExecution20250825)]
    [InlineData(BetaServerToolUseBlockParamCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(BetaServerToolUseBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServerToolUseBlockParamCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamCallerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServerToolUseBlockParamCallerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
