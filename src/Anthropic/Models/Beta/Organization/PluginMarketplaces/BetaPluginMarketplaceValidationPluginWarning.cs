using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginMarketplaceValidationPluginWarning,
        BetaPluginMarketplaceValidationPluginWarningFromRaw
    >)
)]
public sealed record class BetaPluginMarketplaceValidationPluginWarning : JsonModel
{
    /// <summary>
    /// A stable identifier for the kind of warning.
    /// </summary>
    public required string ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// What would be left out, and why.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCode;
        _ = this.Message;
    }

    public BetaPluginMarketplaceValidationPluginWarning() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginMarketplaceValidationPluginWarning(
        BetaPluginMarketplaceValidationPluginWarning betaPluginMarketplaceValidationPluginWarning
    )
        : base(betaPluginMarketplaceValidationPluginWarning) { }
#pragma warning restore CS8618

    public BetaPluginMarketplaceValidationPluginWarning(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginMarketplaceValidationPluginWarning(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginMarketplaceValidationPluginWarningFromRaw.FromRawUnchecked"/>
    public static BetaPluginMarketplaceValidationPluginWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginMarketplaceValidationPluginWarningFromRaw
    : IFromRawJson<BetaPluginMarketplaceValidationPluginWarning>
{
    /// <inheritdoc/>
    public BetaPluginMarketplaceValidationPluginWarning FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginMarketplaceValidationPluginWarning.FromRawUnchecked(rawData);
}
