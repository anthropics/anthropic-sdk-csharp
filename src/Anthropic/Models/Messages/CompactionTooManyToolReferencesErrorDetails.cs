using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The conversation references more distinct tools than a `compaction` block can record.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionTooManyToolReferencesErrorDetails,
        CompactionTooManyToolReferencesErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionTooManyToolReferencesErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_too_many_tool_references")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionTooManyToolReferencesErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_too_many_tool_references");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionTooManyToolReferencesErrorDetails(
        CompactionTooManyToolReferencesErrorDetails compactionTooManyToolReferencesErrorDetails
    )
        : base(compactionTooManyToolReferencesErrorDetails) { }
#pragma warning restore CS8618

    public CompactionTooManyToolReferencesErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_too_many_tool_references");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionTooManyToolReferencesErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionTooManyToolReferencesErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionTooManyToolReferencesErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionTooManyToolReferencesErrorDetailsFromRaw
    : IFromRawJson<CompactionTooManyToolReferencesErrorDetails>
{
    /// <inheritdoc/>
    public CompactionTooManyToolReferencesErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionTooManyToolReferencesErrorDetails.FromRawUnchecked(rawData);
}
