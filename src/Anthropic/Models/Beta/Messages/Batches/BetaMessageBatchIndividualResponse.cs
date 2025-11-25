using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        get
        {
            if (!this._rawData.TryGetValue("custom_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new ArgumentOutOfRangeException("custom_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'custom_id' cannot be null",
                    new ArgumentNullException("custom_id")
                );
        }
        init
        {
            this._rawData["custom_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        get
        {
            if (!this._rawData.TryGetValue("result", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'result' cannot be null",
                    new ArgumentOutOfRangeException("result", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaMessageBatchResult>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'result' cannot be null",
                    new ArgumentNullException("result")
                );
        }
        init
        {
            this._rawData["result"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CustomID;
        this.Result.Validate();
    }

    public BetaMessageBatchIndividualResponse() { }

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

    public static BetaMessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMessageBatchIndividualResponseFromRaw : IFromRaw<BetaMessageBatchIndividualResponse>
{
    public BetaMessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMessageBatchIndividualResponse.FromRawUnchecked(rawData);
}
