using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaNoBillingWorkspaceRoleTest : TestBase
{
    [Theory]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceAdmin)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceUser)]
    public void Validation_Works(BetaNoBillingWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaNoBillingWorkspaceRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaNoBillingWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceAdmin, 0, "workspace_admin")]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceDeveloper, 1, "workspace_developer")]
    [InlineData(
        BetaNoBillingWorkspaceRole.WorkspaceRestrictedDeveloper,
        2,
        "workspace_restricted_developer"
    )]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceUser, 3, "workspace_user")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaNoBillingWorkspaceRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaNoBillingWorkspaceRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaNoBillingWorkspaceRole>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaNoBillingWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaNoBillingWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
