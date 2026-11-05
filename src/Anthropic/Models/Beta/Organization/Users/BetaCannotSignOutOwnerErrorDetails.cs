using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is an owner or has owner permissions, and this API key or token cannot
/// sign them out. In a Claude Enterprise organization, an API key with the `write:members`
/// scope can.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutOwnerErrorDetails,
        BetaCannotSignOutOwnerErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutOwnerErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_owner")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutOwnerErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_owner");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutOwnerErrorDetails(
        BetaCannotSignOutOwnerErrorDetails betaCannotSignOutOwnerErrorDetails
    )
        : base(betaCannotSignOutOwnerErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutOwnerErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_owner");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutOwnerErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutOwnerErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutOwnerErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutOwnerErrorDetailsFromRaw : IFromRawJson<BetaCannotSignOutOwnerErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutOwnerErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutOwnerErrorDetails.FromRawUnchecked(rawData);
}
