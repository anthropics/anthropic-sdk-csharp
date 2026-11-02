using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups.Members;

[JsonConverter(
    typeof(JsonModelConverter<BetaDeletedRbacGroupMember, BetaDeletedRbacGroupMemberFromRaw>)
)]
public sealed record class BetaDeletedRbacGroupMember : JsonModel
{
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
    /// Deleted object type. For RBAC Group Members, this is always `"rbac_group_member_deleted"`.
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
        _ = this.RbacGroupID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("rbac_group_member_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UserID;
    }

    public BetaDeletedRbacGroupMember()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedRbacGroupMember(BetaDeletedRbacGroupMember betaDeletedRbacGroupMember)
        : base(betaDeletedRbacGroupMember) { }
#pragma warning restore CS8618

    public BetaDeletedRbacGroupMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedRbacGroupMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedRbacGroupMemberFromRaw.FromRawUnchecked"/>
    public static BetaDeletedRbacGroupMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDeletedRbacGroupMemberFromRaw : IFromRawJson<BetaDeletedRbacGroupMember>
{
    /// <inheritdoc/>
    public BetaDeletedRbacGroupMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedRbacGroupMember.FromRawUnchecked(rawData);
}
