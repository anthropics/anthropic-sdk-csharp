using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization;

namespace Anthropic.Tests.Models.Organization;

public class RbacGroupOwnerAccessUnconfirmedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupOwnerAccessUnconfirmedErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_owner_access_unconfirmed"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacGroupOwnerAccessUnconfirmedErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupOwnerAccessUnconfirmedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupOwnerAccessUnconfirmedErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupOwnerAccessUnconfirmedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_owner_access_unconfirmed"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacGroupOwnerAccessUnconfirmedErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupOwnerAccessUnconfirmedErrorDetails { };

        RbacGroupOwnerAccessUnconfirmedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
