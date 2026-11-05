using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// On a public-sector deployment, only an API key or token that belongs to a person
/// with owner permissions can sign out a member with the `managed` role.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaCannotSignOutManagedMemberErrorDetails,
        BetaCannotSignOutManagedMemberErrorDetailsFromRaw
    >)
)]
public sealed record class BetaCannotSignOutManagedMemberErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_sign_out_managed_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCannotSignOutManagedMemberErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_managed_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCannotSignOutManagedMemberErrorDetails(
        BetaCannotSignOutManagedMemberErrorDetails betaCannotSignOutManagedMemberErrorDetails
    )
        : base(betaCannotSignOutManagedMemberErrorDetails) { }
#pragma warning restore CS8618

    public BetaCannotSignOutManagedMemberErrorDetails(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_sign_out_managed_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCannotSignOutManagedMemberErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCannotSignOutManagedMemberErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaCannotSignOutManagedMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCannotSignOutManagedMemberErrorDetailsFromRaw
    : IFromRawJson<BetaCannotSignOutManagedMemberErrorDetails>
{
    /// <inheritdoc/>
    public BetaCannotSignOutManagedMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCannotSignOutManagedMemberErrorDetails.FromRawUnchecked(rawData);
}
