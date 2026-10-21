using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Emitted when a model request is initiated by the agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanModelRequestStartEvent,
        BetaManagedAgentsSpanModelRequestStartEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanModelRequestStartEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
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
    /// Timestamp when the model request started.
    /// </summary>
    public required DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("span.model_request_start")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSpanModelRequestStartEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("span.model_request_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanModelRequestStartEvent(
        BetaManagedAgentsSpanModelRequestStartEvent betaManagedAgentsSpanModelRequestStartEvent
    )
        : base(betaManagedAgentsSpanModelRequestStartEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanModelRequestStartEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("span.model_request_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanModelRequestStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanModelRequestStartEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanModelRequestStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanModelRequestStartEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanModelRequestStartEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanModelRequestStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanModelRequestStartEvent.FromRawUnchecked(rawData);
}
