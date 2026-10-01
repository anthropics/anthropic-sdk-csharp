using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

[JsonConverter(typeof(OrganizationRoleConverter))]
public enum OrganizationRole
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

sealed class OrganizationRoleConverter : JsonConverter<OrganizationRole>
{
    public override OrganizationRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => OrganizationRole.Admin,
            "billing" => OrganizationRole.Billing,
            "claude_code_user" => OrganizationRole.ClaudeCodeUser,
            "developer" => OrganizationRole.Developer,
            "managed" => OrganizationRole.Managed,
            "membership_admin" => OrganizationRole.MembershipAdmin,
            "owner" => OrganizationRole.Owner,
            "primary_owner" => OrganizationRole.PrimaryOwner,
            "user" => OrganizationRole.User,
            _ => (OrganizationRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrganizationRole.Admin => "admin",
                OrganizationRole.Billing => "billing",
                OrganizationRole.ClaudeCodeUser => "claude_code_user",
                OrganizationRole.Developer => "developer",
                OrganizationRole.Managed => "managed",
                OrganizationRole.MembershipAdmin => "membership_admin",
                OrganizationRole.Owner => "owner",
                OrganizationRole.PrimaryOwner => "primary_owner",
                OrganizationRole.User => "user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
