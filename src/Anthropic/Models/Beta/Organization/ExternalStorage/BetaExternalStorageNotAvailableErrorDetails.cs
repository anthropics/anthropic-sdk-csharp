using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// External Storage isn't available for this Workspace, so only `internal` storage
/// is accepted. The error's `message` says why.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalStorageNotAvailableErrorDetails,
        BetaExternalStorageNotAvailableErrorDetailsFromRaw
    >)
)]
public sealed record class BetaExternalStorageNotAvailableErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_storage_not_available")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalStorageNotAvailableErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_not_available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorageNotAvailableErrorDetails(
        BetaExternalStorageNotAvailableErrorDetails betaExternalStorageNotAvailableErrorDetails
    )
        : base(betaExternalStorageNotAvailableErrorDetails) { }
#pragma warning restore CS8618

    public BetaExternalStorageNotAvailableErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_not_available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorageNotAvailableErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageNotAvailableErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorageNotAvailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalStorageNotAvailableErrorDetailsFromRaw
    : IFromRawJson<BetaExternalStorageNotAvailableErrorDetails>
{
    /// <inheritdoc/>
    public BetaExternalStorageNotAvailableErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalStorageNotAvailableErrorDetails.FromRawUnchecked(rawData);
}
