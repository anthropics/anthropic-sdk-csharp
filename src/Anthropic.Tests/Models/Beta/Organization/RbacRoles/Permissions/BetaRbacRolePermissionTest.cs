using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Beta.Organization.RbacRoles.Permissions;

public class BetaRbacRolePermissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacRolePermission
        {
            Action = "use",
            Resource = new BetaRbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string expectedAction = "use";
        Resource expectedResource = new BetaRbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_role_permission");

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedResource, model.Resource);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacRolePermission
        {
            Action = "use",
            Resource = new BetaRbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRolePermission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacRolePermission
        {
            Action = "use",
            Resource = new BetaRbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacRolePermission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAction = "use";
        Resource expectedResource = new BetaRbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        JsonElement expectedType = JsonSerializer.SerializeToElement("rbac_role_permission");

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedResource, deserialized.Resource);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacRolePermission
        {
            Action = "use",
            Resource = new BetaRbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacRolePermission
        {
            Action = "use",
            Resource = new BetaRbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        BetaRbacRolePermission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResourceTest : TestBase
{
    [Fact]
    public void BetaRbacOrganizationPermissionValidationWorks()
    {
        Resource value = new BetaRbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        value.Validate();
    }

    [Fact]
    public void BetaRbacConnectorToolPermissionValidationWorks()
    {
        Resource value = new BetaRbacConnectorToolPermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };
        value.Validate();
    }

    [Fact]
    public void BetaRbacConnectorScopePermissionValidationWorks()
    {
        Resource value = new BetaRbacConnectorScopePermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };
        value.Validate();
    }

    [Fact]
    public void BetaRbacConnectorPermissionValidationWorks()
    {
        Resource value = new BetaRbacConnectorPermissionResource("mcpsrv_01BqrKSXkKPpCJWuLoof7q8m");
        value.Validate();
    }

    [Fact]
    public void BetaRbacAllConnectorsPermissionValidationWorks()
    {
        Resource value = new BetaRbacAllConnectorsPermissionResource();
        value.Validate();
    }

    [Fact]
    public void BetaRbacOrganizationPermissionSerializationRoundtripWorks()
    {
        Resource value = new BetaRbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRbacConnectorToolPermissionSerializationRoundtripWorks()
    {
        Resource value = new BetaRbacConnectorToolPermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRbacConnectorScopePermissionSerializationRoundtripWorks()
    {
        Resource value = new BetaRbacConnectorScopePermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRbacConnectorPermissionSerializationRoundtripWorks()
    {
        Resource value = new BetaRbacConnectorPermissionResource("mcpsrv_01BqrKSXkKPpCJWuLoof7q8m");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRbacAllConnectorsPermissionSerializationRoundtripWorks()
    {
        Resource value = new BetaRbacAllConnectorsPermissionResource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Resource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization",
                  "connector_id": "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");
        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedConnectorID, value.ConnectorID);

        Resource emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ConnectorID);

        Resource mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "connector_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ConnectorID);
    }
}
