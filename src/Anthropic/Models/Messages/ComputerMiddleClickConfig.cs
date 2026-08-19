using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// ``middle_click``'s config overrides.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ComputerMiddleClickConfig, ComputerMiddleClickConfigFromRaw>)
)]
public sealed record class ComputerMiddleClickConfig : JsonModel
{
    /// <summary>
    /// Defer loading for this member. Must resolve to the same value on every enabled
    /// member of the toolset.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init { this._rawData.Set("defer_loading", value); }
    }

    /// <summary>
    /// Whether this member is offered to the model. Default is per member, per the
    /// toolset's documentation. A member whose enabled resolves false is withheld
    /// from the served schema.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public ComputerMiddleClickConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerMiddleClickConfig(ComputerMiddleClickConfig computerMiddleClickConfig)
        : base(computerMiddleClickConfig) { }
#pragma warning restore CS8618

    public ComputerMiddleClickConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerMiddleClickConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerMiddleClickConfigFromRaw.FromRawUnchecked"/>
    public static ComputerMiddleClickConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerMiddleClickConfigFromRaw : IFromRawJson<ComputerMiddleClickConfig>
{
    /// <inheritdoc/>
    public ComputerMiddleClickConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerMiddleClickConfig.FromRawUnchecked(rawData);
}
