using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// This is a single line in the response `.jsonl` file and does not represent the
/// response as a whole.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        BetaMessageBatchIndividualResponse,
        BetaMessageBatchIndividualResponseFromRaw
    >)
)]
public sealed record class BetaMessageBatchIndividualResponse : ModelBase
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// <para>Must be unique for each request within the Message Batch.</para>
    /// </summary>
    public required string CustomID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "custom_id"); }
        init { ModelBase.Set(this._rawData, "custom_id", value); }
    }

    /// <summary>
    /// Processing result for this request.
    ///
    /// <para>Contains a Message output if processing was successful, an error response
    /// if processing failed, or the reason why processing was not attempted, such
    /// as cancellation or expiration.</para>
    /// </summary>
    public required BetaMessageBatchResult Result
    {
        get { return ModelBase.GetNotNullClass<BetaMessageBatchResult>(this.RawData, "result"); }
        init { ModelBase.Set(this._rawData, "result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomID;
        this.Result.Validate();
    }

    public BetaMessageBatchIndividualResponse() { }

    public BetaMessageBatchIndividualResponse(
        BetaMessageBatchIndividualResponse betaMessageBatchIndividualResponse
    )
        : base(betaMessageBatchIndividualResponse) { }

    public BetaMessageBatchIndividualResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchIndividualResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMessageBatchIndividualResponseFromRaw.FromRawUnchecked"/>
    public static BetaMessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchIndividualResponseFromRaw : IFromRaw<BetaMessageBatchIndividualResponse>
{
    /// <inheritdoc/>
    public BetaMessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchIndividualResponse.FromRawUnchecked(rawData);
}
