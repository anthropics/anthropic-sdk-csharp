using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta;
using System = System;

namespace Anthropic.Models.Beta.UserProfiles;

/// <summary>
/// Update User Profile
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserProfileUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserProfileID { get; init; }

    /// <summary>
    /// If present, replaces the stored external_id. Omit to leave unchanged. Maximum
    /// 255 characters.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("external_id");
        }
        init { this._rawBodyData.Set("external_id", value); }
    }

    /// <summary>
    /// Key-value pairs to merge into the stored metadata. Keys provided overwrite
    /// existing values. To remove a key, set its value to an empty string. Keys not
    /// provided are left unchanged. Maximum 16 keys, with keys up to 64 characters
    /// and values up to 512 characters.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// If present, replaces the stored name. Omit to leave unchanged. Maximum 255 characters.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// How the entity behind a user profile relates to the platform that owns the
    /// API key. `external`: an individual end-user of the platform. `resold`: a company
    /// the platform resells Claude access to. `internal`: the platform's own usage.
    /// </summary>
    public ApiEnum<string, UserProfileUpdateParamsRelationship>? Relationship
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, UserProfileUpdateParamsRelationship>
            >("relationship");
        }
        init { this._rawBodyData.Set("relationship", value); }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public UserProfileUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileUpdateParams(UserProfileUpdateParams userProfileUpdateParams)
        : base(userProfileUpdateParams)
    {
        this.UserProfileID = userProfileUpdateParams.UserProfileID;

        this._rawBodyData = new(userProfileUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UserProfileUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string userProfileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.UserProfileID = userProfileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserProfileUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string userProfileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            userProfileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["UserProfileID"] = JsonSerializer.SerializeToElement(this.UserProfileID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UserProfileUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.UserProfileID?.Equals(other.UserProfileID) ?? other.UserProfileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/user_profiles/{0}", this.UserProfileID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        UserProfileService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// How the entity behind a user profile relates to the platform that owns the API
/// key. `external`: an individual end-user of the platform. `resold`: a company
/// the platform resells Claude access to. `internal`: the platform's own usage.
/// </summary>
[JsonConverter(typeof(UserProfileUpdateParamsRelationshipConverter))]
public enum UserProfileUpdateParamsRelationship
{
    External,
    Resold,
    Internal,
}

sealed class UserProfileUpdateParamsRelationshipConverter
    : JsonConverter<UserProfileUpdateParamsRelationship>
{
    public override UserProfileUpdateParamsRelationship Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "external" => UserProfileUpdateParamsRelationship.External,
            "resold" => UserProfileUpdateParamsRelationship.Resold,
            "internal" => UserProfileUpdateParamsRelationship.Internal,
            _ => (UserProfileUpdateParamsRelationship)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserProfileUpdateParamsRelationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserProfileUpdateParamsRelationship.External => "external",
                UserProfileUpdateParamsRelationship.Resold => "resold",
                UserProfileUpdateParamsRelationship.Internal => "internal",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
