using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

[JsonConverter(typeof(BetaOrganizationRoleConverter))]
public enum BetaOrganizationRole
{
    Admin,
    Billing,
    ClaudeCodeUser,
    Developer,
    Managed,
    MembershipAdmin,
    Owner,
    PrimaryOwner,
    User,
}

sealed class BetaOrganizationRoleConverter : JsonConverter<BetaOrganizationRole>
{
    public override BetaOrganizationRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => BetaOrganizationRole.Admin,
            "billing" => BetaOrganizationRole.Billing,
            "claude_code_user" => BetaOrganizationRole.ClaudeCodeUser,
            "developer" => BetaOrganizationRole.Developer,
            "managed" => BetaOrganizationRole.Managed,
            "membership_admin" => BetaOrganizationRole.MembershipAdmin,
            "owner" => BetaOrganizationRole.Owner,
            "primary_owner" => BetaOrganizationRole.PrimaryOwner,
            "user" => BetaOrganizationRole.User,
            _ => (BetaOrganizationRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOrganizationRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOrganizationRole.Admin => "admin",
                BetaOrganizationRole.Billing => "billing",
                BetaOrganizationRole.ClaudeCodeUser => "claude_code_user",
                BetaOrganizationRole.Developer => "developer",
                BetaOrganizationRole.Managed => "managed",
                BetaOrganizationRole.MembershipAdmin => "membership_admin",
                BetaOrganizationRole.Owner => "owner",
                BetaOrganizationRole.PrimaryOwner => "primary_owner",
                BetaOrganizationRole.User => "user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
