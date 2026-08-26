using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Invites;

[JsonConverter(typeof(JsonModelConverter<InviteDeleteResponse, InviteDeleteResponseFromRaw>))]
public sealed record class InviteDeleteResponse : JsonModel
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
    /// Deleted object type.
    ///
    /// <para>For Invites, this is always `"invite_deleted"`.</para>
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("invite_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InviteDeleteResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("invite_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteDeleteResponse(InviteDeleteResponse inviteDeleteResponse)
        : base(inviteDeleteResponse) { }
#pragma warning restore CS8618

    public InviteDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invite_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InviteDeleteResponseFromRaw.FromRawUnchecked"/>
    public static InviteDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InviteDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class InviteDeleteResponseFromRaw : IFromRawJson<InviteDeleteResponse>
{
    /// <inheritdoc/>
    public InviteDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InviteDeleteResponse.FromRawUnchecked(rawData);
}
