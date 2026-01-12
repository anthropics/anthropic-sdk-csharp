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
    typeof(JsonModelConverter<BetaMCPToolDefaultConfig, BetaMCPToolDefaultConfigFromRaw>)
)]
public sealed record class BetaMCPToolDefaultConfig : JsonModel
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

    public BetaMCPToolDefaultConfig() { }

    public BetaMCPToolDefaultConfig(BetaMCPToolDefaultConfig betaMCPToolDefaultConfig)
        : base(betaMCPToolDefaultConfig) { }

    public BetaMCPToolDefaultConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolDefaultConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMCPToolDefaultConfigFromRaw.FromRawUnchecked"/>
    public static BetaMCPToolDefaultConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMCPToolDefaultConfigFromRaw : IFromRawJson<BetaMCPToolDefaultConfig>
{
    /// <inheritdoc/>
    public BetaMCPToolDefaultConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMCPToolDefaultConfig.FromRawUnchecked(rawData);
}
