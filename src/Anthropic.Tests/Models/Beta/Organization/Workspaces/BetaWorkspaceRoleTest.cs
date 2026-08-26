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
    [InlineData(BetaWorkspaceRole.WorkspaceAdmin)]
    [InlineData(BetaWorkspaceRole.WorkspaceBilling)]
    [InlineData(BetaWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(BetaWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(BetaWorkspaceRole.WorkspaceUser)]
    public void SerializationRoundtrip_Works(BetaWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
