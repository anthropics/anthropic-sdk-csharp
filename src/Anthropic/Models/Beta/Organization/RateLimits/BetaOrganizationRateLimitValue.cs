using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationRateLimitValue,
        BetaOrganizationRateLimitValueFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitValue : JsonModel
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

    public BetaOrganizationRateLimitValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitValue(
        BetaOrganizationRateLimitValue betaOrganizationRateLimitValue
    )
        : base(betaOrganizationRateLimitValue) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitValueFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationRateLimitValueFromRaw : IFromRawJson<BetaOrganizationRateLimitValue>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitValue.FromRawUnchecked(rawData);
}
