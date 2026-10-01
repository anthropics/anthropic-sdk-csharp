using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(typeof(NoBillingWorkspaceRoleConverter))]
public enum NoBillingWorkspaceRole
{
    WorkspaceAdmin,
    WorkspaceDeveloper,
    WorkspaceRestrictedDeveloper,
    WorkspaceUser,
}

sealed class NoBillingWorkspaceRoleConverter : JsonConverter<NoBillingWorkspaceRole>
{
    public override NoBillingWorkspaceRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_admin" => NoBillingWorkspaceRole.WorkspaceAdmin,
            "workspace_developer" => NoBillingWorkspaceRole.WorkspaceDeveloper,
            "workspace_restricted_developer" => NoBillingWorkspaceRole.WorkspaceRestrictedDeveloper,
            "workspace_user" => NoBillingWorkspaceRole.WorkspaceUser,
            _ => (NoBillingWorkspaceRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoBillingWorkspaceRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NoBillingWorkspaceRole.WorkspaceAdmin => "workspace_admin",
                NoBillingWorkspaceRole.WorkspaceDeveloper => "workspace_developer",
                NoBillingWorkspaceRole.WorkspaceRestrictedDeveloper =>
                    "workspace_restricted_developer",
                NoBillingWorkspaceRole.WorkspaceUser => "workspace_user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
