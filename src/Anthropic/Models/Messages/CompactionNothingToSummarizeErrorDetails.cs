using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// `messages` holds no `user` or `assistant` content to summarize or adopt.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionNothingToSummarizeErrorDetails,
        CompactionNothingToSummarizeErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionNothingToSummarizeErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_nothing_to_summarize")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionNothingToSummarizeErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_nothing_to_summarize");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionNothingToSummarizeErrorDetails(
        CompactionNothingToSummarizeErrorDetails compactionNothingToSummarizeErrorDetails
    )
        : base(compactionNothingToSummarizeErrorDetails) { }
#pragma warning restore CS8618

    public CompactionNothingToSummarizeErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_nothing_to_summarize");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionNothingToSummarizeErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionNothingToSummarizeErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionNothingToSummarizeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionNothingToSummarizeErrorDetailsFromRaw
    : IFromRawJson<CompactionNothingToSummarizeErrorDetails>
{
    /// <inheritdoc/>
    public CompactionNothingToSummarizeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionNothingToSummarizeErrorDetails.FromRawUnchecked(rawData);
}
