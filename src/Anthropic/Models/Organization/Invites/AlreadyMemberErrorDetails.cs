using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// The email address already belongs to a user in the organization. The message names
/// the user.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AlreadyMemberErrorDetails, AlreadyMemberErrorDetailsFromRaw>)
)]
public sealed record class AlreadyMemberErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("already_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public AlreadyMemberErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("already_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlreadyMemberErrorDetails(AlreadyMemberErrorDetails alreadyMemberErrorDetails)
        : base(alreadyMemberErrorDetails) { }
#pragma warning restore CS8618

    public AlreadyMemberErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("already_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlreadyMemberErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlreadyMemberErrorDetailsFromRaw.FromRawUnchecked"/>
    public static AlreadyMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlreadyMemberErrorDetailsFromRaw : IFromRawJson<AlreadyMemberErrorDetails>
{
    /// <inheritdoc/>
    public AlreadyMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlreadyMemberErrorDetails.FromRawUnchecked(rawData);
}
