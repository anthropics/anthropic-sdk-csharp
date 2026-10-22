using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUseBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ToolUseBlockParamCaller expectedCaller = new DirectCaller();
        string expectedToolsetName = "toolset_name";

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
        Assert.Equal(expectedToolsetName, model.ToolsetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ToolUseBlockParamCaller expectedCaller = new DirectCaller();
        string expectedToolsetName = "toolset_name";

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
        Assert.Equal(expectedToolsetName, deserialized.ToolsetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
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
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.ToolsetName);
        Assert.False(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),

            CacheControl = null,
            ToolsetName = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.ToolsetName);
        Assert.True(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),

            CacheControl = null,
            ToolsetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        ToolUseBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolUseBlockParamCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        ToolUseBlockParamCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller20260120("srvtoolu_c");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller20260120("srvtoolu_c");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DirectTypeWorks()
    {
        ToolUseBlockParamCaller value = new DirectCaller();
        Assert.Equal(ToolUseBlockParamCallerType.Direct, value.Type.Value());
    }

    [Fact]
    public void ServerToolTypeWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_c");
        Assert.Equal(ToolUseBlockParamCallerType.CodeExecution20250825, value.Type.Value());
    }

    [Fact]
    public void ServerToolCaller20260120TypeWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller20260120("srvtoolu_c");
        Assert.Equal(ToolUseBlockParamCallerType.CodeExecution20260120, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ToolUseBlockParamCaller value = new(
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

        ApiEnum<string, ToolUseBlockParamCallerType> expectedType =
            ToolUseBlockParamCallerType.Direct;
        string expectedToolID = "srvtoolu_c";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedToolID, value.ToolID);

        ToolUseBlockParamCaller emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ToolID);

        ToolUseBlockParamCaller mismatchedValue = new(
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

public class ToolUseBlockParamCallerTypeTest : TestBase
{
    [Theory]
    [InlineData(ToolUseBlockParamCallerType.Direct)]
    [InlineData(ToolUseBlockParamCallerType.CodeExecution20250825)]
    [InlineData(ToolUseBlockParamCallerType.CodeExecution20260120)]
    public void Validation_Works(ToolUseBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseBlockParamCallerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockParamCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolUseBlockParamCallerType.Direct)]
    [InlineData(ToolUseBlockParamCallerType.CodeExecution20250825)]
    [InlineData(ToolUseBlockParamCallerType.CodeExecution20260120)]
    public void SerializationRoundtrip_Works(ToolUseBlockParamCallerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseBlockParamCallerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockParamCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockParamCallerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolUseBlockParamCallerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
