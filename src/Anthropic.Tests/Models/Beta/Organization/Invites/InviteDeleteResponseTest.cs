using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class InviteDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InviteDeleteResponse { ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu" };

        string expectedID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu";
        JsonElement expectedType = JsonSerializer.SerializeToElement("invite_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InviteDeleteResponse { ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InviteDeleteResponse { ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu";
        JsonElement expectedType = JsonSerializer.SerializeToElement("invite_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InviteDeleteResponse { ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InviteDeleteResponse { ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu" };

        InviteDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
