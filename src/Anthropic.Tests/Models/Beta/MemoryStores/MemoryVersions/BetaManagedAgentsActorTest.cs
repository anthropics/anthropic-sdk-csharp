using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.MemoryVersions;

namespace Anthropic.Tests.Models.Beta.MemoryStores.MemoryVersions;

public class BetaManagedAgentsActorTest : TestBase
{
    [Fact]
    public void SessionValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsSessionActor("x");
        value.Validate();
    }

    [Fact]
    public void ApiValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsApiActor("x");
        value.Validate();
    }

    [Fact]
    public void UserValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsUserActor("x");
        value.Validate();
    }

    [Fact]
    public void ServiceAccountValidationWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsServiceAccountActor("x");
        value.Validate();
    }

    [Fact]
    public void SessionSerializationRoundtripWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsSessionActor("x");
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
        BetaManagedAgentsActor value = new BetaManagedAgentsApiActor("x");
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
        BetaManagedAgentsActor value = new BetaManagedAgentsUserActor("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServiceAccountSerializationRoundtripWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsServiceAccountActor("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsActor>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SessionTypeWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsSessionActor("x");
        Assert.Equal(BetaManagedAgentsActorType.SessionActor, value.Type.Value());
    }

    [Fact]
    public void ApiTypeWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsApiActor("x");
        Assert.Equal(BetaManagedAgentsActorType.ApiActor, value.Type.Value());
    }

    [Fact]
    public void UserTypeWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsUserActor("x");
        Assert.Equal(BetaManagedAgentsActorType.UserActor, value.Type.Value());
    }

    [Fact]
    public void ServiceAccountTypeWorks()
    {
        BetaManagedAgentsActor value = new BetaManagedAgentsServiceAccountActor("x");
        Assert.Equal(BetaManagedAgentsActorType.ServiceAccountActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsActor value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "session_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsActorType> expectedType =
            BetaManagedAgentsActorType.SessionActor;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsActor emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsActorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsActorType.SessionActor)]
    [InlineData(BetaManagedAgentsActorType.ApiActor)]
    [InlineData(BetaManagedAgentsActorType.UserActor)]
    [InlineData(BetaManagedAgentsActorType.ServiceAccountActor)]
    public void Validation_Works(BetaManagedAgentsActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsActorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsActorType.SessionActor)]
    [InlineData(BetaManagedAgentsActorType.ApiActor)]
    [InlineData(BetaManagedAgentsActorType.UserActor)]
    [InlineData(BetaManagedAgentsActorType.ServiceAccountActor)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsActorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsActorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsActorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsActorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
