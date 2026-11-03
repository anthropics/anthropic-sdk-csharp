using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The compaction could not be completed for a transient server reason. Retry the request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionUnavailableErrorDetails,
        CompactionUnavailableErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionUnavailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_unavailable")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionUnavailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionUnavailableErrorDetails(
        CompactionUnavailableErrorDetails compactionUnavailableErrorDetails
    )
        : base(compactionUnavailableErrorDetails) { }
#pragma warning restore CS8618

    public CompactionUnavailableErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_unavailable");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionUnavailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionUnavailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionUnavailableErrorDetailsFromRaw : IFromRawJson<CompactionUnavailableErrorDetails>
{
    /// <inheritdoc/>
    public CompactionUnavailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionUnavailableErrorDetails.FromRawUnchecked(rawData);
}
