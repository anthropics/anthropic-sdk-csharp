using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The `compaction` block's `tool_changes` differs from what was returned with the block.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionToolChangesMismatchErrorDetails,
        CompactionToolChangesMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionToolChangesMismatchErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_tool_changes_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionToolChangesMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_tool_changes_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionToolChangesMismatchErrorDetails(
        CompactionToolChangesMismatchErrorDetails compactionToolChangesMismatchErrorDetails
    )
        : base(compactionToolChangesMismatchErrorDetails) { }
#pragma warning restore CS8618

    public CompactionToolChangesMismatchErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_tool_changes_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionToolChangesMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionToolChangesMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionToolChangesMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionToolChangesMismatchErrorDetailsFromRaw
    : IFromRawJson<CompactionToolChangesMismatchErrorDetails>
{
    /// <inheritdoc/>
    public CompactionToolChangesMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionToolChangesMismatchErrorDetails.FromRawUnchecked(rawData);
}
