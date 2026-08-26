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
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceAdmin)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(BetaNoBillingWorkspaceRole.WorkspaceUser)]
    public void SerializationRoundtrip_Works(BetaNoBillingWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaNoBillingWorkspaceRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaNoBillingWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
