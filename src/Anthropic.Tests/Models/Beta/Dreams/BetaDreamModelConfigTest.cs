using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x", Speed = Speed.Standard };

        string expectedID = "x";
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x", Speed = Speed.Standard };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x", Speed = Speed.Standard };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "x";
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x", Speed = Speed.Standard };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x" };

        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaDreamModelConfig
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            Speed = null,
        };

        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaDreamModelConfig
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamModelConfig { ID = "x", Speed = Speed.Standard };

        BetaDreamModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Speed.Standard)]
    [InlineData(Speed.Fast)]
    public void Validation_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Speed.Standard)]
    [InlineData(Speed.Fast)]
    public void SerializationRoundtrip_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
