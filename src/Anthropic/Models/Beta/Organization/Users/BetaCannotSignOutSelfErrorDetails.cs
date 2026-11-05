using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is the user the API key or token belongs to.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutSelfErrorDetails,
        BetaCannotSignOutSelfErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutSelfErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_self")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutSelfErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_self");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutSelfErrorDetails(
        BetaCannotSignOutSelfErrorDetails betaCannotSignOutSelfErrorDetails
    )
        : base(betaCannotSignOutSelfErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutSelfErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_self");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutSelfErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutSelfErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutSelfErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutSelfErrorDetailsFromRaw : IFromRawJson<BetaCannotSignOutSelfErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutSelfErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutSelfErrorDetails.FromRawUnchecked(rawData);
}
