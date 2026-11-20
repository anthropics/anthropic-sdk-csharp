using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The request can't use External Storage on this cloud provider. The error's message
/// says why.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaProviderNotAllowedErrorDetails,
        BetaProviderNotAllowedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaProviderNotAllowedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("provider_not_allowed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaProviderNotAllowedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("provider_not_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaProviderNotAllowedErrorDetails(
        BetaProviderNotAllowedErrorDetails betaProviderNotAllowedErrorDetails
    )
        : base(betaProviderNotAllowedErrorDetails) { }
#pragma warning restore CS8618

    public BetaProviderNotAllowedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("provider_not_allowed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaProviderNotAllowedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaProviderNotAllowedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaProviderNotAllowedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaProviderNotAllowedErrorDetailsFromRaw : IFromRawJson<BetaProviderNotAllowedErrorDetails>
{
    /// <inheritdoc/>
    public BetaProviderNotAllowedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaProviderNotAllowedErrorDetails.FromRawUnchecked(rawData);
}
