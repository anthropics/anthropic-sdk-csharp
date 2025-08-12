using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// This is a single line in the response `.jsonl` file and does not represent the
/// response as a whole.
/// </summary>
[JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchIndividualResponse>))]
public sealed record class BetaMessageBatchIndividualResponse
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchIndividualResponse>
{
    /// <summary>
    /// Developer-provided ID created for each request in a Message Batch. Useful
    /// for matching results to requests, as results may be given out of request order.
    ///
    /// Must be unique for each request within the Message Batch.
    /// </summary>
    public required string CustomID
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "custom_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("custom_id");
        }
        set { this.Properties["custom_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Processing result for this request.
    ///
    /// Contains a Message output if processing was successful, an error response
    /// if processing failed, or the reason why processing was not attempted, such
    /// as cancellation or expiration.
    /// </summary>
    public required BetaMessageBatchResult Result
    {
        get
        {
            if (!this.Properties.TryGetValue("result", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "result",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaMessageBatchResult>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("result");
        }
        set { this.Properties["result"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CustomID;
        this.Result.Validate();
    }

    public BetaMessageBatchIndividualResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchIndividualResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchIndividualResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
