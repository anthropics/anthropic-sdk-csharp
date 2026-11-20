using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The Workspace has reached its limit of 100 different External Storage resources
/// attached over its lifetime. Detached storage counts toward the limit until it
/// is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageAttachLimitReachedErrorDetails,
        BetaStorageAttachLimitReachedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageAttachLimitReachedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_attach_limit_reached")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaStorageAttachLimitReachedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_attach_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageAttachLimitReachedErrorDetails(
        BetaStorageAttachLimitReachedErrorDetails betaStorageAttachLimitReachedErrorDetails
    )
        : base(betaStorageAttachLimitReachedErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageAttachLimitReachedErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_attach_limit_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageAttachLimitReachedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageAttachLimitReachedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageAttachLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaStorageAttachLimitReachedErrorDetailsFromRaw
    : IFromRawJson<BetaStorageAttachLimitReachedErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageAttachLimitReachedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageAttachLimitReachedErrorDetails.FromRawUnchecked(rawData);
}
