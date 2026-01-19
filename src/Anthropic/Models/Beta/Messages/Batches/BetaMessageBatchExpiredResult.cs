using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<BetaMessageBatchExpiredResult, BetaMessageBatchExpiredResultFromRaw>)
)]
public sealed record class BetaMessageBatchExpiredResult : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("expired")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchExpiredResult()
    {
        this.Type = JsonSerializer.SerializeToElement("expired");
    }

    public BetaMessageBatchExpiredResult(
        BetaMessageBatchExpiredResult betaMessageBatchExpiredResult
    )
        : base(betaMessageBatchExpiredResult) { }

    public BetaMessageBatchExpiredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("expired");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchExpiredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchExpiredResultFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchExpiredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchExpiredResultFromRaw : IFromRawJson<BetaMessageBatchExpiredResult>
{
    /// <inheritdoc/>
    public BetaMessageBatchExpiredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchExpiredResult.FromRawUnchecked(rawData);
}
