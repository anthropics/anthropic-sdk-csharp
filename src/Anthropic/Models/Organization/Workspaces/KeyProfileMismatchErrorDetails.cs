using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The External Key is bound to a user profile, and the Workspace does not have that
/// user profile. A Workspace can use only a key bound to its own user profile or
/// a key that isn't bound to one.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        KeyProfileMismatchErrorDetails,
        KeyProfileMismatchErrorDetailsFromRaw
    >)
)]
public sealed record class KeyProfileMismatchErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("key_profile_mismatch")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public KeyProfileMismatchErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("key_profile_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public KeyProfileMismatchErrorDetails(
        KeyProfileMismatchErrorDetails keyProfileMismatchErrorDetails
    )
        : base(keyProfileMismatchErrorDetails) { }
#pragma warning restore CS8618

    public KeyProfileMismatchErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("key_profile_mismatch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    KeyProfileMismatchErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="KeyProfileMismatchErrorDetailsFromRaw.FromRawUnchecked"/>
    public static KeyProfileMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class KeyProfileMismatchErrorDetailsFromRaw : IFromRawJson<KeyProfileMismatchErrorDetails>
{
    /// <inheritdoc/>
    public KeyProfileMismatchErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => KeyProfileMismatchErrorDetails.FromRawUnchecked(rawData);
}
