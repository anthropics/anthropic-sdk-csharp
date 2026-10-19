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
/// One feature of Enterprise Frontier Safeguards.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfileEfsFeature, UserProfileEfsFeatureFromRaw>))]
public sealed record class UserProfileEfsFeature : JsonModel
{
    /// <summary>
    /// `active` when Anthropic has approved the entity the profile represents to
    /// use the feature, otherwise `inactive`. `active` does not mean that the feature
    /// is set up or switched on, which is a separate step.
    /// </summary>
    public required ApiEnum<string, UserProfileEfsFeatureStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserProfileEfsFeatureStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
    }

    public UserProfileEfsFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileEfsFeature(UserProfileEfsFeature userProfileEfsFeature)
        : base(userProfileEfsFeature) { }
#pragma warning restore CS8618

    public UserProfileEfsFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileEfsFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileEfsFeatureFromRaw.FromRawUnchecked"/>
    public static UserProfileEfsFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserProfileEfsFeature(ApiEnum<string, UserProfileEfsFeatureStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class UserProfileEfsFeatureFromRaw : IFromRawJson<UserProfileEfsFeature>
{
    /// <inheritdoc/>
    public UserProfileEfsFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileEfsFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// `active` when Anthropic has approved the entity the profile represents to use
/// the feature, otherwise `inactive`. `active` does not mean that the feature is
/// set up or switched on, which is a separate step.
/// </summary>
[JsonConverter(typeof(UserProfileEfsFeatureStatusConverter))]
public enum UserProfileEfsFeatureStatus
{
    Active,
    Inactive,
}

sealed class UserProfileEfsFeatureStatusConverter : JsonConverter<UserProfileEfsFeatureStatus>
{
    public override UserProfileEfsFeatureStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => UserProfileEfsFeatureStatus.Active,
            "inactive" => UserProfileEfsFeatureStatus.Inactive,
            _ => (UserProfileEfsFeatureStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileEfsFeatureStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileEfsFeatureStatus.Active => "active",
                UserProfileEfsFeatureStatus.Inactive => "inactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
