using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// This is a single line in the response `.jsonl` file and does not represent the
/// response as a whole.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MessageBatchIndividualResponse,
        MessageBatchIndividualResponseFromRaw
    >)
)]
public sealed record class MessageBatchIndividualResponse : JsonModel
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// <para>Must be unique for each request within the Message Batch.</para>
    /// </summary>
    public required string CustomID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "custom_id"); }
        init { JsonModel.Set(this._rawData, "custom_id", value); }
    }

    /// <summary>
    /// Processing result for this request.
    ///
    /// <para>Contains a Message output if processing was successful, an error response
    /// if processing failed, or the reason why processing was not attempted, such
    /// as cancellation or expiration.</para>
    /// </summary>
    public required MessageBatchResult Result
    {
        get { return JsonModel.GetNotNullClass<MessageBatchResult>(this.RawData, "result"); }
        init { JsonModel.Set(this._rawData, "result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomID;
        this.Result.Validate();
    }

    public MessageBatchIndividualResponse() { }

    public MessageBatchIndividualResponse(
        MessageBatchIndividualResponse messageBatchIndividualResponse
    )
        : base(messageBatchIndividualResponse) { }

    public MessageBatchIndividualResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchIndividualResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageBatchIndividualResponseFromRaw.FromRawUnchecked"/>
    public static MessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageBatchIndividualResponseFromRaw : IFromRawJson<MessageBatchIndividualResponse>
{
    /// <inheritdoc/>
    public MessageBatchIndividualResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageBatchIndividualResponse.FromRawUnchecked(rawData);
}
