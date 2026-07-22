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
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
            Effort = BetaManagedAgentsEffortLevel.Low,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus4_8;
        BetaManagedAgentsModelConfigParamsEffort expectedEffort = BetaManagedAgentsEffortLevel.Low;
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> expectedSpeed =
            BetaManagedAgentsModelConfigParamsSpeed.Standard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedSpeed, model.Speed);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
            Effort = BetaManagedAgentsEffortLevel.Low,
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
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
            Effort = BetaManagedAgentsEffortLevel.Low,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsModel> expectedID = BetaManagedAgentsModel.ClaudeOpus4_8;
        BetaManagedAgentsModelConfigParamsEffort expectedEffort = BetaManagedAgentsEffortLevel.Low;
        ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed> expectedSpeed =
            BetaManagedAgentsModelConfigParamsSpeed.Standard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedSpeed, deserialized.Speed);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
            Effort = BetaManagedAgentsEffortLevel.Low,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
        };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Speed);
        Assert.False(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,

            Effort = null,
            Speed = null,
        };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Speed);
        Assert.True(model.RawData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,

            Effort = null,
            Speed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsModelConfigParams
        {
            ID = BetaManagedAgentsModel.ClaudeOpus4_8,
            Effort = BetaManagedAgentsEffortLevel.Low,
            Speed = BetaManagedAgentsModelConfigParamsSpeed.Standard,
        };

        BetaManagedAgentsModelConfigParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsModelConfigParamsEffortTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsEffortLevelValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = BetaManagedAgentsEffortLevel.Low;
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortLowValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortLow(
            BetaManagedAgentsEffortLowType.Low
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortMediumValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortMedium(
            BetaManagedAgentsEffortMediumType.Medium
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortHighValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortHigh(
            BetaManagedAgentsEffortHighType.High
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortXhighValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortXhigh(
            BetaManagedAgentsEffortXhighType.Xhigh
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortMaxValidationWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortMax(
            BetaManagedAgentsEffortMaxType.Max
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsEffortLevelSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = BetaManagedAgentsEffortLevel.Low;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortLowSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortLow(
            BetaManagedAgentsEffortLowType.Low
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortMediumSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortMedium(
            BetaManagedAgentsEffortMediumType.Medium
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortHighSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortHigh(
            BetaManagedAgentsEffortHighType.High
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortXhighSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortXhigh(
            BetaManagedAgentsEffortXhighType.Xhigh
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsEffortMaxSerializationRoundtripWorks()
    {
        BetaManagedAgentsModelConfigParamsEffort value = new BetaManagedAgentsEffortMax(
            BetaManagedAgentsEffortMaxType.Max
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsModelConfigParamsEffort>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsEffortLevelTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsEffortLevel.Low)]
    [InlineData(BetaManagedAgentsEffortLevel.Medium)]
    [InlineData(BetaManagedAgentsEffortLevel.High)]
    [InlineData(BetaManagedAgentsEffortLevel.Xhigh)]
    [InlineData(BetaManagedAgentsEffortLevel.Max)]
    public void Validation_Works(BetaManagedAgentsEffortLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEffortLevel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsEffortLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsEffortLevel.Low)]
    [InlineData(BetaManagedAgentsEffortLevel.Medium)]
    [InlineData(BetaManagedAgentsEffortLevel.High)]
    [InlineData(BetaManagedAgentsEffortLevel.Xhigh)]
    [InlineData(BetaManagedAgentsEffortLevel.Max)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsEffortLevel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsEffortLevel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEffortLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsEffortLevel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsEffortLevel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
