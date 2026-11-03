using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The request combines `thread` with a request field or an organization setting
/// that Threads do not support; `unsupported`, when present, names it. Send the
/// full conversation without `thread`, or change that field.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ThreadUnsupportedRequestErrorDetails,
        ThreadUnsupportedRequestErrorDetailsFromRaw
    >)
)]
public sealed record class ThreadUnsupportedRequestErrorDetails : JsonModel
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

    /// <summary>
    /// Each entry names a request field or an organization setting that Threads
    /// do not support. On a value you do not recognize, send the full conversation
    /// without `thread`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ThreadUnsupportedFeatureName>>? Unsupported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ThreadUnsupportedFeatureName>>
            >("unsupported");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ThreadUnsupportedFeatureName>>?>(
                "unsupported",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("thread_unsupported_request")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Unsupported ?? [])
        {
            item.Validate();
        }
    }

    public ThreadUnsupportedRequestErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("thread_unsupported_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThreadUnsupportedRequestErrorDetails(
        ThreadUnsupportedRequestErrorDetails threadUnsupportedRequestErrorDetails
    )
        : base(threadUnsupportedRequestErrorDetails) { }
#pragma warning restore CS8618

    public ThreadUnsupportedRequestErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("thread_unsupported_request");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThreadUnsupportedRequestErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThreadUnsupportedRequestErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ThreadUnsupportedRequestErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThreadUnsupportedRequestErrorDetailsFromRaw
    : IFromRawJson<ThreadUnsupportedRequestErrorDetails>
{
    /// <inheritdoc/>
    public ThreadUnsupportedRequestErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThreadUnsupportedRequestErrorDetails.FromRawUnchecked(rawData);
}
