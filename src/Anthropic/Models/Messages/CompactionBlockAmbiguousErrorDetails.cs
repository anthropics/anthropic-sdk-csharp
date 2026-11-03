using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// `messages` holds more than one `compaction` block with content. Send only the
/// block the conversation returned last.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionBlockAmbiguousErrorDetails,
        CompactionBlockAmbiguousErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionBlockAmbiguousErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_block_ambiguous")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionBlockAmbiguousErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_block_ambiguous");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionBlockAmbiguousErrorDetails(
        CompactionBlockAmbiguousErrorDetails compactionBlockAmbiguousErrorDetails
    )
        : base(compactionBlockAmbiguousErrorDetails) { }
#pragma warning restore CS8618

    public CompactionBlockAmbiguousErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_block_ambiguous");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionBlockAmbiguousErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionBlockAmbiguousErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionBlockAmbiguousErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionBlockAmbiguousErrorDetailsFromRaw
    : IFromRawJson<CompactionBlockAmbiguousErrorDetails>
{
    /// <inheritdoc/>
    public CompactionBlockAmbiguousErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionBlockAmbiguousErrorDetails.FromRawUnchecked(rawData);
}
