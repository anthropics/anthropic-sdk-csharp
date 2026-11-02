using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ApiKeys;

public class BetaApiKeyUserActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaApiKeyUserActor { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaApiKeyUserActor { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaApiKeyUserActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaApiKeyUserActor { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaApiKeyUserActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");
        string expectedUserID = "user_01WxYzAbCdEfGhJkMnPqRsTu";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaApiKeyUserActor { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaApiKeyUserActor { UserID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        BetaApiKeyUserActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
