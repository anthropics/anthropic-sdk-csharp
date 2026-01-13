using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolTextEditor20241022Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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

        JsonElement expectedName = JsonSerializer.SerializeToElement("str_replace_editor");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text_editor_20241022");
        List<ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>> expectedAllowedCallers =
        [
            BetaToolTextEditor20241022AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
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
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedName = JsonSerializer.SerializeToElement("str_replace_editor");
        JsonElement expectedType = JsonSerializer.SerializeToElement("text_editor_20241022");
        List<ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>> expectedAllowedCallers =
        [
            BetaToolTextEditor20241022AllowedCaller.Direct,
        ];
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        bool expectedDeferLoading = true;
        List<Dictionary<string, JsonElement>> expectedInputExamples =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
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
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolTextEditor20241022 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

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
        var model = new BetaToolTextEditor20241022 { CacheControl = new() { Ttl = Ttl.Ttl5m } };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

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
        var model = new BetaToolTextEditor20241022
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },

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
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
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
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
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
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaToolTextEditor20241022
        {
            AllowedCallers = [BetaToolTextEditor20241022AllowedCaller.Direct],
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
        };

        model.Validate();
    }
}

public class BetaToolTextEditor20241022AllowedCallerTest : TestBase
{
    [Theory]
    [InlineData(BetaToolTextEditor20241022AllowedCaller.Direct)]
    [InlineData(BetaToolTextEditor20241022AllowedCaller.CodeExecution20250825)]
    public void Validation_Works(BetaToolTextEditor20241022AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolTextEditor20241022AllowedCaller> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaToolTextEditor20241022AllowedCaller.Direct)]
    [InlineData(BetaToolTextEditor20241022AllowedCaller.CodeExecution20250825)]
    public void SerializationRoundtrip_Works(BetaToolTextEditor20241022AllowedCaller rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaToolTextEditor20241022AllowedCaller> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaToolTextEditor20241022AllowedCaller>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
