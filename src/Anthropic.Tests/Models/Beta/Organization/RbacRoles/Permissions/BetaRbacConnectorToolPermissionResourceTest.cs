using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class BetaRbacConnectorToolPermissionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacConnectorToolPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        string expectedToolName = "search_issues";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector_tool");

        Assert.Equal(expectedConnectorID, model.ConnectorID);
        Assert.Equal(expectedToolName, model.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacConnectorToolPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacConnectorToolPermissionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacConnectorToolPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacConnectorToolPermissionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";
        string expectedToolName = "search_issues";
        JsonElement expectedType = JsonSerializer.SerializeToElement("connector_tool");

        Assert.Equal(expectedConnectorID, deserialized.ConnectorID);
        Assert.Equal(expectedToolName, deserialized.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacConnectorToolPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacConnectorToolPermissionResource
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };

        BetaRbacConnectorToolPermissionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
