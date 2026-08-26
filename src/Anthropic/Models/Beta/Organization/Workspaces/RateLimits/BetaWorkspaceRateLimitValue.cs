using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaWorkspaceRateLimitValue, BetaWorkspaceRateLimitValueFromRaw>)
)]
public sealed record class BetaWorkspaceRateLimitValue : JsonModel
{
    /// <summary>
    /// The organization-level value for the same limiter type, for reference. `null`
    /// when the organization has no limit configured for this limiter type.
    /// </summary>
    public required long? OrgLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("org_limit");
        }
        init { this._rawData.Set("org_limit", value); }
    }

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
    /// The workspace-level override value for this limiter type.
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
        _ = this.OrgLimit;
        _ = this.Type;
        _ = this.Value;
    }

    public BetaWorkspaceRateLimitValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimitValue(BetaWorkspaceRateLimitValue betaWorkspaceRateLimitValue)
        : base(betaWorkspaceRateLimitValue) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimitValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimitValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitValueFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitValueFromRaw : IFromRawJson<BetaWorkspaceRateLimitValue>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimitValue.FromRawUnchecked(rawData);
}
