using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The bucket is already in use, or was in use recently. Name a different bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaStorageInUseErrorDetails, BetaStorageInUseErrorDetailsFromRaw>)
)]
public sealed record class BetaStorageInUseErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_in_use")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaStorageInUseErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_in_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageInUseErrorDetails(BetaStorageInUseErrorDetails betaStorageInUseErrorDetails)
        : base(betaStorageInUseErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageInUseErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_in_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageInUseErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageInUseErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageInUseErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaStorageInUseErrorDetailsFromRaw : IFromRawJson<BetaStorageInUseErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageInUseErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageInUseErrorDetails.FromRawUnchecked(rawData);
}
