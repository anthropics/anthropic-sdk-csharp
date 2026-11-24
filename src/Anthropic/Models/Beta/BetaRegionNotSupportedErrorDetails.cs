using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The request names a region code that the control does not take from this organization.
/// The message names the field.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaRegionNotSupportedErrorDetails,
        BetaRegionNotSupportedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaRegionNotSupportedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("region_not_supported")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRegionNotSupportedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("region_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRegionNotSupportedErrorDetails(
        BetaRegionNotSupportedErrorDetails betaRegionNotSupportedErrorDetails
    )
        : base(betaRegionNotSupportedErrorDetails) { }
#pragma warning restore CS8618

    public BetaRegionNotSupportedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("region_not_supported");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRegionNotSupportedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRegionNotSupportedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaRegionNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRegionNotSupportedErrorDetailsFromRaw : IFromRawJson<BetaRegionNotSupportedErrorDetails>
{
    /// <inheritdoc/>
    public BetaRegionNotSupportedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRegionNotSupportedErrorDetails.FromRawUnchecked(rawData);
}
