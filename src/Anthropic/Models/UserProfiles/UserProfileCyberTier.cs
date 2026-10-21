using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// One tier of the Cyber Verification Program.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfileCyberTier, UserProfileCyberTierFromRaw>))]
public sealed record class UserProfileCyberTier : JsonModel
{
    /// <summary>
    /// `active` when the tier applies to the profile, otherwise `inactive`. The response
    /// does not say why a tier is `inactive`: it can be in review, declined, withdrawn,
    /// never applied for, or approved but not applied to this profile.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public UserProfileCyberTier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileCyberTier(UserProfileCyberTier userProfileCyberTier)
        : base(userProfileCyberTier) { }
#pragma warning restore CS8618

    public UserProfileCyberTier(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileCyberTier(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileCyberTierFromRaw.FromRawUnchecked"/>
    public static UserProfileCyberTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserProfileCyberTier(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class UserProfileCyberTierFromRaw : IFromRawJson<UserProfileCyberTier>
{
    /// <inheritdoc/>
    public UserProfileCyberTier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileCyberTier.FromRawUnchecked(rawData);
}

/// <summary>
/// `active` when the tier applies to the profile, otherwise `inactive`. The response
/// does not say why a tier is `inactive`: it can be in review, declined, withdrawn,
/// never applied for, or approved but not applied to this profile.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "inactive" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Inactive => "inactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
