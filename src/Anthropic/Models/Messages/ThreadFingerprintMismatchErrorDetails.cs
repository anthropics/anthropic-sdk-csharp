using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A field that must stay the same across a Thread's turns differs from the value
/// stored with the Thread; the message names each such field. Send the stored values,
/// or replay the full conversation with `thread: {"type": "create"}` to change them.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ThreadFingerprintMismatchErrorDetails,
        ThreadFingerprintMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class ThreadFingerprintMismatchErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("thread_fingerprint_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThreadFingerprintMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("thread_fingerprint_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadFingerprintMismatchErrorDetails(
        ThreadFingerprintMismatchErrorDetails threadFingerprintMismatchErrorDetails
    )
        : base(threadFingerprintMismatchErrorDetails) { }
#pragma warning restore CS8618

    public ThreadFingerprintMismatchErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("thread_fingerprint_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadFingerprintMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThreadFingerprintMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ThreadFingerprintMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThreadFingerprintMismatchErrorDetailsFromRaw
    : IFromRawJson<ThreadFingerprintMismatchErrorDetails>
{
    /// <inheritdoc/>
    public ThreadFingerprintMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThreadFingerprintMismatchErrorDetails.FromRawUnchecked(rawData);
}
