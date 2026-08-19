using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Approximate user location for search result localization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsUserLocation, BetaManagedAgentsUserLocationFromRaw>)
)]
public sealed record class BetaManagedAgentsUserLocation : JsonModel
{
    /// <summary>
    /// Location precision. Only "approximate" is supported.
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
    /// City name.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Two-letter ISO 3166-1 country code, uppercase.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// Region or state name.
    /// </summary>
    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// IANA timezone identifier, e.g. "America/Los_Angeles".
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("approximate")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.City;
        _ = this.Country;
        _ = this.Region;
        _ = this.Timezone;
    }

    public BetaManagedAgentsUserLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("approximate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserLocation(
        BetaManagedAgentsUserLocation betaManagedAgentsUserLocation
    )
        : base(betaManagedAgentsUserLocation) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("approximate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserLocationFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserLocationFromRaw : IFromRawJson<BetaManagedAgentsUserLocation>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserLocation.FromRawUnchecked(rawData);
}
