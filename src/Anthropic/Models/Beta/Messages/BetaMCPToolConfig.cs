using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Configuration for a specific tool in an MCP toolset.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaMCPToolConfig, BetaMCPToolConfigFromRaw>))]
public sealed record class BetaMCPToolConfig : ModelBase
{
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

    public bool? Enabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "enabled"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public BetaMCPToolConfig() { }

    public BetaMCPToolConfig(BetaMCPToolConfig betaMCPToolConfig)
        : base(betaMCPToolConfig) { }

    public BetaMCPToolConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMCPToolConfigFromRaw.FromRawUnchecked"/>
    public static BetaMCPToolConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMCPToolConfigFromRaw : IFromRaw<BetaMCPToolConfig>
{
    /// <inheritdoc/>
    public BetaMCPToolConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMCPToolConfig.FromRawUnchecked(rawData);
}
