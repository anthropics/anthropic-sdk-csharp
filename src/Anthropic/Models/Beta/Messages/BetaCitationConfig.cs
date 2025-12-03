using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationConfig, BetaCitationConfigFromRaw>))]
public sealed record class BetaCitationConfig : ModelBase
{
    public required bool Enabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "enabled"); }
        init { ModelBase.Set(this._rawData, "enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaCitationConfig() { }

    public BetaCitationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaCitationConfigFromRaw : IFromRaw<BetaCitationConfig>
{
    /// <inheritdoc/>
    public BetaCitationConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCitationConfig.FromRawUnchecked(rawData);
}
