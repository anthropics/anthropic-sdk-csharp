using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebhookSessionPendingEventData,
        BetaWebhookSessionPendingEventDataFromRaw
    >)
)]
public sealed record class BetaWebhookSessionPendingEventData : JsonModel
{
    /// <summary>
    /// ID of the resource that triggered the event.
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

    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.OrganizationID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session.pending"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWebhookSessionPendingEventData()
    {
        this.Type = JsonSerializer.SerializeToElement("session.pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookSessionPendingEventData(
        BetaWebhookSessionPendingEventData betaWebhookSessionPendingEventData
    )
        : base(betaWebhookSessionPendingEventData) { }
#pragma warning restore CS8618

    public BetaWebhookSessionPendingEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session.pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookSessionPendingEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookSessionPendingEventDataFromRaw.FromRawUnchecked"/>
    public static BetaWebhookSessionPendingEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookSessionPendingEventDataFromRaw : IFromRawJson<BetaWebhookSessionPendingEventData>
{
    /// <inheritdoc/>
    public BetaWebhookSessionPendingEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebhookSessionPendingEventData.FromRawUnchecked(rawData);
}
