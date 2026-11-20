using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The External Storage failed verification, so the request changed nothing. `failed_checks`
/// lists what to fix.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageVerificationFailedErrorDetails,
        BetaStorageVerificationFailedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageVerificationFailedErrorDetails : JsonModel
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

    /// <summary>
    /// One entry for each check that failed.
    /// </summary>
    public required IReadOnlyList<BetaExternalStorageFailedCheck> FailedChecks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaExternalStorageFailedCheck>>(
                "failed_checks"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaExternalStorageFailedCheck>>(
                "failed_checks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The request field at fault. Sent when the refused request is a Workspace's
    /// create or update.
    /// </summary>
    public string? Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("storage_verification_failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.FailedChecks)
        {
            item.Validate();
        }
        _ = this.Field;
    }

    public BetaStorageVerificationFailedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_verification_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageVerificationFailedErrorDetails(
        BetaStorageVerificationFailedErrorDetails betaStorageVerificationFailedErrorDetails
    )
        : base(betaStorageVerificationFailedErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageVerificationFailedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_verification_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageVerificationFailedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageVerificationFailedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageVerificationFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaStorageVerificationFailedErrorDetails(
        IReadOnlyList<BetaExternalStorageFailedCheck> failedChecks
    )
        : this()
    {
        this.FailedChecks = failedChecks;
    }
}

class BetaStorageVerificationFailedErrorDetailsFromRaw
    : IFromRawJson<BetaStorageVerificationFailedErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageVerificationFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageVerificationFailedErrorDetails.FromRawUnchecked(rawData);
}
