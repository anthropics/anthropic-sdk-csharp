using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolComputerUse20241022Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        long expectedDisplayHeightPx = 1;
        long expectedDisplayWidthPx = 1;
        JsonElement expectedName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_20241022");
        List<ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>> expectedAllowedCallers =
        [
            BetaToolComputerUse20241022AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedDisplayNumber = 0;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;

        Assert.Equal(expectedDisplayHeightPx, model.DisplayHeightPx);
        Assert.Equal(expectedDisplayWidthPx, model.DisplayWidthPx);
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
        Assert.Equal(expectedDisplayNumber, model.DisplayNumber);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDisplayHeightPx = 1;
        long expectedDisplayWidthPx = 1;
        JsonElement expectedName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_20241022");
        List<ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>> expectedAllowedCallers =
        [
            BetaToolComputerUse20241022AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        long expectedDisplayNumber = 0;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        bool expectedStrict = true;

        Assert.Equal(expectedDisplayHeightPx, deserialized.DisplayHeightPx);
        Assert.Equal(expectedDisplayWidthPx, deserialized.DisplayWidthPx);
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
        Assert.Equal(expectedDisplayNumber, deserialized.DisplayNumber);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DeferLoading = true,
            DisplayNumber = 0,
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DisplayNumber = 0,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.InputExamples);
        Assert.False(model.RawData.ContainsKey("input_examples"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DisplayNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DisplayNumber = 0,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            InputExamples = null,
            Strict = null,
        };

        Assert.Null(model.AllowedCallers);
        Assert.False(model.RawData.ContainsKey("allowed_callers"));
        Assert.Null(model.DeferLoading);
        Assert.False(model.RawData.ContainsKey("defer_loading"));
        Assert.Null(model.InputExamples);
        Assert.False(model.RawData.ContainsKey("input_examples"));
        Assert.Null(model.Strict);
        Assert.False(model.RawData.ContainsKey("strict"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            DisplayNumber = 0,

            // Null should be interpreted as omitted for these properties
            AllowedCallers = null,
            DeferLoading = null,
            InputExamples = null,
            Strict = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            DeferLoading = true,
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
        Assert.Null(model.DisplayNumber);
        Assert.False(model.RawData.ContainsKey("display_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            DeferLoading = true,
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
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,

            CacheControl = null,
            DisplayNumber = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.DisplayNumber);
        Assert.True(model.RawData.ContainsKey("display_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaToolComputerUse20241022
        {
            DisplayHeightPx = 1,
            DisplayWidthPx = 1,
            AllowedCallers = [BetaToolComputerUse20241022AllowedCaller.Direct],
            DeferLoading = true,
            InputExamples =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Strict = true,

            CacheControl = null,
            DisplayNumber = null,
        };

        model.Validate();
    }
}

public class BetaToolComputerUse20241022AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaToolComputerUse20241022AllowedCaller.Direct)]
    [InlineData(BetaToolComputerUse20241022AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(BetaToolComputerUse20241022AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolComputerUse20241022AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaToolComputerUse20241022AllowedCaller.Direct)]
    [InlineData(BetaToolComputerUse20241022AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(BetaToolComputerUse20241022AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolComputerUse20241022AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolComputerUse20241022AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
