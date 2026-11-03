using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The `compaction` block's `content` differs from the text its `signature` recorded.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionContentMismatchErrorDetails,
        CompactionContentMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionContentMismatchErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_content_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionContentMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_content_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionContentMismatchErrorDetails(
        CompactionContentMismatchErrorDetails compactionContentMismatchErrorDetails
    )
        : base(compactionContentMismatchErrorDetails) { }
#pragma warning restore CS8618

    public CompactionContentMismatchErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_content_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionContentMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionContentMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionContentMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionContentMismatchErrorDetailsFromRaw
    : IFromRawJson<CompactionContentMismatchErrorDetails>
{
    /// <inheritdoc/>
    public CompactionContentMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionContentMismatchErrorDetails.FromRawUnchecked(rawData);
}
