using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// No usable Thread state was found for `previous_message_id`. Replay the full conversation
/// with `thread: {"type": "create"}` to start a new Thread.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ThreadNotFoundErrorDetails, ThreadNotFoundErrorDetailsFromRaw>)
)]
public sealed record class ThreadNotFoundErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("thread_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThreadNotFoundErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("thread_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadNotFoundErrorDetails(ThreadNotFoundErrorDetails threadNotFoundErrorDetails)
        : base(threadNotFoundErrorDetails) { }
#pragma warning restore CS8618

    public ThreadNotFoundErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("thread_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadNotFoundErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThreadNotFoundErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ThreadNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThreadNotFoundErrorDetailsFromRaw : IFromRawJson<ThreadNotFoundErrorDetails>
{
    /// <inheritdoc/>
    public ThreadNotFoundErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThreadNotFoundErrorDetails.FromRawUnchecked(rawData);
}
