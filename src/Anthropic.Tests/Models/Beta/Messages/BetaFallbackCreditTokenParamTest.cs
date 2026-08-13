using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaFallbackCreditTokenParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x", Mode = Mode.Strict };

        string expectedToken = "x";
        ApiEnum<string, Mode> expectedMode = Mode.Strict;

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x", Mode = Mode.Strict };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditTokenParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x", Mode = Mode.Strict };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaFallbackCreditTokenParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "x";
        ApiEnum<string, Mode> expectedMode = Mode.Strict;

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x", Mode = Mode.Strict };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x" };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaFallbackCreditTokenParam
        {
            Token = "x",

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaFallbackCreditTokenParam
        {
            Token = "x",

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaFallbackCreditTokenParam { Token = "x", Mode = Mode.Strict };

        BetaFallbackCreditTokenParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Strict)]
    [InlineData(Mode.BestEffort)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Strict)]
    [InlineData(Mode.BestEffort)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
