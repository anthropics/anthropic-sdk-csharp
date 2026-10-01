using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaResponseToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
            Type = BetaResponseToolType.Custom,
        };

        BetaResponseToolInputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        List<ApiEnum<string, BetaResponseToolAllowedCaller>> expectedAllowedCallers =
        [
            BetaResponseToolAllowedCaller.Direct,
        ];
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
        ApiEnum<string, BetaResponseToolType> expectedType = BetaResponseToolType.Custom;

        Assert.Equal(expectedInputSchema, model.InputSchema);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, model.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], model.AllowedCallers[i]);
        }
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
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
            Type = BetaResponseToolType.Custom,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
            Type = BetaResponseToolType.Custom,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaResponseToolInputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };
        string expectedName = "name";
        List<ApiEnum<string, BetaResponseToolAllowedCaller>> expectedAllowedCallers =
        [
            BetaResponseToolAllowedCaller.Direct,
        ];
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
        ApiEnum<string, BetaResponseToolType> expectedType = BetaResponseToolType.Custom;

        Assert.Equal(expectedInputSchema, deserialized.InputSchema);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.AllowedCallers);
        Assert.Equal(expectedAllowedCallers.Count, deserialized.AllowedCallers.Count);
        for (int i = 0; i < expectedAllowedCallers.Count; i++)
        {
            Assert.Equal(expectedAllowedCallers[i], deserialized.AllowedCallers[i]);
        }
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
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
            Type = BetaResponseToolType.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaResponseTool
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
            EagerInputStreaming = true,
            Type = BetaResponseToolType.Custom,
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
        var model = new BetaResponseTool
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
            EagerInputStreaming = true,
            Type = BetaResponseToolType.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaResponseTool
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
            EagerInputStreaming = true,
            Type = BetaResponseToolType.Custom,

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
        var model = new BetaResponseTool
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
            EagerInputStreaming = true,
            Type = BetaResponseToolType.Custom,

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
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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

        Assert.Null(model.EagerInputStreaming);
        Assert.False(model.RawData.ContainsKey("eager_input_streaming"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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

            EagerInputStreaming = null,
            Type = null,
        };

        Assert.Null(model.EagerInputStreaming);
        Assert.True(model.RawData.ContainsKey("eager_input_streaming"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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

            EagerInputStreaming = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaResponseTool
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
            AllowedCallers = [BetaResponseToolAllowedCaller.Direct],
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
            Type = BetaResponseToolType.Custom,
        };

        BetaResponseTool copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaResponseToolAllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaResponseToolAllowedCaller.Direct)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20250825)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20260120)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20260521)]
    public void Validation_Works(BetaResponseToolAllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolAllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolAllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaResponseToolAllowedCaller.Direct)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20250825)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20260120)]
    [InlineData(BetaResponseToolAllowedCaller.CodeExecution20260521)]
    public void SerializationRoundtrip_Works(BetaResponseToolAllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolAllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolAllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolAllowedCaller>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaResponseToolAllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaResponseToolTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaResponseToolType.Custom)]
    public void Validation_Works(BetaResponseToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaResponseToolType.Custom)]
    public void SerializationRoundtrip_Works(BetaResponseToolType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaResponseToolType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaResponseToolType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
