using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(typeof(JsonModelConverter<BetaWebhookEvent, BetaWebhookEventFromRaw>))]
public sealed record class BetaWebhookEvent : JsonModel
{
    /// <summary>
    /// Unique event identifier for idempotency.
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
    /// RFC 3339 timestamp when the event occurred.
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

    public required BetaWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaWebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Object type. Always `event` for webhook payloads.
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
        _ = this.CreatedAt;
        this.Data.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("event")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("event");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebhookEvent(BetaWebhookEvent betaWebhookEvent)
        : base(betaWebhookEvent) { }
#pragma warning restore CS8618

    public BetaWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("event");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebhookEventFromRaw.FromRawUnchecked"/>
    public static BetaWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebhookEventFromRaw : IFromRawJson<BetaWebhookEvent>
{
    /// <inheritdoc/>
    public BetaWebhookEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWebhookEvent.FromRawUnchecked(rawData);
}
