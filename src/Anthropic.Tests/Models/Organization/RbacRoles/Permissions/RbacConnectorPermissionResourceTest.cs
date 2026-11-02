using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Organization.RbacRoles.Permissions;

public class RbacConnectorPermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacConnectorPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
        };

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector");

        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RbacConnectorPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacConnectorPermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacConnectorPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacConnectorPermissionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector");

        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RbacConnectorPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacConnectorPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
        };

        RbacConnectorPermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
