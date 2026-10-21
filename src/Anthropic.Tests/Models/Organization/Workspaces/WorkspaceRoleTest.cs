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
    [InlineData(WorkspaceRole.WorkspaceAdmin)]
    [InlineData(WorkspaceRole.WorkspaceBilling)]
    [InlineData(WorkspaceRole.WorkspaceDeveloper)]
    [InlineData(WorkspaceRole.WorkspaceRestrictedDeveloper)]
    [InlineData(WorkspaceRole.WorkspaceUser)]
    public void SerializationRoundtrip_Works(WorkspaceRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WorkspaceRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WorkspaceRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
