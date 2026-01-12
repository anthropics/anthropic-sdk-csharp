using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Default configuration for tools in an MCP toolset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaMcpToolDefaultConfig, BetaMcpToolDefaultConfigFromRaw>)
)]
public sealed record class BetaMcpToolDefaultConfig : JsonModel
{
    public bool? DeferLoading
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "defer_loading"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "defer_loading", value);
        }
    }

    public bool? Enabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "enabled"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public BetaMcpToolDefaultConfig() { }

    public BetaMcpToolDefaultConfig(BetaMcpToolDefaultConfig betaMcpToolDefaultConfig)
        : base(betaMcpToolDefaultConfig) { }

    public BetaMcpToolDefaultConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolDefaultConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolDefaultConfigFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolDefaultConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolDefaultConfigFromRaw : IFromRawJson<BetaMcpToolDefaultConfig>
{
    /// <inheritdoc/>
    public BetaMcpToolDefaultConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMcpToolDefaultConfig.FromRawUnchecked(rawData);
}
