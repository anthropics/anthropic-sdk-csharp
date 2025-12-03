using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawMessageDeltaEvent, RawMessageDeltaEventFromRaw>))]
public sealed record class RawMessageDeltaEvent : ModelBase
{
    public required Delta Delta
    {
        get { return ModelBase.GetNotNullClass<Delta>(this.RawData, "delta"); }
        init { ModelBase.Set(this._rawData, "delta", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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
        get { return ModelBase.GetNotNullClass<MessageDeltaUsage>(this.RawData, "usage"); }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Delta.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"message_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Usage.Validate();
    }

    public RawMessageDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

    public RawMessageDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class RawMessageDeltaEventFromRaw : IFromRaw<RawMessageDeltaEvent>
{
    /// <inheritdoc/>
    public RawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RawMessageDeltaEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Delta, DeltaFromRaw>))]
public sealed record class Delta : ModelBase
{
    public required ApiEnum<string, StopReason>? StopReason
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, StopReason>>(
                this.RawData,
                "stop_reason"
            );
        }
        init { ModelBase.Set(this._rawData, "stop_reason", value); }
    }

    public required string? StopSequence
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "stop_sequence"); }
        init { ModelBase.Set(this._rawData, "stop_sequence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.StopReason?.Validate();
        _ = this.StopSequence;
    }

    public Delta() { }

    public Delta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeltaFromRaw.FromRawUnchecked"/>
    public static Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeltaFromRaw : IFromRaw<Delta>
{
    /// <inheritdoc/>
    public Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delta.FromRawUnchecked(rawData);
}
