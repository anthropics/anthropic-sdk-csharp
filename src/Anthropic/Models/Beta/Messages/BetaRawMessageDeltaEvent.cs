using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaRawMessageDeltaEvent, BetaRawMessageDeltaEventFromRaw>)
)]
public sealed record class BetaRawMessageDeltaEvent : JsonModel
{
    /// <summary>
    /// Information about context management strategies applied during the request
    /// </summary>
    public required BetaContextManagementResponse? ContextManagement
    {
        get
        {
            return JsonModel.GetNullableClass<BetaContextManagementResponse>(
                this.RawData,
                "context_management"
            );
        }
        init { JsonModel.Set(this._rawData, "context_management", value); }
    }

    public required Delta Delta
    {
        get { return JsonModel.GetNotNullClass<Delta>(this.RawData, "delta"); }
        init { JsonModel.Set(this._rawData, "delta", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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
    public required BetaMessageDeltaUsage Usage
    {
        get { return JsonModel.GetNotNullClass<BetaMessageDeltaUsage>(this.RawData, "usage"); }
        init { JsonModel.Set(this._rawData, "usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContextManagement?.Validate();
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

    public BetaRawMessageDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

    public BetaRawMessageDeltaEvent(BetaRawMessageDeltaEvent betaRawMessageDeltaEvent)
        : base(betaRawMessageDeltaEvent) { }

    public BetaRawMessageDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawMessageDeltaEventFromRaw.FromRawUnchecked"/>
    public static BetaRawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRawMessageDeltaEventFromRaw : IFromRawJson<BetaRawMessageDeltaEvent>
{
    /// <inheritdoc/>
    public BetaRawMessageDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawMessageDeltaEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Delta, DeltaFromRaw>))]
public sealed record class Delta : JsonModel
{
    /// <summary>
    /// Information about the container used in the request (for the code execution tool)
    /// </summary>
    public required BetaContainer? Container
    {
        get { return JsonModel.GetNullableClass<BetaContainer>(this.RawData, "container"); }
        init { JsonModel.Set(this._rawData, "container", value); }
    }

    public required ApiEnum<string, BetaStopReason>? StopReason
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, BetaStopReason>>(
                this.RawData,
                "stop_reason"
            );
        }
        init { JsonModel.Set(this._rawData, "stop_reason", value); }
    }

    public required string? StopSequence
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "stop_sequence"); }
        init { JsonModel.Set(this._rawData, "stop_sequence", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Container?.Validate();
        this.StopReason?.Validate();
        _ = this.StopSequence;
    }

    public Delta() { }

    public Delta(Delta delta)
        : base(delta) { }

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

class DeltaFromRaw : IFromRawJson<Delta>
{
    /// <inheritdoc/>
    public Delta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delta.FromRawUnchecked(rawData);
}
