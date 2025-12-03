using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(ModelConverter<BetaMessageBatchExpiredResult, BetaMessageBatchExpiredResultFromRaw>)
)]
public sealed record class BetaMessageBatchExpiredResult : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"expired\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchExpiredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"expired\"");
    }

    public BetaMessageBatchExpiredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"expired\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchExpiredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaMessageBatchExpiredResultFromRaw : IFromRaw<BetaMessageBatchExpiredResult>
{
    /// <inheritdoc/>
    public BetaMessageBatchExpiredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchExpiredResult.FromRawUnchecked(rawData);
}
