using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups.Members;

[JsonConverter(typeof(JsonModelConverter<BetaRbacGroupMember, BetaRbacGroupMemberFromRaw>))]
public sealed record class BetaRbacGroupMember : JsonModel
{
    /// <summary>
    /// RFC 3339 timestamp of when the User was added to the RBAC Group.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Email of the User.
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
    /// ID of the RBAC Group.
    /// </summary>
    public required string RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For RBAC Group Members, this is always `"rbac_group_member"`.</para>
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

    /// <summary>
    /// ID of the User.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Email;
        _ = this.RbacGroupID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("rbac_group_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaRbacGroupMember()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacGroupMember(BetaRbacGroupMember betaRbacGroupMember)
        : base(betaRbacGroupMember) { }
#pragma warning restore CS8618

    public BetaRbacGroupMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacGroupMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacGroupMemberFromRaw.FromRawUnchecked"/>
    public static BetaRbacGroupMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacGroupMemberFromRaw : IFromRawJson<BetaRbacGroupMember>
{
    /// <inheritdoc/>
    public BetaRbacGroupMember FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaRbacGroupMember.FromRawUnchecked(rawData);
}
