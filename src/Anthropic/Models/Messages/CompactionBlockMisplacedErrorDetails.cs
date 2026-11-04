using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The `compaction` block is not the first block of the conversation, or is in a
/// `system` message.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionBlockMisplacedErrorDetails,
        CompactionBlockMisplacedErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionBlockMisplacedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_block_misplaced")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionBlockMisplacedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_block_misplaced");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionBlockMisplacedErrorDetails(
        CompactionBlockMisplacedErrorDetails compactionBlockMisplacedErrorDetails
    )
        : base(compactionBlockMisplacedErrorDetails) { }
#pragma warning restore CS8618

    public CompactionBlockMisplacedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_block_misplaced");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionBlockMisplacedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionBlockMisplacedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionBlockMisplacedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionBlockMisplacedErrorDetailsFromRaw
    : IFromRawJson<CompactionBlockMisplacedErrorDetails>
{
    /// <inheritdoc/>
    public CompactionBlockMisplacedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionBlockMisplacedErrorDetails.FromRawUnchecked(rawData);
}
