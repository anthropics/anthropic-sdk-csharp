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
[JsonConverter(typeof(JsonModelConverter<BetaMcpToolConfig, BetaMcpToolConfigFromRaw>))]
public sealed record class BetaMcpToolConfig : JsonModel
{
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defer_loading", value);
        }
    }

    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public BetaMcpToolConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMcpToolConfig(BetaMcpToolConfig betaMcpToolConfig)
        : base(betaMcpToolConfig) { }
#pragma warning restore CS8618

    public BetaMcpToolConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMcpToolConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMcpToolConfigFromRaw.FromRawUnchecked"/>
    public static BetaMcpToolConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMcpToolConfigFromRaw : IFromRawJson<BetaMcpToolConfig>
{
    /// <inheritdoc/>
    public BetaMcpToolConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMcpToolConfig.FromRawUnchecked(rawData);
}
