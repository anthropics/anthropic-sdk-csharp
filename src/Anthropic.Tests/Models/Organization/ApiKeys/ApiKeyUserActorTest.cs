using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeyUserActor { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeyUserActor { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeyUserActor { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeyUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeyUserActor { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeyUserActor { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        ApiKeyUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
