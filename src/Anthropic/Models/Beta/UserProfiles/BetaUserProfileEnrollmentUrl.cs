using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles;

/// <summary>
/// A URL to give to the entity that a user profile represents, so that the entity
/// can enroll in a program.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaUserProfileEnrollmentUrl, BetaUserProfileEnrollmentUrlFromRaw>)
)]
public sealed record class BetaUserProfileEnrollmentUrl : JsonModel
{
    /// <summary>
    /// When this enrollment URL expires, in RFC 3339 format.
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
    /// Object type. Always `enrollment_url`.
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
    /// Enrollment URL to send to the end user. Valid until `expires_at`.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enrollment_url")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BetaUserProfileEnrollmentUrl()
    {
        this.Type = JsonSerializer.SerializeToElement("enrollment_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileEnrollmentUrl(BetaUserProfileEnrollmentUrl betaUserProfileEnrollmentUrl)
        : base(betaUserProfileEnrollmentUrl) { }
#pragma warning restore CS8618

    public BetaUserProfileEnrollmentUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enrollment_url");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUserProfileEnrollmentUrl(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUserProfileEnrollmentUrlFromRaw.FromRawUnchecked"/>
    public static BetaUserProfileEnrollmentUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUserProfileEnrollmentUrlFromRaw : IFromRawJson<BetaUserProfileEnrollmentUrl>
{
    /// <inheritdoc/>
    public BetaUserProfileEnrollmentUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaUserProfileEnrollmentUrl.FromRawUnchecked(rawData);
}
