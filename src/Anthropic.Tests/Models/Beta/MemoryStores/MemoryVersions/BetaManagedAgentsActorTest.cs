using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class BetaManagedAgentsActorTest : TestBase
{
    [Fact]
    public void SessionValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsApiActor()
        {
            ApiKeyID = "x",
            Type = Type.ApiActor,
        };
        value.Validate();
    }

    [Fact]
    public void UserValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsUserActor()
        {
            Type = BetaManagedAgentsUserActorType.UserActor,
            UserID = "x",
        };
        value.Validate();
    }

    [Fact]
    public void SessionSerializationRoundtripWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsSessionActor()
        {
            SessionID = "x",
            Type = BetaManagedAgentsSessionActorType.SessionActor,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiSerializationRoundtripWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsApiActor()
        {
            ApiKeyID = "x",
            Type = Type.ApiActor,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UserSerializationRoundtripWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsUserActor()
        {
            Type = BetaManagedAgentsUserActorType.UserActor,
            UserID = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
