using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginMarketplaceValidationPluginWarnings,
        BetaPluginMarketplaceValidationPluginWarningsFromRaw
    >)
)]
public sealed record class BetaPluginMarketplaceValidationPluginWarnings : JsonModel
{
    /// <summary>
    /// The plugin's name, as its entry in marketplace.json declares it.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The parts of the plugin a synchronization would leave out.
    /// </summary>
    public required IReadOnlyList<BetaPluginMarketplaceValidationPluginWarning> Warnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaPluginMarketplaceValidationPluginWarning>
            >("warnings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginMarketplaceValidationPluginWarning>>(
                "warnings",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        foreach (var item in this.Warnings)
        {
            item.Validate();
        }
    }

    public BetaPluginMarketplaceValidationPluginWarnings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginMarketplaceValidationPluginWarnings(
        BetaPluginMarketplaceValidationPluginWarnings betaPluginMarketplaceValidationPluginWarnings
    )
        : base(betaPluginMarketplaceValidationPluginWarnings) { }
#pragma warning restore CS8618

    public BetaPluginMarketplaceValidationPluginWarnings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginMarketplaceValidationPluginWarnings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginMarketplaceValidationPluginWarningsFromRaw.FromRawUnchecked"/>
    public static BetaPluginMarketplaceValidationPluginWarnings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginMarketplaceValidationPluginWarningsFromRaw
    : IFromRawJson<BetaPluginMarketplaceValidationPluginWarnings>
{
    /// <inheritdoc/>
    public BetaPluginMarketplaceValidationPluginWarnings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginMarketplaceValidationPluginWarnings.FromRawUnchecked(rawData);
}
