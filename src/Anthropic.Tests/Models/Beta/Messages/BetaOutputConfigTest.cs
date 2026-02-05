using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        ApiEnum<string, Effort> expectedEffort = Effort.Low;
        BetaJsonOutputFormat expectedFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedFormat, model.Format);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Effort> expectedEffort = Effort.Low;
        BetaJsonOutputFormat expectedFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedFormat, deserialized.Format);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaOutputConfig { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaOutputConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaOutputConfig { Effort = null, Format = null };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Format);
        Assert.True(model.RawData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaOutputConfig { Effort = null, Format = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        BetaOutputConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EffortTest : TestBase
{
    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Max)]
    public void Validation_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Max)]
    public void SerializationRoundtrip_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
