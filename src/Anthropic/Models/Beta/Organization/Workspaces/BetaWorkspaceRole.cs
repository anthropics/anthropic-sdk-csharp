using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaWorkspaceRoleConverter))]
public enum BetaWorkspaceRole
{
    WorkspaceAdmin,
    WorkspaceBilling,
    WorkspaceDeveloper,
    WorkspaceRestrictedDeveloper,
    WorkspaceUser,
}

sealed class BetaWorkspaceRoleConverter : JsonConverter<BetaWorkspaceRole>
{
    public override BetaWorkspaceRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_admin" => BetaWorkspaceRole.WorkspaceAdmin,
            "workspace_billing" => BetaWorkspaceRole.WorkspaceBilling,
            "workspace_developer" => BetaWorkspaceRole.WorkspaceDeveloper,
            "workspace_restricted_developer" => BetaWorkspaceRole.WorkspaceRestrictedDeveloper,
            "workspace_user" => BetaWorkspaceRole.WorkspaceUser,
            _ => (BetaWorkspaceRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkspaceRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkspaceRole.WorkspaceAdmin => "workspace_admin",
                BetaWorkspaceRole.WorkspaceBilling => "workspace_billing",
                BetaWorkspaceRole.WorkspaceDeveloper => "workspace_developer",
                BetaWorkspaceRole.WorkspaceRestrictedDeveloper => "workspace_restricted_developer",
                BetaWorkspaceRole.WorkspaceUser => "workspace_user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
