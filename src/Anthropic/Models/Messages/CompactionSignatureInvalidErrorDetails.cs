using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The `compaction` block's `signature` does not verify.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CompactionSignatureInvalidErrorDetails,
        CompactionSignatureInvalidErrorDetailsFromRaw
    >)
)]
public sealed record class CompactionSignatureInvalidErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("compaction_signature_invalid")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CompactionSignatureInvalidErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_signature_invalid");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompactionSignatureInvalidErrorDetails(
        CompactionSignatureInvalidErrorDetails compactionSignatureInvalidErrorDetails
    )
        : base(compactionSignatureInvalidErrorDetails) { }
#pragma warning restore CS8618

    public CompactionSignatureInvalidErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("compaction_signature_invalid");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompactionSignatureInvalidErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompactionSignatureInvalidErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CompactionSignatureInvalidErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompactionSignatureInvalidErrorDetailsFromRaw
    : IFromRawJson<CompactionSignatureInvalidErrorDetails>
{
    /// <inheritdoc/>
    public CompactionSignatureInvalidErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompactionSignatureInvalidErrorDetails.FromRawUnchecked(rawData);
}
