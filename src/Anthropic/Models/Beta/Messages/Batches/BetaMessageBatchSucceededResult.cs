using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaMessageBatchSucceededResult,
        BetaMessageBatchSucceededResultFromRaw
    >)
)]
public sealed record class BetaMessageBatchSucceededResult : JsonModel
{
    public required BetaMessage Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaMessage>("message");
        }
        init { this._rawData.Set("message", value); }
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
        this.Message.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"succeeded\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaMessageBatchSucceededResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

    public BetaMessageBatchSucceededResult(
        BetaMessageBatchSucceededResult betaMessageBatchSucceededResult
    )
        : base(betaMessageBatchSucceededResult) { }

    public BetaMessageBatchSucceededResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchSucceededResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchSucceededResultFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMessageBatchSucceededResult(BetaMessage message)
        : this()
    {
        this.Message = message;
    }
}

class BetaMessageBatchSucceededResultFromRaw : IFromRawJson<BetaMessageBatchSucceededResult>
{
    /// <inheritdoc/>
    public BetaMessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchSucceededResult.FromRawUnchecked(rawData);
}
