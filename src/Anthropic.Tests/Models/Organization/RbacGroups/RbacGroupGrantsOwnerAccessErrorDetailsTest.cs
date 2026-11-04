using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacGroups;

namespace Anthropic.Tests.Models.Organization.RbacGroups;

public class RbacGroupGrantsOwnerAccessErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacGroupGrantsOwnerAccessErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_grants_owner_access"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacGroupGrantsOwnerAccessErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupGrantsOwnerAccessErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacGroupGrantsOwnerAccessErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacGroupGrantsOwnerAccessErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_grants_owner_access"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacGroupGrantsOwnerAccessErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacGroupGrantsOwnerAccessErrorDetails { };

        RbacGroupGrantsOwnerAccessErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
