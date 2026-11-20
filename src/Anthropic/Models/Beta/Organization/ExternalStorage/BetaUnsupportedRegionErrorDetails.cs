using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// `provider_config.region` is not a region where External Storage is available.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaUnsupportedRegionErrorDetails,
        BetaUnsupportedRegionErrorDetailsFromRaw
    >)
)]
public sealed record class BetaUnsupportedRegionErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("unsupported_region")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaUnsupportedRegionErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("unsupported_region");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUnsupportedRegionErrorDetails(
        BetaUnsupportedRegionErrorDetails betaUnsupportedRegionErrorDetails
    )
        : base(betaUnsupportedRegionErrorDetails) { }
#pragma warning restore CS8618

    public BetaUnsupportedRegionErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("unsupported_region");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUnsupportedRegionErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUnsupportedRegionErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaUnsupportedRegionErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUnsupportedRegionErrorDetailsFromRaw : IFromRawJson<BetaUnsupportedRegionErrorDetails>
{
    /// <inheritdoc/>
    public BetaUnsupportedRegionErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUnsupportedRegionErrorDetails.FromRawUnchecked(rawData);
}
