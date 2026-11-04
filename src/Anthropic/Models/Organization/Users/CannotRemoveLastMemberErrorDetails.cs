using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Users;

/// <summary>
/// The user is the organization's only member. Add another member before removing
/// this one.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CannotRemoveLastMemberErrorDetails,
        CannotRemoveLastMemberErrorDetailsFromRaw
    >)
)]
public sealed record class CannotRemoveLastMemberErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("cannot_remove_last_member")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CannotRemoveLastMemberErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_remove_last_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CannotRemoveLastMemberErrorDetails(
        CannotRemoveLastMemberErrorDetails cannotRemoveLastMemberErrorDetails
    )
        : base(cannotRemoveLastMemberErrorDetails) { }
#pragma warning restore CS8618

    public CannotRemoveLastMemberErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cannot_remove_last_member");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CannotRemoveLastMemberErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CannotRemoveLastMemberErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CannotRemoveLastMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CannotRemoveLastMemberErrorDetailsFromRaw : IFromRawJson<CannotRemoveLastMemberErrorDetails>
{
    /// <inheritdoc/>
    public CannotRemoveLastMemberErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CannotRemoveLastMemberErrorDetails.FromRawUnchecked(rawData);
}
