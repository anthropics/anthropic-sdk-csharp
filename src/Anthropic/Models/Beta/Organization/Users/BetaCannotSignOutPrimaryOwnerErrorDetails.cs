using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is the organization's primary owner, whom no API key or token can
/// sign out.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutPrimaryOwnerErrorDetails,
        BetaCannotSignOutPrimaryOwnerErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutPrimaryOwnerErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_primary_owner")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutPrimaryOwnerErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_primary_owner");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutPrimaryOwnerErrorDetails(
        BetaCannotSignOutPrimaryOwnerErrorDetails betaCannotSignOutPrimaryOwnerErrorDetails
    )
        : base(betaCannotSignOutPrimaryOwnerErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutPrimaryOwnerErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_primary_owner");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutPrimaryOwnerErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutPrimaryOwnerErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutPrimaryOwnerErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutPrimaryOwnerErrorDetailsFromRaw
    : IFromRawJson<BetaCannotSignOutPrimaryOwnerErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutPrimaryOwnerErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutPrimaryOwnerErrorDetails.FromRawUnchecked(rawData);
}
