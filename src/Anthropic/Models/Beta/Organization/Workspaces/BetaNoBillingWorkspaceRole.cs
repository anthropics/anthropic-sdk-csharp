using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(BetaNoBillingWorkspaceRoleConverter))]
public enum BetaNoBillingWorkspaceRole
{
    WorkspaceAdmin,
    WorkspaceDeveloper,
    WorkspaceRestrictedDeveloper,
    WorkspaceUser,
}

sealed class BetaNoBillingWorkspaceRoleConverter : JsonConverter<BetaNoBillingWorkspaceRole>
{
    public override BetaNoBillingWorkspaceRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_admin" => BetaNoBillingWorkspaceRole.WorkspaceAdmin,
            "workspace_developer" => BetaNoBillingWorkspaceRole.WorkspaceDeveloper,
            "workspace_restricted_developer" =>
                BetaNoBillingWorkspaceRole.WorkspaceRestrictedDeveloper,
            "workspace_user" => BetaNoBillingWorkspaceRole.WorkspaceUser,
            _ => (BetaNoBillingWorkspaceRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaNoBillingWorkspaceRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaNoBillingWorkspaceRole.WorkspaceAdmin => "workspace_admin",
                BetaNoBillingWorkspaceRole.WorkspaceDeveloper => "workspace_developer",
                BetaNoBillingWorkspaceRole.WorkspaceRestrictedDeveloper =>
                    "workspace_restricted_developer",
                BetaNoBillingWorkspaceRole.WorkspaceUser => "workspace_user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
