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
/// Emitted when a model request completes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanModelRequestEndEvent,
        BetaManagedAgentsSpanModelRequestEndEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanModelRequestEndEvent : JsonModel
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
    /// Whether the model request resulted in an error.
    /// </summary>
    public required bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    /// <summary>
    /// The id of the corresponding `span.model_request_start` event.
    /// </summary>
    public required string ModelRequestStartID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model_request_start_id");
        }
        init { this._rawData.Set("model_request_start_id", value); }
    }

    /// <summary>
    /// Token usage for this model request.
    /// </summary>
    public required BetaManagedAgentsSpanModelUsage ModelUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSpanModelUsage>("model_usage");
        }
        init { this._rawData.Set("model_usage", value); }
    }

    /// <summary>
    /// Timestamp when the model request completed.
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
        _ = this.IsError;
        _ = this.ModelRequestStartID;
        this.ModelUsage.Validate();
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("span.model_request_end")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSpanModelRequestEndEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("span.model_request_end");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanModelRequestEndEvent(
        BetaManagedAgentsSpanModelRequestEndEvent betaManagedAgentsSpanModelRequestEndEvent
    )
        : base(betaManagedAgentsSpanModelRequestEndEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanModelRequestEndEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("span.model_request_end");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanModelRequestEndEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanModelRequestEndEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanModelRequestEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanModelRequestEndEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanModelRequestEndEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanModelRequestEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanModelRequestEndEvent.FromRawUnchecked(rawData);
}
