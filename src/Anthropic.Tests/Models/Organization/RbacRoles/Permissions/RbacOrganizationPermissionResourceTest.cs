using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Organization.RbacRoles.Permissions;

public class RbacOrganizationPermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacOrganizationPermissionResource
        {
            OrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e",
        };

        string expectedOrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.Equal(expectedOrganizationID, model.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacOrganizationPermissionResource
        {
            OrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacOrganizationPermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacOrganizationPermissionResource
        {
            OrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacOrganizationPermissionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedOrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e";
        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.Equal(expectedOrganizationID, deserialized.OrganizationID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacOrganizationPermissionResource
        {
            OrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacOrganizationPermissionResource
        {
            OrganizationID = "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e",
        };

        RbacOrganizationPermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
