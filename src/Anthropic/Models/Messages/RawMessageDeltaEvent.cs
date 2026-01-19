using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RawMessageDeltaEvent, RawMessageDeltaEventFromRaw>))]
public sealed record class RawMessageDeltaEvent : JsonModel
{
    public required Delta Delta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Delta>("delta");
        }
        init { this._rawData.Set("delta", value); }
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
    /// Billing and rate-limit usage.
    ///
    /// <para>Anthropic's API bills and rate-limits by token counts, as tokens represent
    /// the underlying cost to our systems.</para>
    ///
    /// <para>Under the hood, the API transforms requests into a format suitable for
    /// the model. The model's output then goes through a parsing stage before becoming
    /// an API response. As a result, the token counts in `usage` will not match one-to-one
    /// with the exact visible content of an API request or response.</para>
    ///
    /// <para>For example, `output_tokens` will be non-zero, even for an empty string
    /// response from Claude.</para>
    ///
    /// <para>Total input tokens in a request is the summation of `input_tokens`,
    /// `cache_creation_input_tokens`, and `cache_read_input_tokens`.</para>
    /// </summary>
    public required MessageDeltaUsage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessageDeltaUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Delta.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("message_delta")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Usage.Validate();
    }

    public RawMessageDeltaEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("message_delta");
    }

    public RawMessageDeltaEvent(RawMessageDeltaEvent rawMessageDeltaEvent)
        : base(rawMessageDeltaEvent) { }

    public RawMessageDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RawMessageDeltaEventFromRaw.FromRawUnchecked"/>
    public static RawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RawMessageDeltaEventFromRaw : IFromRawJson<RawMessageDeltaEvent>
{
    /// <inheritdoc/>
    public RawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RawMessageDeltaEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Delta, DeltaFromRaw>))]
public sealed record class Delta : JsonModel
{
    public required ApiEnum<string, StopReason>? StopReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StopReason>>("stop_reason");
        }
        init { this._rawData.Set("stop_reason", value); }
    }

    public required string? StopSequence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stop_sequence");
        }
        init { this._rawData.Set("stop_sequence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.StopReason?.Validate();
        _ = this.StopSequence;
    }

    public Delta() { }

    public Delta(Delta delta)
        : base(delta) { }

    public Delta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeltaFromRaw.FromRawUnchecked"/>
    public static Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeltaFromRaw : IFromRawJson<Delta>
{
    /// <inheritdoc/>
    public Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delta.FromRawUnchecked(rawData);
}
