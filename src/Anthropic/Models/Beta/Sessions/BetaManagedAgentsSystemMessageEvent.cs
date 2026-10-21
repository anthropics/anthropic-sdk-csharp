using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// A mid-conversation system message event. Carries system-role content that is
/// appended to the session as a `role: "system"` turn.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSystemMessageEvent,
        BetaManagedAgentsSystemMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSystemMessageEvent : JsonModel
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
    /// System content blocks. Text-only.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSystemContentBlock> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSystemContentBlock>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSystemContentBlock>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <summary>
    /// Timestamp when this system message was processed.
    /// </summary>
    public DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("system.message")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ProcessedAt;
    }

    public BetaManagedAgentsSystemMessageEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("system.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSystemMessageEvent(
        BetaManagedAgentsSystemMessageEvent betaManagedAgentsSystemMessageEvent
    )
        : base(betaManagedAgentsSystemMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSystemMessageEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("system.message");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSystemMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSystemMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSystemMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSystemMessageEventFromRaw : IFromRawJson<BetaManagedAgentsSystemMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSystemMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSystemMessageEvent.FromRawUnchecked(rawData);
}
