using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<OrganizationRateLimitValue, OrganizationRateLimitValueFromRaw>)
)]
public sealed record class OrganizationRateLimitValue : JsonModel
{
    /// <summary>
    /// The limiter type (for example, `requests_per_minute` or `input_tokens_per_minute`).
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The configured limit value for this limiter type.
    /// </summary>
    public required long Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.Value;
    }

    public OrganizationRateLimitValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRateLimitValue(OrganizationRateLimitValue organizationRateLimitValue)
        : base(organizationRateLimitValue) { }
#pragma warning restore CS8618

    public OrganizationRateLimitValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRateLimitValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRateLimitValueFromRaw.FromRawUnchecked"/>
    public static OrganizationRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationRateLimitValueFromRaw : IFromRawJson<OrganizationRateLimitValue>
{
    /// <inheritdoc/>
    public OrganizationRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRateLimitValue.FromRawUnchecked(rawData);
}
