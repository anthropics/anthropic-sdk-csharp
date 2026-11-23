using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage is `active` or `draining`, so this delete didn't erase it.
/// The message says what to do next. On `draining` storage this delete may have started
/// a removal that can't be undone: get the storage and read `status.removal_started`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalStorageInUseErrorDetails,
        BetaExternalStorageInUseErrorDetailsFromRaw
    >)
)]
public sealed record class BetaExternalStorageInUseErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("external_storage_in_use")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalStorageInUseErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_in_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorageInUseErrorDetails(
        BetaExternalStorageInUseErrorDetails betaExternalStorageInUseErrorDetails
    )
        : base(betaExternalStorageInUseErrorDetails) { }
#pragma warning restore CS8618

    public BetaExternalStorageInUseErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("external_storage_in_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorageInUseErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageInUseErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorageInUseErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaExternalStorageInUseErrorDetailsFromRaw
    : IFromRawJson<BetaExternalStorageInUseErrorDetails>
{
    /// <inheritdoc/>
    public BetaExternalStorageInUseErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalStorageInUseErrorDetails.FromRawUnchecked(rawData);
}
