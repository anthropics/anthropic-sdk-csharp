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
        var model = new BetaOutputConfig { Effort = Effort.Low };

        ApiEnum<string, Effort> expectedEffort = Effort.Low;

        Assert.Equal(expectedEffort, model.Effort);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Effort> expectedEffort = Effort.Low;

        Assert.Equal(expectedEffort, deserialized.Effort);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputConfig { Effort = Effort.Low };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaOutputConfig { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
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
        var model = new BetaOutputConfig { Effort = null };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaOutputConfig { Effort = null };

        model.Validate();
    }
}

public class EffortTest : TestBase
{
    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
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
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
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
