using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };

        InputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        List<ApiEnum<string, ToolAllowedCaller>> expectedAllowedCallers =
        [
            ToolAllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        string expectedDescription = "Get the current weather in a given location";
        bool expectedEagerInputStreaming = true;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedInputSchema, model.InputSchema);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedDeferLoading, model.DeferLoading);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEagerInputStreaming, model.EagerInputStreaming);
        Assert.NotNull(model.InputExamples);
        Assert.Equal(expectedInputExamples.Count, model.InputExamples.Count);
        for (int i = 0; i < expectedInputExamples.Count; i++)
        {
            Assert.Equal(expectedInputExamples[i].Count, model.InputExamples[i].Count);
            foreach (var item in expectedInputExamples[i])
            {
                Assert.True(model.InputExamples[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.InputExamples[i][item.Key]));
            }
        }
        Assert.Equal(expectedStrict, model.Strict);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        InputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        List<ApiEnum<string, ToolAllowedCaller>> expectedAllowedCallers =
        [
            ToolAllowedCaller.Direct,
        ];
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        string expectedDescription = "Get the current weather in a given location";
        bool expectedEagerInputStreaming = true;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;
        ApiEnum<string, Type> expectedType = Type.Custom;

        Assert.Equal(expectedInputSchema, deserialized.InputSchema);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedDeferLoading, deserialized.DeferLoading);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEagerInputStreaming, deserialized.EagerInputStreaming);
        Assert.NotNull(deserialized.InputExamples);
        Assert.Equal(expectedInputExamples.Count, deserialized.InputExamples.Count);
        for (int i = 0; i < expectedInputExamples.Count; i++)
        {
            Assert.Equal(expectedInputExamples[i].Count, deserialized.InputExamples[i].Count);
            foreach (var item in expectedInputExamples[i])
            {
                Assert.True(deserialized.InputExamples[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.InputExamples[i][item.Key]));
            }
        }
        Assert.Equal(expectedStrict, deserialized.Strict);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            EagerInputStreaming = true,
            Type = Type.Custom,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.InputExamples);
        Assert.False(model.RawData.ContainsKey("input_examples"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            EagerInputStreaming = true,
            Type = Type.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            EagerInputStreaming = true,
            Type = Type.Custom,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Description = null,
            InputExamples = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.InputExamples);
        Assert.False(model.RawData.ContainsKey("input_examples"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            EagerInputStreaming = true,
            Type = Type.Custom,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            Description = null,
            InputExamples = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.EagerInputStreaming);
        Assert.False(model.RawData.ContainsKey("eager_input_streaming"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,

            CacheControl = null,
            EagerInputStreaming = null,
            Type = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.EagerInputStreaming);
        Assert.True(model.RawData.ContainsKey("eager_input_streaming"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,

            CacheControl = null,
            EagerInputStreaming = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tool
        {
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "location", JsonSerializer.SerializeToElement("bar") },
                    { "unit", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["location"],
            },
            Name = "name",
            AllowedCallers = [ToolAllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            Description = "Get the current weather in a given location",
            EagerInputStreaming = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
            Type = Type.Custom,
        };

        Tool copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("object");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Properties);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.NotNull(model.Required);
        Assert.Equal(expectedRequired.Count, model.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], model.Required[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputSchema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("object");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.NotNull(deserialized.Required);
        Assert.Equal(expectedRequired.Count, deserialized.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], deserialized.Required[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InputSchema { };

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InputSchema { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InputSchema { Properties = null, Required = null };

        Assert.Null(model.Properties);
        Assert.True(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.True(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InputSchema { Properties = null, Required = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        InputSchema copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolAllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(ToolAllowedCaller.Direct)]
    [InlineData(ToolAllowedCaller.CodeExecution20250825)]
    public void Validation_Works(ToolAllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolAllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolAllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolAllowedCaller.Direct)]
    [InlineData(ToolAllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(ToolAllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolAllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolAllowedCaller>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolAllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolAllowedCaller>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Custom)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Custom)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
