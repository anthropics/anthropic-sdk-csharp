using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaCitationConfig, BetaCitationConfigFromRaw>))]
public sealed record class BetaCitationConfig : JsonModel
{
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaCitationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCitationConfig(BetaCitationConfig betaCitationConfig)
        : base(betaCitationConfig) { }
#pragma warning restore CS8618

    public BetaCitationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationConfigFromRaw.FromRawUnchecked"/>
    public static BetaCitationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCitationConfig(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class BetaCitationConfigFromRaw : IFromRawJson<BetaCitationConfig>
{
    /// <inheritdoc/>
    public BetaCitationConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCitationConfig.FromRawUnchecked(rawData);
}
