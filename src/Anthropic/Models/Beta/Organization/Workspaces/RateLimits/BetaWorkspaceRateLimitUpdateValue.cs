using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWorkspaceRateLimitUpdateValue,
        BetaWorkspaceRateLimitUpdateValueFromRaw
    >)
)]
public sealed record class BetaWorkspaceRateLimitUpdateValue : JsonModel
{
    /// <summary>
    /// Rate limiter type.
    /// </summary>
    public required ApiEnum<string, BetaWorkspaceRateLimitType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWorkspaceRateLimitType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// New limit value. Set to null to clear the workspace override and fall back
    /// to the organization limit.
    /// </summary>
    public required long? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public BetaWorkspaceRateLimitUpdateValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimitUpdateValue(
        BetaWorkspaceRateLimitUpdateValue betaWorkspaceRateLimitUpdateValue
    )
        : base(betaWorkspaceRateLimitUpdateValue) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimitUpdateValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimitUpdateValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitUpdateValueFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimitUpdateValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitUpdateValueFromRaw : IFromRawJson<BetaWorkspaceRateLimitUpdateValue>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimitUpdateValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimitUpdateValue.FromRawUnchecked(rawData);
}
