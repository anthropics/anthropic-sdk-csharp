using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class WorkspaceRoleTest : TestBase
{
    [Theory]
    [InlineData(WorkspaceRole.WorkspaceAdmin)]
    [InlineData(WorkspaceRole.WorkspaceBilling)]
    [InlineData(WorkspaceRole.WorkspaceDeveloper)]
    [InlineData(WorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(WorkspaceRole.WorkspaceUser)]
    public void Validation_Works(WorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WorkspaceRole.WorkspaceAdmin, 0, "workspace_admin")]
    [InlineData(WorkspaceRole.WorkspaceBilling, 1, "workspace_billing")]
    [InlineData(WorkspaceRole.WorkspaceDeveloper, 2, "workspace_developer")]
    [InlineData(WorkspaceRole.WorkspaceRestrictedDeveloper, 3, "workspace_restricted_developer")]
    [InlineData(WorkspaceRole.WorkspaceUser, 4, "workspace_user")]
    public void EnumMemberSerializationRoundtrip_Works(
        WorkspaceRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRole>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
