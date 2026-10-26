using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Users;

namespace Anthropic.Tests.Models.Organization.Users;

public class UserRemoveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRemoveResponse { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        string expectedID = "user_01WxYzAbCdEfGhJkMnPqRsTu";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRemoveResponse { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRemoveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRemoveResponse { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRemoveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "user_01WxYzAbCdEfGhJkMnPqRsTu";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRemoveResponse { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserRemoveResponse { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu" };

        UserRemoveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
