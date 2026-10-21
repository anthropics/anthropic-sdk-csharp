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
    [InlineData(NoBillingWorkspaceRole.WorkspaceAdmin)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceDeveloper)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(NoBillingWorkspaceRole.WorkspaceUser)]
    public void SerializationRoundtrip_Works(NoBillingWorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NoBillingWorkspaceRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NoBillingWorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
