using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The organization has not proved that it owns the Google Cloud project that holds
/// the key or bucket. The message names the field.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaGcpProjectNotVerifiedErrorDetails,
        BetaGcpProjectNotVerifiedErrorDetailsFromRaw
    >)
)]
public sealed record class BetaGcpProjectNotVerifiedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("gcp_project_not_verified")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGcpProjectNotVerifiedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("gcp_project_not_verified");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGcpProjectNotVerifiedErrorDetails(
        BetaGcpProjectNotVerifiedErrorDetails betaGcpProjectNotVerifiedErrorDetails
    )
        : base(betaGcpProjectNotVerifiedErrorDetails) { }
#pragma warning restore CS8618

    public BetaGcpProjectNotVerifiedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("gcp_project_not_verified");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGcpProjectNotVerifiedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGcpProjectNotVerifiedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaGcpProjectNotVerifiedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGcpProjectNotVerifiedErrorDetailsFromRaw
    : IFromRawJson<BetaGcpProjectNotVerifiedErrorDetails>
{
    /// <inheritdoc/>
    public BetaGcpProjectNotVerifiedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGcpProjectNotVerifiedErrorDetails.FromRawUnchecked(rawData);
}
