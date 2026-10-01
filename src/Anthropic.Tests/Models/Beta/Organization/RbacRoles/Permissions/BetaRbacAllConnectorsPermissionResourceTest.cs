using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class BetaRbacAllConnectorsPermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacAllConnectorsPermissionResource { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("all_connectors");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacAllConnectorsPermissionResource { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacAllConnectorsPermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacAllConnectorsPermissionResource { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacAllConnectorsPermissionResource>(
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
        var model = new BetaRbacAllConnectorsPermissionResource { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacAllConnectorsPermissionResource { };

        BetaRbacAllConnectorsPermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
