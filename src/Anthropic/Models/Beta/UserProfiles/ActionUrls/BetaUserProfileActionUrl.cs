using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.ActionUrls;

/// <summary>
/// A URL to give to the person who takes the requested action.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaUserProfileActionUrl, BetaUserProfileActionUrlFromRaw>)
)]
public sealed record class BetaUserProfileActionUrl : JsonModel
{
    /// <summary>
    /// When the URL stops working, in RFC 3339 format.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Object type. Always `user_profile_action_url`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The URL to give to the person who takes the action. Anyone who holds it can
    /// open it until `expires_at`.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpiresAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("user_profile_action_url")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BetaUserProfileActionUrl()
    {
        this.Type = JsonSerializer.SerializeToElement("user_profile_action_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileActionUrl(BetaUserProfileActionUrl betaUserProfileActionUrl)
        : base(betaUserProfileActionUrl) { }
#pragma warning restore CS8618

    public BetaUserProfileActionUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user_profile_action_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileActionUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileActionUrlFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileActionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileActionUrlFromRaw : IFromRawJson<BetaUserProfileActionUrl>
{
    /// <inheritdoc/>
    public BetaUserProfileActionUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileActionUrl.FromRawUnchecked(rawData);
}
