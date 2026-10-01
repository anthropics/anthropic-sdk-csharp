using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class BetaRbacConnectorScopePermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacConnectorScopePermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        string expectedScope = "offline_access";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector_scope");

        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedScope, model.Scope);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacConnectorScopePermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacConnectorScopePermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacConnectorScopePermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacConnectorScopePermissionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        string expectedScope = "offline_access";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector_scope");

        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacConnectorScopePermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacConnectorScopePermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };

        BetaRbacConnectorScopePermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
