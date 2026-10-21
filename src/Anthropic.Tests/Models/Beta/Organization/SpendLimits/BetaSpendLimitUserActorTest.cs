using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitUserActor
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        bool expectedDeleted = true;
        string expectedEmailAddress = "email_address";
        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.Equal(expectedDeleted, model.Deleted);
        Assert.Equal(expectedEmailAddress, model.EmailAddress);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitUserActor
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitUserActor
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeleted = true;
        string expectedEmailAddress = "email_address";
        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.Equal(expectedDeleted, deserialized.Deleted);
        Assert.Equal(expectedEmailAddress, deserialized.EmailAddress);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendLimitUserActor
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitUserActor
        {
            Deleted = true,
            EmailAddress = "email_address",
            Name = "name",
            UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
        };

        BetaSpendLimitUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
