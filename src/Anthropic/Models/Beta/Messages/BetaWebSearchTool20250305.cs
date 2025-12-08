using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebSearchTool20250305, BetaWebSearchTool20250305FromRaw>))]
public sealed record class BetaWebSearchTool20250305 : ModelBase
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

    public IReadOnlyList<ApiEnum<string, BetaWebSearchTool20250305AllowedCaller>>? AllowedCallers
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, BetaWebSearchTool20250305AllowedCaller>>
            >(this.RawData, "allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "allowed_callers", value);
        }
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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <summary>
    /// If true, tool will not be included in initial system prompt. Only loaded when
    /// returned via tool_reference from tool search.
    /// </summary>
    public bool? DeferLoading
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "defer_loading"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "defer_loading", value);
        }
    }

    /// <summary>
    /// Maximum number of times the tool can be used in the API request.
    /// </summary>
    public long? MaxUses
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "max_uses"); }
        init { ModelBase.Set(this._rawData, "max_uses", value); }
    }

    public bool? Strict
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "strict"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "strict", value);
        }
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
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        _ = this.AllowedDomains;
        _ = this.BlockedDomains;
        this.CacheControl?.Validate();
        _ = this.DeferLoading;
        _ = this.MaxUses;
        _ = this.Strict;
        this.UserLocation?.Validate();
    }

    public BetaWebSearchTool20250305()
    {
        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

    public BetaWebSearchTool20250305(BetaWebSearchTool20250305 betaWebSearchTool20250305)
        : base(betaWebSearchTool20250305) { }

    public BetaWebSearchTool20250305(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Name = JsonSerializer.Deserialize<JsonElement>("\"web_search\"");
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_20250305\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchTool20250305(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebSearchTool20250305FromRaw.FromRawUnchecked"/>
    public static BetaWebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebSearchTool20250305FromRaw : IFromRaw<BetaWebSearchTool20250305>
{
    /// <inheritdoc/>
    public BetaWebSearchTool20250305 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebSearchTool20250305.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaWebSearchTool20250305AllowedCallerConverter))]
public enum BetaWebSearchTool20250305AllowedCaller
{
    Direct,
    CodeExecution20250825,
}

sealed class BetaWebSearchTool20250305AllowedCallerConverter
    : JsonConverter<BetaWebSearchTool20250305AllowedCaller>
{
    public override BetaWebSearchTool20250305AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaWebSearchTool20250305AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaWebSearchTool20250305AllowedCaller.CodeExecution20250825,
            _ => (BetaWebSearchTool20250305AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchTool20250305AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebSearchTool20250305AllowedCaller.Direct => "direct",
                BetaWebSearchTool20250305AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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
