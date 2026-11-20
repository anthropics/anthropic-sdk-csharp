using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The organization already has External Storage for this bucket that it has not
/// deleted. List the organization's External Storage to find it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaStorageAlreadyRegisteredErrorDetails,
        BetaStorageAlreadyRegisteredErrorDetailsFromRaw
    >)
)]
public sealed record class BetaStorageAlreadyRegisteredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("storage_already_registered")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaStorageAlreadyRegisteredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("storage_already_registered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaStorageAlreadyRegisteredErrorDetails(
        BetaStorageAlreadyRegisteredErrorDetails betaStorageAlreadyRegisteredErrorDetails
    )
        : base(betaStorageAlreadyRegisteredErrorDetails) { }
#pragma warning restore CS8618

    public BetaStorageAlreadyRegisteredErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("storage_already_registered");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaStorageAlreadyRegisteredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaStorageAlreadyRegisteredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaStorageAlreadyRegisteredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaStorageAlreadyRegisteredErrorDetailsFromRaw
    : IFromRawJson<BetaStorageAlreadyRegisteredErrorDetails>
{
    /// <inheritdoc/>
    public BetaStorageAlreadyRegisteredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaStorageAlreadyRegisteredErrorDetails.FromRawUnchecked(rawData);
}
