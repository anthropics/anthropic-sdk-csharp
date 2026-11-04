using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// A pending invite already exists for the email address. The message names the invite.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        InviteAlreadyExistsErrorDetails,
        InviteAlreadyExistsErrorDetailsFromRaw
    >)
)]
public sealed record class InviteAlreadyExistsErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("invite_already_exists")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InviteAlreadyExistsErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("invite_already_exists");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteAlreadyExistsErrorDetails(
        InviteAlreadyExistsErrorDetails inviteAlreadyExistsErrorDetails
    )
        : base(inviteAlreadyExistsErrorDetails) { }
#pragma warning restore CS8618

    public InviteAlreadyExistsErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("invite_already_exists");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteAlreadyExistsErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InviteAlreadyExistsErrorDetailsFromRaw.FromRawUnchecked"/>
    public static InviteAlreadyExistsErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InviteAlreadyExistsErrorDetailsFromRaw : IFromRawJson<InviteAlreadyExistsErrorDetails>
{
    /// <inheritdoc/>
    public InviteAlreadyExistsErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InviteAlreadyExistsErrorDetails.FromRawUnchecked(rawData);
}
