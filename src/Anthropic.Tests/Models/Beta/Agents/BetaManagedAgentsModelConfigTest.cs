using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus5_5;
        Effort expectedEffort = new BetaManagedAgentsEffortLow();
        string expectedInferenceGeo = "inference_geo";
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedInferenceGeo, model.InferenceGeo);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus5_5;
        Effort expectedEffort = new BetaManagedAgentsEffortLow();
        string expectedInferenceGeo = "inference_geo";
        ApiEnum<string, Speed> expectedSpeed = Speed.Standard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedInferenceGeo, deserialized.InferenceGeo);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsModelConfig { ID = BetaManagedAgentsModel.ClaudeOpus5_5 };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfig { ID = BetaManagedAgentsModel.ClaudeOpus5_5 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,

            // Null should be interpreted as omitted for these properties
            Effort = null,
            InferenceGeo = null,
            Speed = null,
        };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        } with
        {
            // Null should be interpreted as omitted for these properties
            Effort = null,
            InferenceGeo = null,
            Speed = null,
        };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.InferenceGeo);
        Assert.False(model.RawData.ContainsKey("inference_geo"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,

            // Null should be interpreted as omitted for these properties
            Effort = null,
            InferenceGeo = null,
            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsModelConfig
        {
            ID = BetaManagedAgentsModel.ClaudeOpus5_5,
            Effort = new BetaManagedAgentsEffortLow(),
            InferenceGeo = "inference_geo",
            Speed = Speed.Standard,
        };

        BetaManagedAgentsModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EffortTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsEffortLowValidationWorks()
    {
        Effort value = new BetaManagedAgentsEffortLow();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortMediumValidationWorks()
    {
        Effort value = new BetaManagedAgentsEffortMedium();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortHighValidationWorks()
    {
        Effort value = new BetaManagedAgentsEffortHigh();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortXhighValidationWorks()
    {
        Effort value = new BetaManagedAgentsEffortXhigh();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortMaxValidationWorks()
    {
        Effort value = new BetaManagedAgentsEffortMax();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortLowSerializationRoundtripWorks()
    {
        Effort value = new BetaManagedAgentsEffortLow();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Effort>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortMediumSerializationRoundtripWorks()
    {
        Effort value = new BetaManagedAgentsEffortMedium();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Effort>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortHighSerializationRoundtripWorks()
    {
        Effort value = new BetaManagedAgentsEffortHigh();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Effort>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortXhighSerializationRoundtripWorks()
    {
        Effort value = new BetaManagedAgentsEffortXhigh();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Effort>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortMaxSerializationRoundtripWorks()
    {
        Effort value = new BetaManagedAgentsEffortMax();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Effort>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortLowTypeWorks()
    {
        Effort value = new BetaManagedAgentsEffortLow();
        Assert.Equal(EffortType.Low, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEffortMediumTypeWorks()
    {
        Effort value = new BetaManagedAgentsEffortMedium();
        Assert.Equal(EffortType.Medium, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEffortHighTypeWorks()
    {
        Effort value = new BetaManagedAgentsEffortHigh();
        Assert.Equal(EffortType.High, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEffortXhighTypeWorks()
    {
        Effort value = new BetaManagedAgentsEffortXhigh();
        Assert.Equal(EffortType.Xhigh, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsEffortMaxTypeWorks()
    {
        Effort value = new BetaManagedAgentsEffortMax();
        Assert.Equal(EffortType.Max, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Effort value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "low"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, EffortType> expectedType = EffortType.Low;

        Assert.Equal(expectedType, value.Type);

        Effort emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class EffortTypeTest : TestBase
{
    [Theory]
    [InlineData(EffortType.Low)]
    [InlineData(EffortType.Medium)]
    [InlineData(EffortType.High)]
    [InlineData(EffortType.Xhigh)]
    [InlineData(EffortType.Max)]
    public void Validation_Works(EffortType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffortType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffortType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EffortType.Low)]
    [InlineData(EffortType.Medium)]
    [InlineData(EffortType.High)]
    [InlineData(EffortType.Xhigh)]
    [InlineData(EffortType.Max)]
    public void SerializationRoundtrip_Works(EffortType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EffortType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffortType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EffortType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EffortType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
