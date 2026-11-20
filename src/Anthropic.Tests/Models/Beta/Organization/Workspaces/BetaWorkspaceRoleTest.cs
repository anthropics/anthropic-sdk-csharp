using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaWorkspaceRoleTest : TestBase
{
    [Theory]
    [InlineData(BetaWorkspaceRole.WorkspaceAdmin)]
    [InlineData(BetaWorkspaceRole.WorkspaceBilling)]
    [InlineData(BetaWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(BetaWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(BetaWorkspaceRole.WorkspaceUser)]
    public void Validation_Works(BetaWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWorkspaceRole.WorkspaceAdmin, 0, "workspace_admin")]
    [InlineData(BetaWorkspaceRole.WorkspaceBilling, 1, "workspace_billing")]
    [InlineData(BetaWorkspaceRole.WorkspaceDeveloper, 2, "workspace_developer")]
    [InlineData(
        BetaWorkspaceRole.WorkspaceRestrictedDeveloper,
        3,
        "workspace_restricted_developer"
    )]
    [InlineData(BetaWorkspaceRole.WorkspaceUser, 4, "workspace_user")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaWorkspaceRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRole>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
