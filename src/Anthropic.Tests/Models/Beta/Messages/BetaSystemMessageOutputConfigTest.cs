using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaSystemMessageOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSystemMessageOutputConfig
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        ApiEnum<string, BetaSystemMessageOutputConfigEffort> expectedEffort =
            BetaSystemMessageOutputConfigEffort.Low;

        Assert.Equal(expectedEffort, model.Effort);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSystemMessageOutputConfig
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageOutputConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSystemMessageOutputConfig
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSystemMessageOutputConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaSystemMessageOutputConfigEffort> expectedEffort =
            BetaSystemMessageOutputConfigEffort.Low;

        Assert.Equal(expectedEffort, deserialized.Effort);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSystemMessageOutputConfig
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSystemMessageOutputConfig { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSystemMessageOutputConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaSystemMessageOutputConfig { Effort = null };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSystemMessageOutputConfig { Effort = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSystemMessageOutputConfig
        {
            Effort = BetaSystemMessageOutputConfigEffort.Low,
        };

        BetaSystemMessageOutputConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaSystemMessageOutputConfigEffortTest : TestBase
{
    [Theory]
    [InlineData(BetaSystemMessageOutputConfigEffort.Low)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Medium)]
    [InlineData(BetaSystemMessageOutputConfigEffort.High)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Xhigh)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Max)]
    public void Validation_Works(BetaSystemMessageOutputConfigEffort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSystemMessageOutputConfigEffort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSystemMessageOutputConfigEffort>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaSystemMessageOutputConfigEffort.Low)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Medium)]
    [InlineData(BetaSystemMessageOutputConfigEffort.High)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Xhigh)]
    [InlineData(BetaSystemMessageOutputConfigEffort.Max)]
    public void SerializationRoundtrip_Works(BetaSystemMessageOutputConfigEffort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaSystemMessageOutputConfigEffort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSystemMessageOutputConfigEffort>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSystemMessageOutputConfigEffort>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaSystemMessageOutputConfigEffort>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
