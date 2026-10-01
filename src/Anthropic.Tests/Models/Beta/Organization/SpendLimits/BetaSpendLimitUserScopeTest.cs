using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Beta.Organization.SpendLimits;

public class BetaSpendLimitUserScopeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSpendLimitUserScope { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("user");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSpendLimitUserScope { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserScope>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSpendLimitUserScope { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserScope>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("user");
        string expectedUserID = "user_01WCz1FkmYMm4gnmykNKUu3Q";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSpendLimitUserScope { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSpendLimitUserScope { UserID = "user_01WCz1FkmYMm4gnmykNKUu3Q" };

        BetaSpendLimitUserScope copied = new(model);

        Assert.Equal(model, copied);
    }
}
