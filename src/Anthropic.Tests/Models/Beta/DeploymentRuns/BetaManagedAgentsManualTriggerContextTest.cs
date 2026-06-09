using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class BetaManagedAgentsManualTriggerContextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsManualTriggerContext
        {
            Type = BetaManagedAgentsManualTriggerContextType.Manual,
        };

        ApiEnum<string, BetaManagedAgentsManualTriggerContextType> expectedType =
            BetaManagedAgentsManualTriggerContextType.Manual;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsManualTriggerContext
        {
            Type = BetaManagedAgentsManualTriggerContextType.Manual,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsManualTriggerContext>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsManualTriggerContext
        {
            Type = BetaManagedAgentsManualTriggerContextType.Manual,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsManualTriggerContext>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsManualTriggerContextType> expectedType =
            BetaManagedAgentsManualTriggerContextType.Manual;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsManualTriggerContext
        {
            Type = BetaManagedAgentsManualTriggerContextType.Manual,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsManualTriggerContext
        {
            Type = BetaManagedAgentsManualTriggerContextType.Manual,
        };

        BetaManagedAgentsManualTriggerContext copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsManualTriggerContextTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsManualTriggerContextType.Manual)]
    public void Validation_Works(BetaManagedAgentsManualTriggerContextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsManualTriggerContextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualTriggerContextType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsManualTriggerContextType.Manual)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsManualTriggerContextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsManualTriggerContextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualTriggerContextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualTriggerContextType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsManualTriggerContextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
