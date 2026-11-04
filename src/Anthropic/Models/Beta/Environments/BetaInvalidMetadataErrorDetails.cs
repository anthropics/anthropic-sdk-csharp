using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// `metadata` has too many keys, a key or value that is too long, or a reserved
/// key. The message names each problem.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaInvalidMetadataErrorDetails,
        BetaInvalidMetadataErrorDetailsFromRaw
    >)
)]
public sealed record class BetaInvalidMetadataErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("invalid_metadata")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInvalidMetadataErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaInvalidMetadataErrorDetails(
        BetaInvalidMetadataErrorDetails betaInvalidMetadataErrorDetails
    )
        : base(betaInvalidMetadataErrorDetails) { }
#pragma warning restore CS8618

    public BetaInvalidMetadataErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("invalid_metadata");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInvalidMetadataErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInvalidMetadataErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaInvalidMetadataErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaInvalidMetadataErrorDetailsFromRaw : IFromRawJson<BetaInvalidMetadataErrorDetails>
{
    /// <inheritdoc/>
    public BetaInvalidMetadataErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInvalidMetadataErrorDetails.FromRawUnchecked(rawData);
}
