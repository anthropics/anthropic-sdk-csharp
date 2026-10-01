using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

[JsonConverter(typeof(JsonModelConverter<OrganizationInvite, OrganizationInviteFromRaw>))]
public sealed record class OrganizationInvite : JsonModel
{
    /// <summary>
    /// ID of the Invite.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string indicating when the Invite was accepted, or null.
    /// </summary>
    public required DateTimeOffset? AcceptedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("accepted_at");
        }
        init { this._rawData.Set("accepted_at", value); }
    }

    /// <summary>
    /// Email of the User being invited.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string indicating when the Invite expires.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string indicating when the Invite was created.
    /// </summary>
    public required DateTimeOffset InvitedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("invited_at");
        }
        init { this._rawData.Set("invited_at", value); }
    }

    /// <summary>
    /// RBAC group IDs recorded on the Invite (Claude Enterprise organizations),
    /// to be assigned to the User when the Invite is accepted. `[]` when none.
    /// </summary>
    public required IReadOnlyList<string> RbacGroupIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("rbac_group_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "rbac_group_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Organization role of the User.
    /// </summary>
    public required ApiEnum<string, OrganizationRole> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OrganizationRole>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Status of the Invite.
    /// </summary>
    public required ApiEnum<string, OrganizationInviteStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OrganizationInviteStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Invites, this is always `"invite"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AcceptedAt;
        _ = this.Email;
        _ = this.ExpiresAt;
        _ = this.InvitedAt;
        _ = this.RbacGroupIds;
        this.Role.Validate();
        this.Status.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("invite")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationInvite()
    {
        this.Type = JsonSerializer.SerializeToElement("invite");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationInvite(OrganizationInvite organizationInvite)
        : base(organizationInvite) { }
#pragma warning restore CS8618

    public OrganizationInvite(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invite");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationInvite(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationInviteFromRaw.FromRawUnchecked"/>
    public static OrganizationInvite FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationInviteFromRaw : IFromRawJson<OrganizationInvite>
{
    /// <inheritdoc/>
    public OrganizationInvite FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrganizationInvite.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the Invite.
/// </summary>
[JsonConverter(typeof(OrganizationInviteStatusConverter))]
public enum OrganizationInviteStatus
{
    Accepted,
    Deleted,
    Expired,
    Pending,
}

sealed class OrganizationInviteStatusConverter : JsonConverter<OrganizationInviteStatus>
{
    public override OrganizationInviteStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "accepted" => OrganizationInviteStatus.Accepted,
            "deleted" => OrganizationInviteStatus.Deleted,
            "expired" => OrganizationInviteStatus.Expired,
            "pending" => OrganizationInviteStatus.Pending,
            _ => (OrganizationInviteStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OrganizationInviteStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OrganizationInviteStatus.Accepted => "accepted",
                OrganizationInviteStatus.Deleted => "deleted",
                OrganizationInviteStatus.Expired => "expired",
                OrganizationInviteStatus.Pending => "pending",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
