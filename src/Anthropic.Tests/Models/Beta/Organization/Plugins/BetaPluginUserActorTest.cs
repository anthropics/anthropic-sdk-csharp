using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Plugins;

namespace Anthropic.Tests.Models.Beta.Organization.Plugins;

public class BetaPluginUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaPluginUserActor
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string expectedEmailAddress = "user@example.com";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaPluginUserActor
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaPluginUserActor
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaPluginUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmailAddress = "user@example.com";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaPluginUserActor
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaPluginUserActor
        {
            EmailAddress = "user@example.com",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        BetaPluginUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
