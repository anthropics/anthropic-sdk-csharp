using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Resume from the response named by ``previous_message_id``.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaThreadContinueParams, BetaThreadContinueParamsFromRaw>)
)]
public sealed record class BetaThreadContinueParams : JsonModel
{
    /// <summary>
    /// The `id` of the previous response in this Thread.
    /// </summary>
    public required string PreviousMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("previous_message_id");
        }
        init { this._rawData.Set("previous_message_id", value); }
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
        _ = this.PreviousMessageID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("continue")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThreadContinueParams()
    {
        this.Type = JsonSerializer.SerializeToElement("continue");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThreadContinueParams(BetaThreadContinueParams betaThreadContinueParams)
        : base(betaThreadContinueParams) { }
#pragma warning restore CS8618

    public BetaThreadContinueParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("continue");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThreadContinueParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThreadContinueParamsFromRaw.FromRawUnchecked"/>
    public static BetaThreadContinueParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaThreadContinueParams(string previousMessageID)
        : this()
    {
        this.PreviousMessageID = previousMessageID;
    }
}

class BetaThreadContinueParamsFromRaw : IFromRawJson<BetaThreadContinueParams>
{
    /// <inheritdoc/>
    public BetaThreadContinueParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaThreadContinueParams.FromRawUnchecked(rawData);
}
