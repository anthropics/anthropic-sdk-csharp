using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionRequiresActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };

        List<string> expectedEventIds = ["string"];
        ApiEnum<string, BetaManagedAgentsSessionRequiresActionType> expectedType =
            BetaManagedAgentsSessionRequiresActionType.RequiresAction;

        Assert.Equal(expectedEventIds.Count, model.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], model.EventIds[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRequiresAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionRequiresAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedEventIds = ["string"];
        ApiEnum<string, BetaManagedAgentsSessionRequiresActionType> expectedType =
            BetaManagedAgentsSessionRequiresActionType.RequiresAction;

        Assert.Equal(expectedEventIds.Count, deserialized.EventIds.Count);
        for (int i = 0; i < expectedEventIds.Count; i++)
        {
            Assert.Equal(expectedEventIds[i], deserialized.EventIds[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionRequiresAction
        {
            EventIds = ["string"],
            Type = BetaManagedAgentsSessionRequiresActionType.RequiresAction,
        };

        BetaManagedAgentsSessionRequiresAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionRequiresActionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionRequiresActionType.RequiresAction)]
    public void Validation_Works(BetaManagedAgentsSessionRequiresActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRequiresActionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRequiresActionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionRequiresActionType.RequiresAction)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionRequiresActionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionRequiresActionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRequiresActionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRequiresActionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionRequiresActionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
