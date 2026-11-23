using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// This storage is bound to a different user profile from storage the Workspace has
/// attached, or from active or draining storage it once had for safeguards data.
/// Detaching storage the Workspace uses only for transcripts clears this. Detaching
/// safeguards storage doesn't, so use a new Workspace instead.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageProfileStillRequiredErrorDetails,
        BetaStorageProfileStillRequiredErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageProfileStillRequiredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_profile_still_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaStorageProfileStillRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_profile_still_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageProfileStillRequiredErrorDetails(
        BetaStorageProfileStillRequiredErrorDetails betaStorageProfileStillRequiredErrorDetails
    )
        : base(betaStorageProfileStillRequiredErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageProfileStillRequiredErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_profile_still_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageProfileStillRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageProfileStillRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageProfileStillRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaStorageProfileStillRequiredErrorDetailsFromRaw
    : IFromRawJson<BetaStorageProfileStillRequiredErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageProfileStillRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageProfileStillRequiredErrorDetails.FromRawUnchecked(rawData);
}
