using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Organization.RbacRoles.Permissions;

public class RbacAllConnectorsPermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacAllConnectorsPermissionResource { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("all_connectors");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacAllConnectorsPermissionResource { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacAllConnectorsPermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacAllConnectorsPermissionResource { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacAllConnectorsPermissionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("all_connectors");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacAllConnectorsPermissionResource { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacAllConnectorsPermissionResource { };

        RbacAllConnectorsPermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
