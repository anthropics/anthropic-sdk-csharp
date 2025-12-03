using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(ModelConverter<BetaMessageBatchCanceledResult, BetaMessageBatchCanceledResultFromRaw>)
)]
public sealed record class BetaMessageBatchCanceledResult : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"canceled\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchCanceledResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");
    }

    public BetaMessageBatchCanceledResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"canceled\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchCanceledResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchCanceledResultFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchCanceledResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchCanceledResultFromRaw : IFromRaw<BetaMessageBatchCanceledResult>
{
    /// <inheritdoc/>
    public BetaMessageBatchCanceledResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchCanceledResult.FromRawUnchecked(rawData);
}
