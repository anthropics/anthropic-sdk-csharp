using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchTool20250305, WebSearchTool20250305FromRaw>))]
public sealed record class WebSearchTool20250305 : ModelBase
{
    /// <summary>
    /// Name of the tool.
    ///
    /// <para>This is how the tool will be called by the model and in `tool_use` blocks.</para>
    /// </summary>
    public JsonElement Name
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// If provided, only these domains will be included in results. Cannot be used
    /// alongside `blocked_domains`.
    /// </summary>
    public IReadOnlyList<string>? AllowedDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "allowed_domains"); }
        init { ModelBase.Set(this._rawData, "allowed_domains", value); }
    }

    /// <summary>
    /// If provided, these domains will never appear in results. Cannot be used alongside `allowed_domains`.
    /// </summary>
    public IReadOnlyList<string>? BlockedDomains
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "blocked_domains"); }
        init { ModelBase.Set(this._rawData, "blocked_domains", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<CacheControlEphemeral>(this.RawData, "cache_control");
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "max_uses"); }
        init { ModelBase.Set(this._rawData, "max_uses", value); }
    }

    /// <summary>
    /// Parameters for the user's location. Used to provide more relevant search results.
    /// </summary>
    public UserLocation? UserLocation
    {
        get { return ModelBase.GetNullableClass<UserLocation>(this.RawData, "user_location"); }
        init { ModelBase.Set(this._rawData, "user_location", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.Deserialize<JsonElement>("\"web_search\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        _ = this.MaxUses;
        this.UserLocation?.Validate();
    }

    public WebSearchTool20250305()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

    public WebSearchTool20250305(WebSearchTool20250305 webSearchTool20250305)
        : base(webSearchTool20250305) { }

    public WebSearchTool20250305(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchTool20250305(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchTool20250305FromRaw.FromRawUnchecked"/>
    public static WebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebSearchTool20250305FromRaw : IFromRaw<WebSearchTool20250305>
{
    /// <inheritdoc/>
    public WebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchTool20250305.FromRawUnchecked(rawData);
}

/// <summary>
/// Parameters for the user's location. Used to provide more relevant search results.
/// </summary>
[JsonConverter(typeof(ModelConverter<UserLocation, UserLocationFromRaw>))]
public sealed record class UserLocation : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The city of the user.
    /// </summary>
    public string? City
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "city"); }
        init { ModelBase.Set(this._rawData, "city", value); }
    }

    /// <summary>
    /// The two letter [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// of the user.
    /// </summary>
    public string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init { ModelBase.Set(this._rawData, "country", value); }
    }

    /// <summary>
    /// The region of the user.
    /// </summary>
    public string? Region
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "region"); }
        init { ModelBase.Set(this._rawData, "region", value); }
    }

    /// <summary>
    /// The [IANA timezone](https://nodatime.org/TimeZones) of the user.
    /// </summary>
    public string? Timezone
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "timezone"); }
        init { ModelBase.Set(this._rawData, "timezone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"approximate\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public UserLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

    public UserLocation(UserLocation userLocation)
        : base(userLocation) { }

    public UserLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"approximate\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserLocationFromRaw.FromRawUnchecked"/>
    public static UserLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserLocationFromRaw : IFromRaw<UserLocation>
{
    /// <inheritdoc/>
    public UserLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserLocation.FromRawUnchecked(rawData);
}
