using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Webhooks;

[JsonConverter(typeof(JsonModelConverter<UnwrapWebhookEvent, UnwrapWebhookEventFromRaw>))]
public sealed record class UnwrapWebhookEvent : JsonModel
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

    public UnwrapWebhookEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("event");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UnwrapWebhookEvent(UnwrapWebhookEvent unwrapWebhookEvent)
        : base(unwrapWebhookEvent) { }
#pragma warning restore CS8618

    public UnwrapWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("event");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnwrapWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UnwrapWebhookEventFromRaw.FromRawUnchecked"/>
    public static UnwrapWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UnwrapWebhookEventFromRaw : IFromRawJson<UnwrapWebhookEvent>
{
    /// <inheritdoc/>
    public UnwrapWebhookEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UnwrapWebhookEvent.FromRawUnchecked(rawData);
}
