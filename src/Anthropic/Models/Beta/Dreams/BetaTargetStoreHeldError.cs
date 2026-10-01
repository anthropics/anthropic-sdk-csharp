using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Returned with status 409 when a request to create a dream sets `output_behavior`
/// to `update_existing` and another dream that writes into the same memory store
/// hasn't fully stopped.
///
/// <para>The other dream is `pending` or `running`, or it has just stopped and is
/// still finishing its last writes. `message` gives the ID of the other dream when
/// the server can identify it. If that dream has already reached `completed`, `failed`,
/// or `canceled`, retry after a short wait. Otherwise, wait for the other dream
/// to end or cancel it, then retry. The response sets the `x-should-retry` header
/// to `false`.</para>
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
    /// A human-readable explanation of why the memory store can't be used yet, with
    /// the ID of the dream that is using it when the server can identify it.
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
