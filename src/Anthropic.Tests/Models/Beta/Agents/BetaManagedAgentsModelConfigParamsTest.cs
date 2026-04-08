using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsModelConfigParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus4_6;
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> expectedSpeed =
            BetaManagedAgentsModelConfigParamsSpeed.Standard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus4_6;
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> expectedSpeed =
            BetaManagedAgentsModelConfigParamsSpeed.Standard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
        };

        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,

            Speed = null,
        };

        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,

            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_6,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        BetaManagedAgentsModelConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsModelConfigParamsSpeedTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsModelConfigParamsSpeed.Standard)]
    [InlineData(BetaManagedAgentsModelConfigParamsSpeed.Fast)]
    public void Validation_Works(BetaManagedAgentsModelConfigParamsSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsModelConfigParamsSpeed.Standard)]
    [InlineData(BetaManagedAgentsModelConfigParamsSpeed.Fast)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsModelConfigParamsSpeed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
