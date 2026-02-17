using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CitationsConfig, CitationsConfigFromRaw>))]
public sealed record class CitationsConfig : JsonModel
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

    public CitationsConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CitationsConfig(CitationsConfig citationsConfig)
        : base(citationsConfig) { }
#pragma warning restore CS8618

    public CitationsConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsConfigFromRaw.FromRawUnchecked"/>
    public static CitationsConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CitationsConfig(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class CitationsConfigFromRaw : IFromRawJson<CitationsConfig>
{
    /// <inheritdoc/>
    public CitationsConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CitationsConfig.FromRawUnchecked(rawData);
}
