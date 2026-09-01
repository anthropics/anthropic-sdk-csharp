using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// The `output_behavior.memory_store_id` target is still held by a prior `{type:
/// "update_existing"}` dream — one that is `pending` or `running`, or was canceled
/// with its final writes still landing. Rarely the named dream has just finished
/// (`completed`/`failed`) and its execution is still closing; an immediate retry
/// then almost always succeeds. The message names the holding dream when the server
/// can identify it (rarely omitted); poll it to a terminal state or cancel it, then
/// retry. Carried with `x-should-retry: false`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaTargetStoreHeldError, BetaTargetStoreHeldErrorFromRaw>)
)]
public sealed record class BetaTargetStoreHeldError : JsonModel
{
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
    /// Human-readable description of the conflict, naming the dream that holds the
    /// target store when the server can identify it.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("conflict_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Message;
    }

    public BetaTargetStoreHeldError()
    {
        this.Type = JsonSerializer.SerializeToElement("conflict_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTargetStoreHeldError(BetaTargetStoreHeldError betaTargetStoreHeldError)
        : base(betaTargetStoreHeldError) { }
#pragma warning restore CS8618

    public BetaTargetStoreHeldError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("conflict_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTargetStoreHeldError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTargetStoreHeldErrorFromRaw.FromRawUnchecked"/>
    public static BetaTargetStoreHeldError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTargetStoreHeldErrorFromRaw : IFromRawJson<BetaTargetStoreHeldError>
{
    /// <inheritdoc/>
    public BetaTargetStoreHeldError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTargetStoreHeldError.FromRawUnchecked(rawData);
}
