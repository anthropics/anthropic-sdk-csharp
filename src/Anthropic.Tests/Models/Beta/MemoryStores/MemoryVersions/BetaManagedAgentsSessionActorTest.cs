using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class BetaManagedAgentsSessionActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionActor
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        string expectedSessionID = "x";
        ApiEnum<string, BetaManagedAgentsSessionActorType> expectedType =
            BetaManagedAgentsSessionActorType.SessionActor;

        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionActor
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionActor
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSessionID = "x";
        ApiEnum<string, BetaManagedAgentsSessionActorType> expectedType =
            BetaManagedAgentsSessionActorType.SessionActor;

        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionActor
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionActor
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };

        BetaManagedAgentsSessionActor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSessionActorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionActorType.SessionActor)]
    public void Validation_Works(BetaManagedAgentsSessionActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionActorType.SessionActor)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsSessionActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionActorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
