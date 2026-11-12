using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization;

namespace Anthropic.Tests.Models.Organization;

public class RbacRoleNotFoundErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacRoleNotFoundErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("rbac_role_not_found");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacRoleNotFoundErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleNotFoundErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacRoleNotFoundErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRoleNotFoundErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("rbac_role_not_found");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacRoleNotFoundErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacRoleNotFoundErrorDetails { };

        RbacRoleNotFoundErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
