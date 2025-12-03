using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(ModelConverter<BetaMessageBatchErroredResult, BetaMessageBatchErroredResultFromRaw>)
)]
public sealed record class BetaMessageBatchErroredResult : ModelBase
{
    public required BetaErrorResponse Error
    {
        get { return ModelBase.GetNotNullClass<BetaErrorResponse>(this.RawData, "error"); }
        init { ModelBase.Set(this._rawData, "error", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"errored\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

    public BetaMessageBatchErroredResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchErroredResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchErroredResultFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMessageBatchErroredResult(BetaErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}

class BetaMessageBatchErroredResultFromRaw : IFromRaw<BetaMessageBatchErroredResult>
{
    /// <inheritdoc/>
    public BetaMessageBatchErroredResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchErroredResult.FromRawUnchecked(rawData);
}
