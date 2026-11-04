using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The compaction request ends on an `assistant` turn that is not finished.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionIncompleteTurnErrorDetails,
        CompactionIncompleteTurnErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionIncompleteTurnErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_incomplete_turn")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionIncompleteTurnErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_incomplete_turn");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionIncompleteTurnErrorDetails(
        CompactionIncompleteTurnErrorDetails compactionIncompleteTurnErrorDetails
    )
        : base(compactionIncompleteTurnErrorDetails) { }
#pragma warning restore CS8618

    public CompactionIncompleteTurnErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_incomplete_turn");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionIncompleteTurnErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionIncompleteTurnErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionIncompleteTurnErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionIncompleteTurnErrorDetailsFromRaw
    : IFromRawJson<CompactionIncompleteTurnErrorDetails>
{
    /// <inheritdoc/>
    public CompactionIncompleteTurnErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionIncompleteTurnErrorDetails.FromRawUnchecked(rawData);
}
