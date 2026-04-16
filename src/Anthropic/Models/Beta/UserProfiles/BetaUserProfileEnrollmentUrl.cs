using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

[JsonConverter(
    typeof(JsonModelConverter<BetaUserProfileEnrollmentUrl, BetaUserProfileEnrollmentUrlFromRaw>)
)]
public sealed record class BetaUserProfileEnrollmentUrl : JsonModel
{
    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Object type. Always `enrollment_url`.
    /// </summary>
    public required ApiEnum<string, BetaUserProfileEnrollmentUrlType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaUserProfileEnrollmentUrlType>>(
                "type"
            );
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
        this.Type.Validate();
        _ = this.Url;
    }

    public BetaUserProfileEnrollmentUrl() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUserProfileEnrollmentUrl(BetaUserProfileEnrollmentUrl betaUserProfileEnrollmentUrl)
        : base(betaUserProfileEnrollmentUrl) { }
#pragma warning restore CS8618

    public BetaUserProfileEnrollmentUrl(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

/// <summary>
/// Object type. Always `enrollment_url`.
/// </summary>
[JsonConverter(typeof(BetaUserProfileEnrollmentUrlTypeConverter))]
public enum BetaUserProfileEnrollmentUrlType
{
    EnrollmentUrl,
}

sealed class BetaUserProfileEnrollmentUrlTypeConverter
    : JsonConverter<BetaUserProfileEnrollmentUrlType>
{
    public override BetaUserProfileEnrollmentUrlType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enrollment_url" => BetaUserProfileEnrollmentUrlType.EnrollmentUrl,
            _ => (BetaUserProfileEnrollmentUrlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUserProfileEnrollmentUrlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUserProfileEnrollmentUrlType.EnrollmentUrl => "enrollment_url",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
