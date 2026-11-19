using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Tests.Models.Organization.Workspaces;

public class NoBillingWorkspaceRoleTest : TestBase
{
    [Theory]
    [InlineData(NoBillingWorkspaceRole.WorkspaceAdmin)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceUser)]
    public void Validation_Works(NoBillingWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NoBillingWorkspaceRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NoBillingWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NoBillingWorkspaceRole.WorkspaceAdmin, 0, "workspace_admin")]
    [InlineData(NoBillingWorkspaceRole.WorkspaceDeveloper, 1, "workspace_developer")]
    [InlineData(
        NoBillingWorkspaceRole.WorkspaceRestrictedDeveloper,
        2,
        "workspace_restricted_developer"
    )]
    [InlineData(NoBillingWorkspaceRole.WorkspaceUser, 3, "workspace_user")]
    public void EnumMemberSerializationRoundtrip_Works(
        NoBillingWorkspaceRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NoBillingWorkspaceRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NoBillingWorkspaceRole>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, NoBillingWorkspaceRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NoBillingWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
