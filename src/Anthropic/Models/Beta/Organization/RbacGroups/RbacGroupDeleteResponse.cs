using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups;

[JsonConverter(typeof(JsonModelConverter<RbacGroupDeleteResponse, RbacGroupDeleteResponseFromRaw>))]
public sealed record class RbacGroupDeleteResponse : JsonModel
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

    public RbacGroupDeleteResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacGroupDeleteResponse(RbacGroupDeleteResponse rbacGroupDeleteResponse)
        : base(rbacGroupDeleteResponse) { }
#pragma warning restore CS8618

    public RbacGroupDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacGroupDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacGroupDeleteResponseFromRaw.FromRawUnchecked"/>
    public static RbacGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RbacGroupDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class RbacGroupDeleteResponseFromRaw : IFromRawJson<RbacGroupDeleteResponse>
{
    /// <inheritdoc/>
    public RbacGroupDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacGroupDeleteResponse.FromRawUnchecked(rawData);
}
