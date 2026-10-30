using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.RbacRoles.Permissions;

namespace Anthropic.Tests.Models.Organization.RbacRoles.Permissions;

public class RbacRolePermissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RbacRolePermission
        {
            Action = "use",
            Resource = new RbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string expectedAction = "use";
        Resource expectedResource = new RbacOrganizationPermissionResource(
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
        var model = new RbacRolePermission
        {
            Action = "use",
            Resource = new RbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRolePermission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RbacRolePermission
        {
            Action = "use",
            Resource = new RbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RbacRolePermission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAction = "use";
        Resource expectedResource = new RbacOrganizationPermissionResource(
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
        var model = new RbacRolePermission
        {
            Action = "use",
            Resource = new RbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RbacRolePermission
        {
            Action = "use",
            Resource = new RbacOrganizationPermissionResource(
                "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
            ),
        };

        RbacRolePermission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResourceTest : TestBase
{
    [Fact]
    public void RbacOrganizationPermissionValidationWorks()
    {
        Resource value = new RbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        value.Validate();
    }

    [Fact]
    public void RbacConnectorToolPermissionValidationWorks()
    {
        Resource value = new RbacConnectorToolPermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };
        value.Validate();
    }

    [Fact]
    public void RbacConnectorScopePermissionValidationWorks()
    {
        Resource value = new RbacConnectorScopePermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };
        value.Validate();
    }

    [Fact]
    public void RbacConnectorPermissionValidationWorks()
    {
        Resource value = new RbacConnectorPermissionResource("mcpsrv_01BqrKSXkKPpCJWuLoof7q8m");
        value.Validate();
    }

    [Fact]
    public void RbacAllConnectorsPermissionValidationWorks()
    {
        Resource value = new RbacAllConnectorsPermissionResource();
        value.Validate();
    }

    [Fact]
    public void RbacOrganizationPermissionSerializationRoundtripWorks()
    {
        Resource value = new RbacOrganizationPermissionResource(
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
    public void RbacConnectorToolPermissionSerializationRoundtripWorks()
    {
        Resource value = new RbacConnectorToolPermissionResource()
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
    public void RbacConnectorScopePermissionSerializationRoundtripWorks()
    {
        Resource value = new RbacConnectorScopePermissionResource()
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
    public void RbacConnectorPermissionSerializationRoundtripWorks()
    {
        Resource value = new RbacConnectorPermissionResource("mcpsrv_01BqrKSXkKPpCJWuLoof7q8m");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacAllConnectorsPermissionSerializationRoundtripWorks()
    {
        Resource value = new RbacAllConnectorsPermissionResource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Resource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RbacOrganizationPermissionTypeWorks()
    {
        Resource value = new RbacOrganizationPermissionResource(
            "3c4f5e6d-7a8b-49c0-9d1e-2f3a4b5c6d7e"
        );
        Assert.Equal(ResourceType.Organization, value.Type.Value());
    }

    [Fact]
    public void RbacConnectorToolPermissionTypeWorks()
    {
        Resource value = new RbacConnectorToolPermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            ToolName = "search_issues",
        };
        Assert.Equal(ResourceType.ConnectorTool, value.Type.Value());
    }

    [Fact]
    public void RbacConnectorScopePermissionTypeWorks()
    {
        Resource value = new RbacConnectorScopePermissionResource()
        {
            ConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m",
            Scope = "offline_access",
        };
        Assert.Equal(ResourceType.ConnectorScope, value.Type.Value());
    }

    [Fact]
    public void RbacConnectorPermissionTypeWorks()
    {
        Resource value = new RbacConnectorPermissionResource("mcpsrv_01BqrKSXkKPpCJWuLoof7q8m");
        Assert.Equal(ResourceType.Connector, value.Type.Value());
    }

    [Fact]
    public void RbacAllConnectorsPermissionTypeWorks()
    {
        Resource value = new RbacAllConnectorsPermissionResource();
        Assert.Equal(ResourceType.AllConnectors, value.Type.Value());
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

        ApiEnum<string, ResourceType> expectedType = ResourceType.Organization;
        string expectedConnectorID = "mcpsrv_01BqrKSXkKPpCJWuLoof7q8m";

        Assert.Equal(expectedType, value.Type);
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

public class ResourceTypeTest : TestBase
{
    [Theory]
    [InlineData(ResourceType.Organization)]
    [InlineData(ResourceType.ConnectorTool)]
    [InlineData(ResourceType.ConnectorScope)]
    [InlineData(ResourceType.Connector)]
    [InlineData(ResourceType.AllConnectors)]
    public void Validation_Works(ResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResourceType.Organization)]
    [InlineData(ResourceType.ConnectorTool)]
    [InlineData(ResourceType.ConnectorScope)]
    [InlineData(ResourceType.Connector)]
    [InlineData(ResourceType.AllConnectors)]
    public void SerializationRoundtrip_Works(ResourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
