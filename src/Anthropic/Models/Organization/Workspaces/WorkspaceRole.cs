using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

[JsonConverter(typeof(WorkspaceRoleConverter))]
public enum WorkspaceRole
{
    WorkspaceAdmin,
    WorkspaceBilling,
    WorkspaceDeveloper,
    WorkspaceRestrictedDeveloper,
    WorkspaceUser,
}

sealed class WorkspaceRoleConverter : JsonConverter<WorkspaceRole>
{
    public override WorkspaceRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_admin" => WorkspaceRole.WorkspaceAdmin,
            "workspace_billing" => WorkspaceRole.WorkspaceBilling,
            "workspace_developer" => WorkspaceRole.WorkspaceDeveloper,
            "workspace_restricted_developer" => WorkspaceRole.WorkspaceRestrictedDeveloper,
            "workspace_user" => WorkspaceRole.WorkspaceUser,
            _ => (WorkspaceRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WorkspaceRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WorkspaceRole.WorkspaceAdmin => "workspace_admin",
                WorkspaceRole.WorkspaceBilling => "workspace_billing",
                WorkspaceRole.WorkspaceDeveloper => "workspace_developer",
                WorkspaceRole.WorkspaceRestrictedDeveloper => "workspace_restricted_developer",
                WorkspaceRole.WorkspaceUser => "workspace_user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
