using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamModelConfigParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };

        string expectedID = "x";
        ApiEnum<string, BetaDreamModelConfigParamSpeed> expectedSpeed =
            BetaDreamModelConfigParamSpeed.Standard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamModelConfigParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamModelConfigParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "x";
        ApiEnum<string, BetaDreamModelConfigParamSpeed> expectedSpeed =
            BetaDreamModelConfigParamSpeed.Standard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaDreamModelConfigParam { ID = "x" };

        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaDreamModelConfigParam { ID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",

            Speed = null,
        };

        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",

            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamModelConfigParam
        {
            ID = "x",
            Speed = BetaDreamModelConfigParamSpeed.Standard,
        };

        BetaDreamModelConfigParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaDreamModelConfigParamSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaDreamModelConfigParamSpeed.Standard)]
    [InlineData(BetaDreamModelConfigParamSpeed.Fast)]
    public void Validation_Works(BetaDreamModelConfigParamSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamModelConfigParamSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamModelConfigParamSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaDreamModelConfigParamSpeed.Standard)]
    [InlineData(BetaDreamModelConfigParamSpeed.Fast)]
    public void SerializationRoundtrip_Works(BetaDreamModelConfigParamSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaDreamModelConfigParamSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDreamModelConfigParamSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaDreamModelConfigParamSpeed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaDreamModelConfigParamSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
