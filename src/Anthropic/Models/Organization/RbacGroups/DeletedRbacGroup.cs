using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacGroups;

[JsonConverter(typeof(JsonModelConverter<DeletedRbacGroup, DeletedRbacGroupFromRaw>))]
public sealed record class DeletedRbacGroup : JsonModel
{
    /// <summary>
    /// ID of the RBAC Group.
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
    /// Deleted object type.
    ///
    /// <para>For RBAC Groups, this is always `"rbac_group_deleted"`.</para>
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("rbac_group_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public DeletedRbacGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeletedRbacGroup(DeletedRbacGroup deletedRbacGroup)
        : base(deletedRbacGroup) { }
#pragma warning restore CS8618

    public DeletedRbacGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeletedRbacGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeletedRbacGroupFromRaw.FromRawUnchecked"/>
    public static DeletedRbacGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeletedRbacGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class DeletedRbacGroupFromRaw : IFromRawJson<DeletedRbacGroup>
{
    /// <inheritdoc/>
    public DeletedRbacGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeletedRbacGroup.FromRawUnchecked(rawData);
}
