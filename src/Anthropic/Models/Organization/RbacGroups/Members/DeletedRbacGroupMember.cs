using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacGroups.Members;

[JsonConverter(typeof(JsonModelConverter<DeletedRbacGroupMember, DeletedRbacGroupMemberFromRaw>))]
public sealed record class DeletedRbacGroupMember : JsonModel
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

    public DeletedRbacGroupMember()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedRbacGroupMember(DeletedRbacGroupMember deletedRbacGroupMember)
        : base(deletedRbacGroupMember) { }
#pragma warning restore CS8618

    public DeletedRbacGroupMember(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedRbacGroupMember(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedRbacGroupMemberFromRaw.FromRawUnchecked"/>
    public static DeletedRbacGroupMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeletedRbacGroupMemberFromRaw : IFromRawJson<DeletedRbacGroupMember>
{
    /// <inheritdoc/>
    public DeletedRbacGroupMember FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeletedRbacGroupMember.FromRawUnchecked(rawData);
}
