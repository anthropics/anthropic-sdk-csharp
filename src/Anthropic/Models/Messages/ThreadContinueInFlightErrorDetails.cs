using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Another request is still continuing from the same `previous_message_id`. Wait
/// for it to complete and continue from its response `id`, or replay the full conversation
/// with `thread: {"type": "create"}`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ThreadContinueInFlightErrorDetails,
        ThreadContinueInFlightErrorDetailsFromRaw
    >)
)]
public sealed record class ThreadContinueInFlightErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("thread_continue_in_flight")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThreadContinueInFlightErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("thread_continue_in_flight");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadContinueInFlightErrorDetails(
        ThreadContinueInFlightErrorDetails threadContinueInFlightErrorDetails
    )
        : base(threadContinueInFlightErrorDetails) { }
#pragma warning restore CS8618

    public ThreadContinueInFlightErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("thread_continue_in_flight");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadContinueInFlightErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThreadContinueInFlightErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ThreadContinueInFlightErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThreadContinueInFlightErrorDetailsFromRaw : IFromRawJson<ThreadContinueInFlightErrorDetails>
{
    /// <inheritdoc/>
    public ThreadContinueInFlightErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThreadContinueInFlightErrorDetails.FromRawUnchecked(rawData);
}
