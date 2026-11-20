using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// Anthropic has not approved External Storage for the organization, for the Workspace
/// or, for storage bound to a user profile, for that user profile. Contact your
/// Anthropic account team.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaGrantRequiredErrorDetails, BetaGrantRequiredErrorDetailsFromRaw>)
)]
public sealed record class BetaGrantRequiredErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("grant_required")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaGrantRequiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("grant_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaGrantRequiredErrorDetails(
        BetaGrantRequiredErrorDetails betaGrantRequiredErrorDetails
    )
        : base(betaGrantRequiredErrorDetails) { }
#pragma warning restore CS8618

    public BetaGrantRequiredErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("grant_required");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGrantRequiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGrantRequiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaGrantRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaGrantRequiredErrorDetailsFromRaw : IFromRawJson<BetaGrantRequiredErrorDetails>
{
    /// <inheritdoc/>
    public BetaGrantRequiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGrantRequiredErrorDetails.FromRawUnchecked(rawData);
}
